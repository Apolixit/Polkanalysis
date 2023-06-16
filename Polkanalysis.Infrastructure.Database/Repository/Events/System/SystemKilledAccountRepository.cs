using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using Polkanalysis.Domain.Contracts.Secondary;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Domain.Contracts.Core;
using Microsoft.EntityFrameworkCore;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.System;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Contracts.Model;

namespace Polkanalysis.Infrastructure.Database.Repository.Events.System
{
    public class SystemKilledAccountRepository : EventDatabaseRepository, IDatabaseGet<SystemKilledAccountModel>
    {
        public SystemKilledAccountRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IBlockchainMapping mapping,
            ILogger<SystemKilledAccountRepository> logger) : base(context, substrateNodeRepository, mapping, logger)
        {
        }

        public async Task<bool> IsAlreadyExistsAsync(SystemKilledAccountModel eventModel, CancellationToken token)
        {
            return await _context.EventSystemKilledAccount.AnyAsync(x => x.Equals(eventModel), token);
        }

        public Task<IEnumerable<SystemKilledAccountModel>> GetAllAsync(CancellationToken token)
        {
            return Task.FromResult(_context.EventSystemKilledAccount ?? Enumerable.Empty<SystemKilledAccountModel>());
        }

        protected override async Task<bool> BuildRequestInsertAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = _mapping.Mapper.Map<SubstrateAccount>(data);

            var account = convertedData.ToStringAddress();

            var model = new SystemKilledAccountModel(
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

            _context.EventSystemKilledAccount.Add(model);
            return true;
        }


    }
}
