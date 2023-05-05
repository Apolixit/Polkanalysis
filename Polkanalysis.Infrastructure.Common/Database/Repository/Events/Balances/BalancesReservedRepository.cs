using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using Polkanalysis.Domain.Contracts.Secondary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Events.Balances;
using Polkanalysis.Infrastructure.Contracts.Model;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Events;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Domain.Contracts.Core;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.AjunaExtension;
using Microsoft.EntityFrameworkCore;

namespace Polkanalysis.Infrastructure.Common.Database.Repository.Events.Balances
{
    public class BalancesReservedRepository : EventDatabaseRepository, IDatabaseGet<BalancesReservedModel>
    {
        public BalancesReservedRepository(
            SubstrateDbContext context,
            ISubstrateRepository substrateNodeRepository,
            IBlockchainMapping mapping,
            ILogger<BalancesReservedRepository> logger) : base(context, substrateNodeRepository, mapping, logger)
        {
        }

        public async Task<bool> IsAlreadyExistsAsync(BalancesReservedModel eventModel, CancellationToken token)
        {
            return await _context.EventBalancesReserved.AnyAsync(x => x.Equals(eventModel), token);
        }

        public Task<IEnumerable<BalancesReservedModel>> GetAllAsync(CancellationToken token)
        {
            return Task.FromResult(_context.EventBalancesReserved ?? Enumerable.Empty<BalancesReservedModel>());
        }

        protected override async Task<bool> BuildRequestInsertAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = _mapping.Mapper.Map<BaseTuple<SubstrateAccount, U128>>(data);

            var account = ((SubstrateAccount)convertedData.Value[0]).ToStringAddress();
            var reservedAmount = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);

            var model = new BalancesReservedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
                account,
                reservedAmount);

            if (await IsAlreadyExistsAsync(model, token))
            {
                _logger.LogWarning($"{model} already exists in database !");
                return false;
            }

            await _context.EventBalancesReserved.AddAsync(model);
            return true;
        }

        
    }
}
