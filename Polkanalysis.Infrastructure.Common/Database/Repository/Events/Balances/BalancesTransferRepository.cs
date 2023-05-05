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

namespace Polkanalysis.Infrastructure.Common.Database.Repository.Events.Balances
{
    //[LinkedEvent("Domain.Contracts.Secondary.Pallet.Balances.Enums.Event.Transfer")]
    public class BalancesTransferRepository : EventDatabaseRepository, IDatabaseGet<BalancesTransferModel>
    {
        public BalancesTransferRepository(
            SubstrateDbContext context,
            ISubstrateRepository substrateNodeRepository,
            IBlockchainMapping mapping,
            ILogger<EventDatabaseRepository> logger) : base(context, substrateNodeRepository, mapping, logger)
        {
        }

        public async Task<bool> IsAlreadyExistsAsync(BalancesTransferModel eventModel, CancellationToken token)
        {
            return await _context.EventBalancesTransfer.AnyAsync(x => x.Equals(eventModel), token);
        }

        /// <summary>
        /// Insert a new transfer in the database
        /// </summary>
        /// <param name="eventModel"></param>
        /// <param name="data"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        protected override async Task<bool> BuildRequestInsertAsync(
            EventModel eventModel,
            IType data,
            CancellationToken token)
        {
            var convertedData = _mapping.Mapper.Map<BaseTuple<SubstrateAccount, SubstrateAccount, U128>>(data);

            var transferAmount = ((U128)convertedData.Value[2]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);

            var model = new BalancesTransferModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
                ((SubstrateAccount)convertedData.Value[0]).ToStringAddress(),
                ((SubstrateAccount)convertedData.Value[1]).ToStringAddress(),
                transferAmount);

            if (await IsAlreadyExistsAsync(model, token))
            {
                _logger.LogWarning($"{model} already exists in database !");
                return false;
            }

            await _context.EventBalancesTransfer.AddAsync(model);
            return true;
        }

        /// <summary>
        /// Get all balances transfer saved in database
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IEnumerable<BalancesTransferModel>> GetAllAsync(CancellationToken token)
        {
            return Task.FromResult(_context.EventBalancesTransfer ?? Enumerable.Empty<BalancesTransferModel>());
        }

        
    }
}
