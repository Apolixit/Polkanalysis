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
using Substrate.NET.Utils;
using Microsoft.EntityFrameworkCore;

namespace Polkanalysis.Infrastructure.Common.Database.Repository.Events.Balances
{
    public class BalancesSetRepository : EventDatabaseRepository, IDatabaseGet<BalancesBalanceSetModel>
    {
        public BalancesSetRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IBlockchainMapping mapping,
            ILogger<EventDatabaseRepository> logger) : base(context, substrateNodeRepository, mapping, logger)
        {
        }

        public async Task<bool> IsAlreadyExistsAsync(BalancesBalanceSetModel eventModel, CancellationToken token)
        {
            return await _context.EventBalancesBalanceSet.AnyAsync(x => x.Equals(eventModel), token);
        }

        public Task<IEnumerable<BalancesBalanceSetModel>> GetAllAsync(CancellationToken token)
        {
            return Task.FromResult(_context.EventBalancesBalanceSet ?? Enumerable.Empty<BalancesBalanceSetModel>());
        }

        protected override async Task<bool> BuildRequestInsertAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = _mapping.Mapper.Map<BaseTuple<SubstrateAccount, U128, U128>>(data);

            var rootAccount = ((SubstrateAccount)convertedData.Value[0]).ToStringAddress();
            var amount1 = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);
            var amount2 = ((U128)convertedData.Value[2]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);

            var model = new BalancesBalanceSetModel(
                            eventModel.BlockchainName,
                            eventModel.BlockId,
                            eventModel.BlockDate,
                            eventModel.EventId,
                            eventModel.ModuleName,
                            eventModel.ModuleEvent,
                            rootAccount,
                            amount1,
                            amount2);

            if (await IsAlreadyExistsAsync(model, token))
            {
                _logger.LogWarning($"{model} already exists in database !");
                return false;
            }

            _context.EventBalancesBalanceSet.Add(model);
            return true;
        }


    }
}
