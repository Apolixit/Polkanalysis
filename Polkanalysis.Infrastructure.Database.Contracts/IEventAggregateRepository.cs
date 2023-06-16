using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;

namespace Polkanalysis.Infrastructure.Contracts
{
    public interface IEventAggregateRepository
    {
        Task<IEnumerable<EventModel>> GetAllAsync(CancellationToken token);
        Task<IEnumerable<EventModel>> GetEventsByModuleNameAsync(string moduleName, CancellationToken token);
        Task AddAsync(EventModel eventModel, CancellationToken token);
    }
}
