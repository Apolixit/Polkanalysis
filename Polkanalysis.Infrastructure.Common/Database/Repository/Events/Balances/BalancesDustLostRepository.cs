using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.AjunaExtension;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Events;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Events.Balances;
using Polkanalysis.Infrastructure.Contracts.Model;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Common.Database.Repository.Events.Balances
{
    public class BalancesDustLostRepository : EventDatabaseRepository, IDatabaseGet<BalancesDustLostModel>
    {
        public BalancesDustLostRepository(
            SubstrateDbContext context,
            ISubstrateRepository substrateNodeRepository,
            IBlockchainMapping mapping,
            ILogger<BalancesDustLostRepository> logger) : 
            base(context, substrateNodeRepository, mapping, logger)
        {
        }

        public async Task<bool> IsAlreadyExistsAsync(BalancesDustLostModel eventModel, CancellationToken token)
        {
            return await _context.EventBalancesDustLost.AnyAsync(x => x.Equals(eventModel), token);
        }

        public Task<IEnumerable<BalancesDustLostModel>> GetAllAsync(CancellationToken token)
        {
            return Task.FromResult(_context.EventBalancesDustLost ?? Enumerable.Empty<BalancesDustLostModel>());
        }

        protected override async Task<bool> BuildRequestInsertAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = _mapping.Mapper.Map<BaseTuple<SubstrateAccount, U128>>(data);

            var account = ((SubstrateAccount)convertedData.Value[0]).ToStringAddress();
            var transferAmount = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);

            var model = new BalancesDustLostModel(
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

            _context.EventBalancesDustLost.Add(model);
            return true;
        }
    }
}
