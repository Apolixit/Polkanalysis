using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Crowdloan;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substrate.NET.Utils;

namespace Polkanalysis.Infrastructure.Database.Repository.Events.Crowdloan
{
    public class CrowloanCreatedRepository : EventDatabaseRepository<CrowloanCreatedModel>, ISearchEvent
    {
        public CrowloanCreatedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            ILogger<CrowloanCreatedRepository> logger) : base(context, substrateNodeRepository, logger)
        {
        }

        public string SearchName { get => "Crowdloan.Created"; }

        protected override DbSet<CrowloanCreatedModel> dbTable => _context.EventCrowdloanCreated;

        public override Task<IEnumerable<EventModel>> SearchAsync(SearchCriteria criteria, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        internal async override Task<CrowloanCreatedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums.EnumEvent,
                Id>();

            var crowloanId = (int)convertedData.Value.Value;

            return new CrowloanCreatedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
                crowloanId);
        }
    }
}
