using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives;

namespace Substats.AjunaExtension
{
    public static class NumberExtension
    {
        public static Id ToParachainId(this uint id)
        {
            var paraId = new Id();
            var u32 = new U32();
            u32.Create(id);
            paraId.Value = u32;

            return paraId;
        }
    }
}
