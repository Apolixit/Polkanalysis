using Substrate.NetApi;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.AjunaExtension
{
    //public static class AddressExtension
    //{
    //    public static string ToStringAddress(this AccountId32? sender, int ss58 = 42)
    //        => ToStringAddress(sender, (short)ss58);
    //    public static string ToStringAddress(this AccountId32? sender, short ss58 = 42)
    //    {
    //        if (sender == null) return string.Empty;

    //        return Utils.GetAddressFrom(sender.Bytes, ss58);
    //    }

    //    public static bool IsEqual(this AccountId32 a, AccountId32 b)
    //    {
    //        return a.Value.Encode().SequenceEqual(b.Value.Encode());
    //    }
    //}
}
