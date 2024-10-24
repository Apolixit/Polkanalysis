using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.ExtrinsicTmp;
using Substrate.NetApi.Modules.Contracts;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Rpc
{
    public interface IRpc
    {
        public ITmpChain Chain { get; }
        public IState State { get; }
        public IAuthor Author { get; }
        public ISystem System { get; }
    }
}
