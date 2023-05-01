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
using Polkanalysis.Infrastructure.Contracts.Database.Model.Events.Identity;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Events;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Domain.Contracts.Core;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.Model.Types.Base;
using Microsoft.EntityFrameworkCore;

namespace Polkanalysis.Infrastructure.Common.Database.Repository.Events.Identity
{
    public class IdentityIdentitySetRepository : AnalysisRepository, IDatabaseGet<IdentityIdentitySetModel>
    {
        public IdentityIdentitySetRepository(
            SubstrateDbContext context,
            ISubstrateRepository substrateNodeRepository,
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

        protected override async Task BuildRequestInsertAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = _mapping.Mapper.Map<SubstrateAccount>(data);

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
                return;
            }

            await _context.EventIdentityIdentitySet.AddAsync(model);
        }

        
    }
}
