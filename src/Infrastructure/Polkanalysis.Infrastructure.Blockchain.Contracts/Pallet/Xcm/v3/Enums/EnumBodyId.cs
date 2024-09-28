//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Polkanalysis.Domain.Contracts.Core.Display;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.Collections.Generic;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v3.Enums
{
    [DomainMapping("xcm/v3/junction")]
    public enum BodyId
    {
        Unit = 0,
        Moniker = 1,
        Index = 2,
        Executive = 3,
        Technical = 4,
        Legislative = 5,
        Judicial = 6,
        Defense = 7,
        Administration = 8,
        Treasury = 9
    }

    /// <summary>
    /// >> 16540 - Variant[xcm.v3.junction.BodyId]
    /// </summary>
    public sealed class EnumBodyId : BaseEnumExt<BodyId, BaseVoid, NameableSize4, BaseCom<U32>, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>
    {
    }
}