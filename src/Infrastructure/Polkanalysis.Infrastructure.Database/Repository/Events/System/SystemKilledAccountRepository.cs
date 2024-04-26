using Microsoft.Extensions.Logging;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Domain.Contracts.Core;
using Microsoft.EntityFrameworkCore;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.System;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Contracts.Model;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Substrate.NET.Utils;

namespace Polkanalysis.Infrastructure.Database.Repository.Events.System
{
    public class SystemKilledAccountRepository : EventDatabaseRepository<SystemKilledAccountModel>
    {
        public SystemKilledAccountRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IBlockchainMapping mapping,
            ILogger<SystemKilledAccountRepository> logger) : base(context, substrateNodeRepository, mapping, logger)
        {
        }

        protected override DbSet<SystemKilledAccountModel> dbTable => _context.EventSystemKilledAccount;

        internal override async Task<SystemKilledAccountModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Blockchain.Contracts.Pallet.System.Enums.EnumEvent,
                SubstrateAccount>();

            var account = convertedData.ToStringAddress();

            return new SystemKilledAccountModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
                account);
        }
    }
}
