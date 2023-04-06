using Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntime;
using Polkanalysis.Infrastructure.Contracts.Model;
using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Contracts.Database.Analysis.Events
{
    public interface IEventsFactory
    {
        public Task ExecuteInsertAsync(RuntimeEvent runtimeEvent, Enum eventValue, EventsDatabaseModel eventModel, IType details, CancellationToken token);
    }
}
