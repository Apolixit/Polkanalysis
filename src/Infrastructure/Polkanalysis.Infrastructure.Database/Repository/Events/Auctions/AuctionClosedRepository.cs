using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Crowdloan;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Repository.Events.Crowdloan;
using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Auctions;
using Substrate.NET.Utils;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Infrastructure.Database.Repository.Events.Auctions
{
    public class AuctionClosedRepository : EventDatabaseRepository<AuctionClosedModel>
    {
        public AuctionClosedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IBlockchainMapping mapping,
            ILogger<AuctionClosedRepository> logger) : base(context, substrateNodeRepository, mapping, logger)
        {
        }

        protected override DbSet<AuctionClosedModel> dbTable => _context.EventAuctionClosed;

        internal async override Task<AuctionClosedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Auctions.Enums.EnumEvent,
                Id>();

            var auctionIndex = (int)convertedData.Value.Value;

            return new AuctionClosedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
                auctionIndex);
        }
    }
}
