using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives;
using System.Numerics;

namespace Substats.AjunaExtension
{
    public static class NumberExtension
    {
        public static U128 With(this U128 prim, BigInteger num)
        {
            prim.Create(num);
            return prim;
        }

        public static U64 With(this U64 prim, ulong num)
        {
            prim.Create(num);
            return prim;
        }

        public static U32 With(this U32 prim, uint num)
        {
            prim.Create(num);
            return prim;
        }

        public static Id ToParachainId(this uint id)
        {
            var paraId = new Id();
            var u32 = new U32();
            u32.Create(id);
            paraId.Value = u32;

            return paraId;
        }

        public static double ToDouble(this BigInteger num, int tokenDecimals)
        {
            var divider = new BigInteger(Math.Pow(10, tokenDecimals));
            return (double)(num / divider);
        }
        public static double ToDouble(this U128 num, int tokenDecimals) => ToDouble(num.Value, tokenDecimals);
    }
}
