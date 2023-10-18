using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Babe.Enums
{
    public enum NextConfigDescriptor
    {

        V1 = 1,
    }

    public sealed class EnumNextConfigDescriptor : BaseEnumExt<NextConfigDescriptor, BaseVoid, BaseTuple<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64,
        Substrate.NetApi.Model.Types.Primitive.U64>,
        EnumAllowedSlots>>
    {
    }
}
