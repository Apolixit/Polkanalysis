using Substrate.NetApi;
using Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.AjunaExtension
{
    public static class HexaExtension
    {
        public static string ToStringAddress(this Arr32U8 input) 
            => Utils.Bytes2HexString(input.Bytes);
    }
}
