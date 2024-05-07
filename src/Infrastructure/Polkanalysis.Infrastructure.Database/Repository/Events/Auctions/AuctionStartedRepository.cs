using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Crowdloan;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Repository.Events.Crowdloan;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Auctions;
using Substrate.NET.Utils;

namespace Polkanalysis.Infrastructure.Database.Repository.Events.Auctions
{
    public class AuctionStartedRepository : EventDatabaseRepository<AuctionStartedModel>
    {
        public AuctionStartedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IBlockchainMapping mapping,
            ILogger<AuctionStartedRepository> logger) : base(context, substrateNodeRepository, mapping, logger)
        {
        }

        protected override DbSet<AuctionStartedModel> dbTable => _context.EventAuctionStarted;

        internal async override Task<AuctionStartedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Auctions.Enums.EnumEvent,
                BaseTuple<U32, U32, U32>>();

            var auctionIndex = convertedData.Value[0].As<U32>();
            var leasePeriod = convertedData.Value[1].As<U32>();
            var ending = convertedData.Value[2].As<U32>();

            return new AuctionStartedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
                auctionIndex,
                leasePeriod,
                ending);
        }
    }
}
