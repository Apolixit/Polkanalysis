using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Xcm.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Xcm.v2.Enums
{
    public enum Response
    {

        Null = 0,

        Assets = 1,

        ExecutionResult = 2,

        Version = 3,
    }

    /// <summary>
    /// >> 140 - Variant[xcm.v2.Response]
    /// </summary>
    public sealed class EnumResponse : BaseEnumExt<Response, BaseVoid, MultiAssets, BaseOpt<BaseTuple<U32, EnumError>>, U32>
    {
    }
}
