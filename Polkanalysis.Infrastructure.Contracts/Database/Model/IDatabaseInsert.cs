using Polkanalysis.Infrastructure.Contracts.Database.Model.Events;
using Substrate.NetApi.Model.Types;

namespace Polkanalysis.Infrastructure.Contracts.Model
{
    public interface IDatabaseInsert
    {
        public Task InsertAsync(EventModel eventModel, IType data, CancellationToken token);
    }
}
