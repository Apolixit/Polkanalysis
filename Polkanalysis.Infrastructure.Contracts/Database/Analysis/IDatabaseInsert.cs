using Polkanalysis.Infrastructure.Contracts.Model;
using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Contracts.Database.Analysis
{
    public interface IDatabaseInsert
    {
        public Task InsertAsync(EventsDatabaseModel eventModel, IType data, CancellationToken token);
    }
}
