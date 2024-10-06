using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v3;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v3.Enums;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums
{
    [DomainMapping("pallet_xcm/pallet")]
    public enum Event
    {

        Attempted = 0,

        Sent = 1,

        UnexpectedResponse = 2,

        ResponseReady = 3,

        Notified = 4,

        NotifyOverweight = 5,

        NotifyDispatchError = 6,

        NotifyDecodeFailed = 7,

        InvalidResponder = 8,

        InvalidResponderVersion = 9,

        ResponseTaken = 10,

        AssetsTrapped = 11,

        VersionChangeNotified = 12,

        SupportedVersionChanged = 13,

        NotifyTargetSendFail = 14,

        NotifyTargetMigrationFail = 15,

        AssetsClaimed = 16,
    }

    /// <summary>
    /// >> 121 - Variant[pallet_xcm.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event,
        EnumOutcome,
        BaseTuple<MultiLocation, MultiLocation, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v3.Xcm>, BaseTuple<MultiLocation, U64>, BaseTuple<U64, EnumResponse>, BaseTuple<U64, U8, U8>, BaseTuple<U64, U8, U8, Weight, Weight>, BaseTuple<U64, U8, U8>, BaseTuple<U64, U8, U8>, BaseTuple<MultiLocation, U64, BaseOpt<MultiLocation>>, BaseTuple<MultiLocation, U64>, U64, BaseTuple<Hash, MultiLocation, EnumVersionedMultiAssets>, BaseTuple<MultiLocation, U32>, BaseTuple<MultiLocation, U32>, BaseTuple<MultiLocation, U64, EnumError>, BaseTuple<EnumVersionedMultiLocation, U64>, BaseTuple<Hash, MultiLocation, EnumVersionedMultiAssets>>
    {
    }
}
