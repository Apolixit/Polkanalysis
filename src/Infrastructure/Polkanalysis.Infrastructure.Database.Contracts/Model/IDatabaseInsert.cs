using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Substrate.NetApi.Model.Types;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model
{
    public interface IDatabaseInsert
    {
        public Task InsertAsync(EventModel eventModel, IType data, CancellationToken token);
    }
}
