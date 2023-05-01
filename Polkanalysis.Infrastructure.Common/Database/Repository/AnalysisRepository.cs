using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Npgsql;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Events;
using Polkanalysis.Infrastructure.Contracts.Model;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types;

namespace Polkanalysis.Infrastructure.Common.Database.Repository
{
    public abstract class AnalysisRepository : IDatabaseInsert
    {
        protected readonly SubstrateDbContext _context;
        protected readonly ISubstrateRepository _substrateNodeRepository;
        protected readonly ILogger<AnalysisRepository> _logger;
        protected readonly IBlockchainMapping _mapping;

        protected AnalysisRepository(
            SubstrateDbContext context,
            ISubstrateRepository substrateNodeRepository,
            IBlockchainMapping mapping,
            ILogger<AnalysisRepository> logger)
        {
            _context = context;
            _substrateNodeRepository = substrateNodeRepository;
            _logger = logger;
            _mapping = mapping;
        }

        protected abstract Task BuildRequestInsertAsync(
            EventModel eventModel,
            IType data,
            CancellationToken token);

        public async Task InsertAsync(
            EventModel eventModel,
            IType data,
            CancellationToken token)
        {
            Guard.Against.Null(eventModel);
            Guard.Against.Null(data);

            try
            {
                await BuildRequestInsertAsync(eventModel, data, token);

                var nbRows = await _context.SaveChangesAsync(token);
                if (nbRows != 1)
                    throw new InvalidOperationException("Inserted rows are inconsistent");

                _logger.LogInformation($"{eventModel.ModuleEvent} successfully inserted is database");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while trying to insert in database");
            }
        }

        protected async Task<Properties> GetChainInfoAsync(CancellationToken token)
            => await _substrateNodeRepository.Rpc.System.PropertiesAsync(token);
    }
}
