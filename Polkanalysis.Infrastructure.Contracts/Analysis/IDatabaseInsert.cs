using Polkanalysis.Infrastructure.Contracts.Model;
using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Contracts.Analysis
{
    //public interface IDatabaseInsert<in T>
    //    where T : IType, new()
    //{
    //    public Task InsertAsync(EventsDatabaseModel eventModel, T data, CancellationToken token);
    //}

    public interface IDatabaseInsert
    {
        public Task InsertAsync<T>(EventsDatabaseModel eventModel, T data, CancellationToken token);
    }
}
