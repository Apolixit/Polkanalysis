using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Types;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums
{
    [DomainMapping("pallet_nfts/pallet")]
    public enum Event
    {
        Created = 0, //
        ForceCreated = 1, //
        Destroyed = 2, //
        Issued = 3, //
        Transferred = 4, //
        Burned = 5, //
        ItemTransferLocked = 6,
        ItemTransferUnlocked = 7,
        ItemPropertiesLocked = 8,
        CollectionLocked = 9, //
        OwnerChanged = 10, //
        TeamChanged = 11, //
        TransferApproved = 12, //
        ApprovalCancelled = 13,
        AllApprovalsCancelled = 14,
        CollectionConfigChanged = 15,
        CollectionMetadataSet = 16,
        CollectionMetadataCleared = 17,
        ItemMetadataSet = 18,
        ItemMetadataCleared = 19,
        Redeposited = 20,
        AttributeSet = 21,
        AttributeCleared = 22,
        ItemAttributesApprovalAdded = 23,
        ItemAttributesApprovalRemoved = 24,
        OwnershipAcceptanceChanged = 25,
        CollectionMaxSupplySet = 26,
        CollectionMintSettingsUpdated = 27,
        NextCollectionIdIncremented = 28,
        ItemPriceSet = 29,
        ItemPriceRemoved = 30,
        ItemBought = 31,
        TipSent = 32,
        SwapCreated = 33,
        SwapCancelled = 34,
        SwapClaimed = 35,
        PreSignedAttributesSet = 36,
        PalletAttributeSet = 37
    }

    /// <summary>
    /// >> 4005 - Variant[pallet_nfts.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event,
        BaseTuple<IncrementableU256, SubstrateAccount, SubstrateAccount>,
        BaseTuple<IncrementableU256, SubstrateAccount>,
        IncrementableU256,
        BaseTuple<IncrementableU256, U128, SubstrateAccount>,
        BaseTuple<IncrementableU256, U128, SubstrateAccount, SubstrateAccount>,
        BaseTuple<IncrementableU256, U128, SubstrateAccount>,
        BaseTuple<IncrementableU256, U128>,
        BaseTuple<IncrementableU256, U128>,
        BaseTuple<IncrementableU256, U128, Bool, Bool>,
        IncrementableU256,
        BaseTuple<IncrementableU256, SubstrateAccount>,
        BaseTuple<IncrementableU256, BaseOpt<SubstrateAccount>, BaseOpt<SubstrateAccount>, BaseOpt<SubstrateAccount>>,
        BaseTuple<IncrementableU256, U128, SubstrateAccount, SubstrateAccount, BaseOpt<U32>>,
        BaseTuple<IncrementableU256, U128, SubstrateAccount, SubstrateAccount>,
        BaseTuple<IncrementableU256, U128, SubstrateAccount>,
        IncrementableU256,
        BaseTuple<IncrementableU256, BaseVec<U8>>,
        IncrementableU256,
        BaseTuple<IncrementableU256, U128, BaseVec<U8>>,
        BaseTuple<IncrementableU256, U128>,
        BaseTuple<IncrementableU256, BaseVec<U128>>,
        BaseTuple<IncrementableU256, BaseOpt<U128>, BaseVec<U8>, BaseVec<U8>, EnumAttributeNamespace>,
        BaseTuple<IncrementableU256, BaseOpt<U128>, BaseVec<U8>, EnumAttributeNamespace>,
        BaseTuple<IncrementableU256, U128, SubstrateAccount>,
        BaseTuple<IncrementableU256, U128, SubstrateAccount>,
        BaseTuple<SubstrateAccount, BaseOpt<IncrementableU256>>,
        BaseTuple<IncrementableU256, U128>,
        IncrementableU256,
        BaseOpt<IncrementableU256>,
        BaseTuple<IncrementableU256, U128, U128, BaseOpt<SubstrateAccount>>,
        BaseTuple<IncrementableU256, U128>,
        BaseTuple<IncrementableU256, U128, U128, SubstrateAccount, SubstrateAccount>,
        BaseTuple<IncrementableU256, U128, SubstrateAccount, SubstrateAccount, U128>,
        BaseTuple<IncrementableU256, U128, IncrementableU256, BaseOpt<U128>, BaseOpt<PriceWithDirection>, U32>,
        BaseTuple<IncrementableU256, U128, IncrementableU256, BaseOpt<U128>, BaseOpt<PriceWithDirection>, U32>,
        BaseTuple<IncrementableU256, U128, SubstrateAccount, IncrementableU256, U128, SubstrateAccount, BaseOpt<PriceWithDirection>, U32>,
        BaseTuple<IncrementableU256, U128, EnumAttributeNamespace>,
        BaseTuple<IncrementableU256, BaseOpt<U128>, EnumPalletAttributes, BaseVec<U8>>
    >
    {
        
    }
}
