using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Babe
{
    public enum NextConfigDescriptor
    {

        V1 = 1,
    }

    public sealed class EnumNextConfigDescriptor : BaseEnumExt<NextConfigDescriptor, BaseVoid, BaseTuple<BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U64, 
        Ajuna.NetApi.Model.Types.Primitive.U64>, 
        EnumAllowedSlots>>
    {
    }
}
