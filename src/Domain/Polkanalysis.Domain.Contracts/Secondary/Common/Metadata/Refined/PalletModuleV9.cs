using Substrate.NetApi.Model.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Refined
{
    public class PalletModuleV9
    {
        public string Name { get; set; }

        public PalletStorageV9? Storage { get; set; }

        public PalletCallsV9[]? Calls { get; set; }

        public PalletEventsV9[]? Events { get; set; }

        public required PalletConstantV9[] Constants { get; set; }

        public PalletErrorsV9 Errors { get; set; }

        public uint Index { get; set; }
    }
}
