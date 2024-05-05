using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances;
using Polkanalysis.Infrastructure.Database.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Crowdloan;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Polkanalysis.Domain.Contracts.Core;
using Substrate.NET.Utils;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.Runtime.CompilerServices;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;

[assembly: InternalsVisibleTo("Polkanalysis.Infrastructure.Database.Tests")]
namespace Polkanalysis.Infrastructure.Database.Repository.Events.Crowdloan
{
    [BindEvents(RuntimeEvent.Crowdloan, "Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums.Event.Contributed")]
    public class CrowloanContributedRepository : EventDatabaseRepository<CrowloanContributedModel>
    {
        public CrowloanContributedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IBlockchainMapping mapping,
            ILogger<CrowloanContributedRepository> logger) : base(context, substrateNodeRepository, mapping, logger)
        {
        }

        protected override DbSet<CrowloanContributedModel> dbTable => _context.EventCrowdloanContributed;

        internal async override Task<CrowloanContributedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums.EnumEvent,
                BaseTuple<SubstrateAccount, Id, U128>>();

            var account = convertedData.Value[0].As<SubstrateAccount>().ToStringAddress();
            var crowloanId = (int)convertedData.Value[1].As<Id>().Value.Value;
            var amount = convertedData.Value[2].As<U128>().Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);

            return new CrowloanContributedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
                account,
                crowloanId,
                amount);
        }
    }
}
