using Substrate.NetApi.Model.Rpc;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core.ExtrinsicTmp
{
    public class TempOldBlock : IBlock
    {
        //
        // Summary:
        //     Extrinsics
        public TempOldExtrinsic[] Extrinsics { get; set; }

        //
        // Summary:
        //     Header
        public Header Header { get; set; }

        public IExtrinsic[] GetExtrinsics() => Extrinsics;
    }
}
