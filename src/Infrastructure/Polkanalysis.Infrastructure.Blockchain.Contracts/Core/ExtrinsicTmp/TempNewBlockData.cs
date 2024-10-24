using Newtonsoft.Json;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core.ExtrinsicTmp
{
    public class TempNewBlockData : IBlockData
    {
        //
        // Summary:
        //     Block
        public TempNewBlock Block { get; set; }

        //
        // Summary:
        //     Justification
        public object Justification { get; set; }

        //
        // Summary:
        //     Block Data Constructor
        //
        // Parameters:
        //   block:
        //
        //   justification:
        public TempNewBlockData(TempNewBlock block, object justification)
        {
            Block = block;
            Justification = justification;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public IBlock GetBlock() => Block;
    }
}
