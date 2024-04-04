using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1;
using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v2.Enums
{
    [DomainMapping("xcm/v2")]
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
