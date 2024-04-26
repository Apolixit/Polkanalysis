using Microsoft.Extensions.Logging;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Domain.Contracts.Core;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;
using Microsoft.EntityFrameworkCore;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Identity;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Contracts.Model;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;

namespace Polkanalysis.Infrastructure.Database.Repository.Events.Identity
{
    public class IdentityIdentityClearedRepository : EventDatabaseRepository<IdentityIdentityClearedModel>
    {
        public IdentityIdentityClearedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IBlockchainMapping mapping,
            ILogger<IdentityIdentityClearedRepository> logger) : base(context, substrateNodeRepository, mapping, logger)
        {
        }

        protected override DbSet<IdentityIdentityClearedModel> dbTable => _context.EventIdentityIdentityCleared;

        internal override async Task<IdentityIdentityClearedModel> BuildModelAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Blockchain.Contracts.Pallet.Identity.Enums.EnumEvent,
                BaseTuple<SubstrateAccount, U128>>();

            var account = ((SubstrateAccount)convertedData.Value[0]).ToStringAddress();
            var amount = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);

            return new IdentityIdentityClearedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
                account,
                amount);
        }
    }
}
