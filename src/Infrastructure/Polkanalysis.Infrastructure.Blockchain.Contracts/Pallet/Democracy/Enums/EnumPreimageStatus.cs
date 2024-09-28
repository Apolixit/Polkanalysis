using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums
{
    [DomainMapping("pallet_democracy")]
    public enum PreimageStatus
    {

        Missing = 0,

        Available = 1,
    }

    /// <summary>
    /// >> 530 - Variant[pallet_democracy.PreimageStatus]
    /// </summary>
    public sealed class EnumPreimageStatus : BaseEnumExt<PreimageStatus, U32, BaseTuple<BaseVec<U8>, SubstrateAccount, U128, U32, BaseOpt<U32>>>
    {
    }
}
