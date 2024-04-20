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
    public class SystemNewAccountRepository : EventDatabaseRepository<SystemNewAccountModel>
    {
        public SystemNewAccountRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IBlockchainMapping mapping,
            ILogger<SystemNewAccountRepository> logger) : base(context, substrateNodeRepository, mapping, logger)
        {
        }

        protected override DbSet<SystemNewAccountModel> dbTable => _context.EventSystemNewAccount;

        protected override async Task<SystemNewAccountModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Blockchain.Contracts.Pallet.System.Enums.EnumEvent,
                SubstrateAccount>();

            var account = convertedData.ToStringAddress();

            return new SystemNewAccountModel(
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
