using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime
{
    public interface IEventNode : INode
    {
        public RuntimeEvent Module { get; }
        public string ModuleName { get; }
        public Enum Method { get; }
        public string MethodName { get; }
        public INode EventData { get; }
        public string ToParameterJson();
    }
}
