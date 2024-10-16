using Substrate.NetApi.Model.Rpc;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core.ExtrinsicTmp
{
    public class TempNewBlock : IBlock
    {
        //
        // Summary:
        //     Extrinsics
        public TempNewExtrinsic[] Extrinsics { get; set; }

        //
        // Summary:
        //     Header
        public Header Header { get; set; }

        public IExtrinsic[] GetExtrinsics() => Extrinsics;
    }
}
