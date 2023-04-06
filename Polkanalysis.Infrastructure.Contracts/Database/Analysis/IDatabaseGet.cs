using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Contracts.Database.Analysis
{
    public interface IDatabaseGet<T> 
        where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync(CancellationToken token);
    }
}
