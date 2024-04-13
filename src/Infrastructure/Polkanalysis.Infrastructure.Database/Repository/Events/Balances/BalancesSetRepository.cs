using Microsoft.Extensions.Logging;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Domain.Contracts.Core;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;
using Microsoft.EntityFrameworkCore;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Contracts.Model;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts;

namespace Polkanalysis.Infrastructure.Database.Repository.Events.Balances
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
            var convertedData = data.CastToEnumValues<
                Blockchain.Contracts.Pallet.Balances.Enums.EnumEvent,
                BaseTuple<SubstrateAccount, U128, U128>>();

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
                _logger.LogDebug($"{model} already exists in database !");
                return false;
            }

            _context.EventBalancesBalanceSet.Add(model);
            return true;
        }


    }
}
