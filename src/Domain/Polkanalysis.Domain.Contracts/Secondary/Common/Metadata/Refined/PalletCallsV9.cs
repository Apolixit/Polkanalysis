using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Refined
{
    public class PalletCallsV9
    {
        /* readonly name: Text;
  readonly args: Vec<FunctionArgumentMetadataV9>;
  readonly docs: Vec<Text>; */

        public string Name { get; set; }
        public FunctionArgV9 Args { get; set; }
        public string[] Docs { get; set; }
    }
}
