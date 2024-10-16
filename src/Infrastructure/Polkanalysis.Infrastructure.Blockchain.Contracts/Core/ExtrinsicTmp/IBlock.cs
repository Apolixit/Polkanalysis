using Substrate.NetApi.Model.Rpc;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core.ExtrinsicTmp
{
    public interface IBlock
    {
        IExtrinsic[] GetExtrinsics();
        Header Header { get; set; }
    }
}
