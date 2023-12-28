using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v2.Enums
{
    [DomainMapping("xcm/v2/traits")]
    public enum Error
    {

        Overflow = 0,

        Unimplemented = 1,

        UntrustedReserveLocation = 2,

        UntrustedTeleportLocation = 3,

        MultiLocationFull = 4,

        MultiLocationNotInvertible = 5,

        BadOrigin = 6,

        InvalidLocation = 7,

        AssetNotFound = 8,

        FailedToTransactAsset = 9,

        NotWithdrawable = 10,

        LocationCannotHold = 11,

        ExceedsMaxMessageSize = 12,

        DestinationUnsupported = 13,

        Transport = 14,

        Unroutable = 15,

        UnknownClaim = 16,

        FailedToDecode = 17,

        MaxWeightInvalid = 18,

        NotHoldingFees = 19,

        TooExpensive = 20,

        Trap = 21,

        UnhandledXcmVersion = 22,

        WeightLimitReached = 23,

        Barrier = 24,

        WeightNotComputable = 25,
    }

    /// <summary>
    /// >> 110 - Variant[xcm.v2.traits.Error]
    /// </summary>
    public sealed class EnumError : BaseEnumExt<Error, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid,
        U64, BaseVoid, U64, BaseVoid, BaseVoid>
    {
    }
}
