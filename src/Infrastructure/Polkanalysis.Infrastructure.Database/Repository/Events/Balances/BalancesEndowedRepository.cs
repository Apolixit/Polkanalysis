using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using Polkanalysis.Domain.Contracts.Secondary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Domain.Contracts.Core;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;
using Microsoft.EntityFrameworkCore;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Contracts.Model;

namespace Polkanalysis.Infrastructure.Database.Repository.Events.Balances
{
    public class BalancesEndowedRepository : EventDatabaseRepository, IDatabaseGet<BalancesEndowedModel>
    {
        public BalancesEndowedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
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

        protected override async Task<bool> BuildRequestInsertAsync(EventModel eventModel, IType data, CancellationToken token)
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
                return false;
            }

            _context.EventBalancesEndowed.Add(model);
            return true;
        }


    }
}
