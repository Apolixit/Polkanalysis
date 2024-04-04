//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Polkanalysis.Domain.Contracts.Core.Display;
using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v3.Enums
{
    [DomainMapping("xcm/v3/junction")]
    public enum NetworkId
    {
        ByGenesis = 0,
        ByFork = 1,
        Polkadot = 2,
        Kusama = 3,
        Westend = 4,
        Rococo = 5,
        Wococo = 6,
        Ethereum = 7,
        BitcoinCore = 8,
        BitcoinCash = 9
    }

    /// <summary>
    /// >> 16539 - Variant[xcm.v3.junction.NetworkId]
    /// </summary>
    public sealed class EnumNetworkId : BaseEnumExt<NetworkId, NameableSize32, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, NameableSize32>, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>, BaseVoid, BaseVoid>
    {
    }
}