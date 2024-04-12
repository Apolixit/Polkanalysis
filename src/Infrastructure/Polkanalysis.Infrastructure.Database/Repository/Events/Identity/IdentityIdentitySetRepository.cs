using Microsoft.Extensions.Logging;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Domain.Contracts.Core;
using Microsoft.EntityFrameworkCore;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Identity;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Contracts.Model;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Substrate.NET.Utils;

namespace Polkanalysis.Infrastructure.Database.Repository.Events.Identity
{
    public class IdentityIdentitySetRepository : EventDatabaseRepository, IDatabaseGet<IdentityIdentitySetModel>
    {
        public IdentityIdentitySetRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IBlockchainMapping mapping,
            ILogger<IdentityIdentitySetRepository> logger) : base(context, substrateNodeRepository, mapping, logger)
        {
        }

        public async Task<bool> IsAlreadyExistsAsync(IdentityIdentitySetModel eventModel, CancellationToken token)
        {
            return await _context.EventIdentityIdentitySet.AnyAsync(x => x.Equals(eventModel), token);
        }

        public Task<IEnumerable<IdentityIdentitySetModel>> GetAllAsync(CancellationToken token)
        {
            return Task.FromResult(_context.EventIdentityIdentitySet ?? Enumerable.Empty<IdentityIdentitySetModel>());
        }

        protected override async Task<bool> BuildRequestInsertAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = data.CastToEnumValues<
                Blockchain.Contracts.Pallet.Identity.Enums.EnumEvent,
                SubstrateAccount>();

            var account = convertedData.ToStringAddress();

            var model = new IdentityIdentitySetModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
                account);

            if (await IsAlreadyExistsAsync(model, token))
            {
                _logger.LogWarning($"{model} already exists in database !");
                return false;
            }

            _context.EventIdentityIdentitySet.Add(model);
            return true;
        }


    }
}
