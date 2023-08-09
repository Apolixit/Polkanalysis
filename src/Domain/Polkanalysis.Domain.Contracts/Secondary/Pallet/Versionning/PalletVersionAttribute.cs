using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Versionning
{
    /// <summary>
    /// Define pallet version
    /// What is very important, is when blockEnd is not set, it should be equal to uint.MaxValue
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct, AllowMultiple = true)]
    public class PalletVersionAttribute : System.Attribute
    {
        public PalletVersionAttribute(string blockchainName, string name, uint blockStart, uint blockEnd)
        {
            BlockchainName = blockchainName;
            StorageName = name;
            BlockStart = blockStart;
            BlockEnd = blockEnd;
        }

        public string BlockchainName { get; set; }
        public string StorageName { get; set; }
        public uint BlockStart { get; set; }
        public uint BlockEnd { get; set; }
    }
}
