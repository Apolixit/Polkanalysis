using Ardalis.GuardClauses;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Runtime
{
    public class EventNode : GenericNode, IEventNode
    {
        private RuntimeEvent? _module = null;
        public RuntimeEvent Module {
            get
            {
                if (_module == null)
                {
                    var runtimeEvent = getRuntimeEvent();
                    
                    Guard.Against.Null(runtimeEvent);
                    _module = (RuntimeEvent)runtimeEvent.HumanData;
                    Guard.Against.Null(_module);
                }

                return _module.Value;
            }
            internal set
            {
                _module = value;
            }
        }

        private Enum? _method = null;
        public Enum Method
        {
            get
            {
                if (_method == null)
                {
                    var runtimeEvent = getRuntimeEvent();
                    Guard.Against.Null(runtimeEvent);

                    var palletEvent = runtimeEvent.Children[0];

                    Guard.Against.Null(palletEvent);
                    _method = (Enum?)palletEvent.HumanData;
                    Guard.Against.Null(_method);
                }

                return _method!;
            }
            internal set
            {
                _method = value;
            }
        }

        private INode getRuntimeEvent()
        {
            if (Children == null || Children.Count == 0)
                throw new InvalidOperationException("EventRecord node has no children...");

            var globalEvent = Children[1];
            if (globalEvent.Children == null || globalEvent.Children.Count == 0)
                throw new InvalidOperationException("RuntimeEvent node has no children...");

            var runtimeEvent = globalEvent.Children[0];

            return runtimeEvent;
        }
    }
}
