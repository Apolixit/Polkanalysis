using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Collective.Enums
{
    public enum RawOrigin
    {

        Members = 0,

        Member = 1,

        _Phantom = 2,
    }

    /// <summary>
    /// >> 259 - Variant[pallet_collective.RawOrigin]
    /// </summary>
    public sealed class EnumRawOrigin : BaseEnumExt<RawOrigin, BaseTuple<U32, U32>, SubstrateAccount, BaseVoid>
    {
    }
}
