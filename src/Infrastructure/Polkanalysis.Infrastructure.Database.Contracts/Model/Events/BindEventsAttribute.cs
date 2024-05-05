using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Repository.Events
{
    /// <summary>
    /// Bind a database event repository to a runtime event
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class BindEventsAttribute : Attribute
    {
        public BindEventsAttribute(RuntimeEvent runtimeEvent, string eventValue)
        {
            RuntimeEvent = runtimeEvent;
            EventValue = eventValue;
        }

        public RuntimeEvent RuntimeEvent { get; set; }
        public string EventValue { get; set; }
    }
}
