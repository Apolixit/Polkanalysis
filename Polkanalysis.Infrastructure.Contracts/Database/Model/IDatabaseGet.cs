using Polkanalysis.Infrastructure.Contracts.Database.Model.Events;

namespace Polkanalysis.Infrastructure.Contracts.Model
{
    public interface IDatabaseGet<T> 
        where T : class
    {
        public Task<bool> IsAlreadyExistsAsync(T eventModel, CancellationToken token);
        public Task<IEnumerable<T>> GetAllAsync(CancellationToken token);
    }
}
