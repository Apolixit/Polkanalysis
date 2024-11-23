using Ardalis.GuardClauses;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Runtime
{
    public class EventNode : GenericNode, IEventNode
    {
        private RuntimeEvent? _module = null;
        public RuntimeEvent Module
        {
            get
            {
                if (_module is null)
                {
                    var runtimeEvent = getRuntimeEvent();

                    Guard.Against.Null(runtimeEvent, nameof(runtimeEvent));
                    _module = Enum.Parse<RuntimeEvent>(runtimeEvent.Name);
                    Guard.Against.Null(_module, nameof(_module));
                }

                return _module.Value;
            }
            internal set
            {
                _module = value;
            }
        }

        public string ModuleName => getRuntimeEvent().Name;

        public string MethodName => EventData.Name;

        private Enum? _method = null;
        public Enum Method
        {
            get
            {
                if (_method is null)
                {
                    var palletEvent = EventData;

                    Guard.Against.Null(palletEvent);
                    _method = (Enum?)palletEvent.HumanData;
                    Guard.Against.Null(_method, nameof(_method));
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

        public string ToParameterJson()
        {
            var method = this[Method.ToString()]!;

            var output = new List<Dictionary<string, object>>();
            foreach (var child in method.Children)
            {
                output.Add(child.ToDictionnary());
            }

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return JsonSerializer.Serialize(output, options);
        }

        private INode? _eventData = null;
        public INode EventData
        {
            get
            {
                if (_eventData is null)
                {
                    var runtimeEvent = getRuntimeEvent();
                    Guard.Against.Null(runtimeEvent, nameof(runtimeEvent));

                    return runtimeEvent.Children[0];
                }

                return _eventData;
            }
        }

        
    }
}
