using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substrate.NET.Utils
{
    public static class SubstrateCheck
    {
        public static bool CheckHash(string hash)
        {
            if (string.IsNullOrEmpty(hash)) return false;

            var blockStringStart = "0x";
            if (!hash.ToUpper().StartsWith(blockStringStart.ToUpper())) return false;

            return hash.Length >= 2;
        }
    }
}
