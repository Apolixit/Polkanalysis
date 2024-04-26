using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types;

namespace Polkanalysis.Infrastructure.Database.Repository
{
    public abstract class EventDatabaseRepository<TModel> : IDatabaseInsert, IDatabaseGet<TModel>
        where TModel : EventModel
    {
        protected readonly SubstrateDbContext _context;
        protected readonly ISubstrateService _substrateNodeRepository;
        protected readonly ILogger<EventDatabaseRepository<TModel>> _logger;
        protected readonly IBlockchainMapping _mapping;

        protected abstract DbSet<TModel> dbTable { get; }

        protected EventDatabaseRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IBlockchainMapping mapping,
            ILogger<EventDatabaseRepository<TModel>> logger)
        {
            _context = context;
            _substrateNodeRepository = substrateNodeRepository;
            _logger = logger;
            _mapping = mapping;
        }

        /// <summary>
        /// The method to build the database model from the substrate event data
        /// </summary>
        /// <param name="eventModel"></param>
        /// <param name="data"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        internal abstract Task<TModel> BuildModelAsync(
            EventModel eventModel,
            IType data,
            CancellationToken token);

        /// <summary>
        /// Insert the given event in the database
        /// </summary>
        /// <param name="eventModel"></param>
        /// <param name="data"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task InsertAsync(
            EventModel eventModel,
            IType data,
            CancellationToken token)
        {
            Guard.Against.Null(eventModel, nameof(eventModel));
            Guard.Against.Null(data, nameof(data));

            try
            {
                var model = await BuildModelAsync(eventModel, data, token);

                if (await IsAlreadyExistsAsync(model, token))
                {
                    _logger.LogDebug("[EventDatabaseRepository] {model} already exists in database !", model);
                    return;
                }

                dbTable.Add(model);

                var nbRows = _context.SaveChanges();
                if (nbRows != 1)
                    throw new InvalidOperationException("Inserted rows are inconsistent");

                _logger.LogDebug("{moduleEvent} successfully inserted is database at block = {blockId}", eventModel.ModuleEvent, eventModel.BlockId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[EventDatabaseRepository] Error while trying to insert in database : {moduleName} | {moduleEvent} at block = {blockId}", eventModel.ModuleName, eventModel.ModuleEvent, eventModel.BlockId);
            }
        }

        protected async Task<Properties> GetChainInfoAsync(CancellationToken token)
            => await _substrateNodeRepository.Rpc.System.PropertiesAsync(token);

        /// <summary>
        /// Check if the event is already present in the database
        /// </summary>
        /// <param name="eventModel"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<bool> IsAlreadyExistsAsync(TModel eventModel, CancellationToken token)
        {
            return await dbTable.AnyAsync(x => x.Equals(eventModel), token);
        }

        /// <summary>
        /// Return all the elements from a given table in the database
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TModel>> GetAllAsync(CancellationToken token)
        {
            return await dbTable.ToListAsync();
        }
    }
}
