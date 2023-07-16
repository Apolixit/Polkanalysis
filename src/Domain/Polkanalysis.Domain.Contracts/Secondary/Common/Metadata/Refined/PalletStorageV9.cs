using Substrate.NetApi.Model.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Refined
{
    public class PalletStorageV9
    {
        public string Prefix { get; set; }

        public EntryV9[] Entries { get; set; }
    }
}
