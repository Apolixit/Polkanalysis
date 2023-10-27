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
    public class IdentityIdentityClearedRepository : EventDatabaseRepository, IDatabaseGet<IdentityIdentityClearedModel>
    {
        public IdentityIdentityClearedRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IBlockchainMapping mapping,
            ILogger<IdentityIdentityClearedRepository> logger) : base(context, substrateNodeRepository, mapping, logger)
        {
        }

        public async Task<bool> IsAlreadyExistsAsync(IdentityIdentityClearedModel eventModel, CancellationToken token)
        {
            return await _context.EventIdentityIdentityCleared.AnyAsync(x => x.Equals(eventModel), token);
        }

        public Task<IEnumerable<IdentityIdentityClearedModel>> GetAllAsync(CancellationToken token)
        {
            return Task.FromResult(_context.EventIdentityIdentityCleared ?? Enumerable.Empty<IdentityIdentityClearedModel>());
        }

        protected override async Task<bool> BuildRequestInsertAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = _mapping.Map<IType, BaseTuple<SubstrateAccount, U128>>(data);

            var account = ((SubstrateAccount)convertedData.Value[0]).ToStringAddress();
            var amount = ((U128)convertedData.Value[1]).Value.ToDouble((await GetChainInfoAsync(token)).TokenDecimals);

            var model = new IdentityIdentityClearedModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
                account,
                amount);

            if (await IsAlreadyExistsAsync(model, token))
            {
                _logger.LogWarning($"{model} already exists in database !");
                return false;
            }

            _context.EventIdentityIdentityCleared.Add(model);
            return true;
        }


    }
}
