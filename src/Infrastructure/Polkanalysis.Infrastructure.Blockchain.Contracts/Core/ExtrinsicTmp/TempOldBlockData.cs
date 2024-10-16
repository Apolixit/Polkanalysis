using Newtonsoft.Json;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core.ExtrinsicTmp
{
    public class TempOldBlockData : IBlockData
    {
        //
        // Summary:
        //     Block
        public TempOldBlock Block { get; set; }

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
        [JsonConstructor]
        public TempOldBlockData(TempOldBlock block, object justification)
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
