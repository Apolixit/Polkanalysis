using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Events.Balances;
using Polkanalysis.Infrastructure.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Events;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Domain.Contracts.Core;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.AjunaExtension;
using Microsoft.EntityFrameworkCore;

namespace Polkanalysis.Infrastructure.Common.Database.Repository.Events.Balances
{
    public class BalancesEndowedRepository : AnalysisRepository, IDatabaseGet<BalancesEndowedModel>
    {
        public BalancesEndowedRepository(
            SubstrateDbContext context,
            ISubstrateRepository substrateNodeRepository,
            IBlockchainMapping mapping,
            ILogger<BalancesEndowedRepository> logger) : base(context, substrateNodeRepository, mapping, logger)
        {
        }

        public async Task<bool> IsAlreadyExistsAsync(BalancesEndowedModel eventModel, CancellationToken token)
        {
            return await _context.EventBalancesEndowed.AnyAsync(x => x.Equals(eventModel), token);
        }

        public Task<IEnumerable<BalancesEndowedModel>> GetAllAsync(CancellationToken token)
        {
            return Task.FromResult(_context.EventBalancesEndowed ?? Enumerable.Empty<BalancesEndowedModel>());
        }

        protected override async Task BuildRequestInsertAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = _mapping.Mapper.Map<BaseTuple<SubstrateAccount, U128>>(data);

            var account = ((SubstrateAccount)convertedData.Value[0]).ToStringAddress();
            var transferAmount = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);

            var model = new BalancesEndowedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
                account,
                transferAmount);

            if (await IsAlreadyExistsAsync(model, token))
            {
                _logger.LogWarning($"{model} already exists in database !");
                return;
            }

            await _context.EventBalancesEndowed.AddAsync(model);
        }

        
    }
}
