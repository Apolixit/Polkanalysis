using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Repository.Models
{
    public class PalletVersions
    {
        public int PalletId { get; set; }
        public string PalletName { get; set; } = string.Empty;
        public int PalletVersion { get; set; }
        public uint BlockStart { get; set; }
        public uint? BlockEnd { get; set; }
    }
}
