using Ardalis.GuardClauses;
using Polkanalysis.Hub;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types;

namespace Polkanalysis.Infrastructure.Database.Repository
{
    /// <summary>
    /// Abstract class to define the desire behavior of Substrate events that are insert into the database and allowed to be query by applications
    /// </summary>
    /// <typeparam name="TModel">The EF model (<see cref="SubstrateDbContext"/></typeparam>)
    /// <typeparam name="TSearchCriteria">The parameters allowed to query the event</typeparam>
    public abstract class EventDatabaseRepository<TModel, TSearchCriteria> : IDatabaseInsert, IDatabaseGet<TModel>, ISearchEvent<TSearchCriteria>
        where TModel : EventModel
        where TSearchCriteria : SearchCriteria, new()
    {
        protected readonly SubstrateDbContext _context;
        protected readonly ISubstrateService _substrateNodeRepository;
        protected readonly IHubConnection _hubConnection;
        protected readonly ILogger<EventDatabaseRepository<TModel, TSearchCriteria>> _logger;

        protected abstract DbSet<TModel> dbTable { get; }
        public abstract string SearchName { get; }

        protected EventDatabaseRepository(
            SubstrateDbContext context,
            ISubstrateService substrateNodeRepository,
            IHubConnection hubConnection,
            ILogger<EventDatabaseRepository<TModel, TSearchCriteria>> logger)
        {
            _context = context;
            _substrateNodeRepository = substrateNodeRepository;
            _hubConnection = hubConnection;
            _logger = logger;
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

                var nbRows = await _context.SaveChangesAsync(token);
                if (nbRows != 1)
                    throw new InvalidOperationException("Inserted rows are inconsistent");

                _logger.LogDebug("{moduleEvent} successfully inserted is database at block = {blockId}", eventModel.ModuleEvent, eventModel.BlockId);

                // Publish event to hub
                await PublishEventToHubAsync(model, token);
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

        /// <summary>
        /// The search query function defined in <see cref="ISearchEvent"/>
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<IEnumerable<EventModel>> SearchAsync(TSearchCriteria criteria, CancellationToken token)
        {
            var model = dbTable.AsQueryable();

            //if (criteria.CrowdloanId is not null) model = model.WhereCriteria(criteria.CrowdloanId, x => x.CrowdloanId);
            if (criteria.BlockDate is not null) model = model.WhereCriteria(criteria.BlockDate, x => x.BlockDate);

            if(criteria.BlockNumber is not null) model = model.WhereCriteria(criteria.BlockNumber, x => x.BlockId);

            //if (criteria.ToDate is not null)
            //    model = model.Where(x => x.BlockDate <= criteria.ToDate.Value);

            //if (criteria.FromBlock is not null)
            //    model = model.Where(x => x.BlockId >= criteria.FromBlock.Value);

            //if (criteria.ToBlock is not null)
            //    model = model.Where(x => x.BlockId <= criteria.ToBlock.Value);

            model = await SearchInnerAsync(criteria, model, token);
            var dbResult = await model.ToListAsync();

            if (!dbResult.Any())
                _logger.LogWarning("[{repositoryName}] No transactions found in the database with query {searchQuery}", this.GetType().Name, criteria);

            return dbResult;
        }

        /// <summary>
        /// The custom event specific logic (to be defined by each child event)
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="model"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        protected abstract Task<IQueryable<TModel>> SearchInnerAsync(TSearchCriteria criteria, IQueryable<TModel> model, CancellationToken token);

        /// <summary>
        /// The search query parameter defined in <see cref="ISearchEvent"/>
        /// </summary>
        /// <returns></returns>
        public Type SearchCriterias => typeof(TSearchCriteria);

        /// <summary>
        /// Publish event to the hub (facultative)
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public virtual Task PublishEventToHubAsync(TModel model, CancellationToken token)
        {
            return Task.CompletedTask;
        }
    }
}
