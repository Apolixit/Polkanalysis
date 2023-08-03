using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Version
{
    public class PalletVersionModel : BlockchainModel
    {
        public string PalletName { get; set; } = string.Empty;
        public int PalletVersion { get; set; }
        public uint SpecVersion { get; set; }
        public uint BlockStart { get; set; }
        public uint? BlockEnd { get; set; }
    }
}
