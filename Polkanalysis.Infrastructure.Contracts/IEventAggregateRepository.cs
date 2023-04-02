using Polkanalysis.Infrastructure.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Contracts
{
    public interface IEventAggregateRepository
    {
        Task<IEnumerable<EventsDatabaseModel>> GetAllAsync(CancellationToken token);
        Task<IEnumerable<EventsDatabaseModel>> GetEventsByModuleNameAsync(string moduleName, CancellationToken token);
        Task AddAsync(EventsDatabaseModel eventModel, CancellationToken token);
    }
}
