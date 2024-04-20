using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Core;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Contracts.Model;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts;

namespace Polkanalysis.Infrastructure.Database.Repository.Events.Balances
{
    //[LinkedEvent("Domain.Contracts.Secondary.Pallet.Balances.Enums.Event.Transfer")]
    public class BalancesTransferRepository : EventDatabaseRepository<BalancesTransferModel>
    {
        public BalancesTransferRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IBlockchainMapping mapping,
            ILogger<BalancesTransferRepository> logger) : base(context, substrateNodeRepository, mapping, logger)
        {
        }

        protected override DbSet<BalancesTransferModel> dbTable => _context.EventBalancesTransfer;

        /// <summary>
        /// Insert a new transfer in the database
        /// </summary>
        /// <param name="eventModel"></param>
        /// <param name="data"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        protected override async Task<BalancesTransferModel> BuildModelAsync(
            EventModel eventModel,
            IType data,
            CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Blockchain.Contracts.Pallet.Balances.Enums.EnumEvent, 
                BaseTuple<SubstrateAccount, SubstrateAccount, U128>>();

            var transferAmount = ((U128)convertedData.Value[2]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);

            return new BalancesTransferModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
                ((SubstrateAccount)convertedData.Value[0]).ToStringAddress(),
                ((SubstrateAccount)convertedData.Value[1]).ToStringAddress(),
                transferAmount);
        }
    }
}
