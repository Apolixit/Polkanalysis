using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Types
{
    [DomainMapping("pallet_democracy/types")]
    public enum MetadataOwner
    {
        External = 0,
        Proposal = 1,
        Referendum = 2
    }

    /// <summary>
    /// >> 13963 - Variant[pallet_democracy.types.MetadataOwner]
    /// </summary>
    public sealed class EnumMetadataOwner : BaseEnumExt<MetadataOwner, BaseVoid, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>
    {
    }
}
