using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Events.Balances;
using Polkanalysis.Infrastructure.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Events.System;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Events;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Events.Identity;
using Polkanalysis.Domain.Contracts.Core;
using Microsoft.EntityFrameworkCore;

namespace Polkanalysis.Infrastructure.Common.Database.Repository.Events.System
{
    public class SystemKilledAccountRepository : EventDatabaseRepository, IDatabaseGet<SystemKilledAccountModel>
    {
        public SystemKilledAccountRepository(
            SubstrateDbContext context,
            ISubstrateRepository substrateNodeRepository,
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

            await _context.EventSystemKilledAccount.AddAsync(model);
            return true;
        }

        
    }
}
