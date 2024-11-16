using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums
{
    [DomainMapping("pallet_nfts/pallet")]
    public enum Error
    {
        NoPermission = 0,
        UnknownCollection = 1,
        AlreadyExists = 2,
        ApprovalExpired = 3,
        WrongOwner = 4,
        BadWitness = 5,
        CollectionIdInUse = 6,
        ItemsNonTransferable = 7,
        NotDelegate = 8,
        WrongDelegate = 9,
        Unapproved = 10,
        Unaccepted = 11,
        ItemLocked = 12,
        LockedItemAttributes = 13,
        LockedCollectionAttributes = 14,
        LockedItemMetadata = 15,
        LockedCollectionMetadata = 16,
        MaxSupplyReached = 17,
        MaxSupplyLocked = 18,
        MaxSupplyTooSmall = 19,
        UnknownItem = 20,
        UnknownSwap = 21,
        MetadataNotFound = 22,
        AttributeNotFound = 23,
        NotForSale = 24,
        BidTooLow = 25,
        ReachedApprovalLimit = 26,
        DeadlineExpired = 27,
        WrongDuration = 28,
        MethodDisabled = 29,
        WrongSetting = 30,
        InconsistentItemConfig = 31,
        NoConfig = 32,
        RolesNotCleared = 33,
        MintNotStarted = 34,
        MintEnded = 35,
        AlreadyClaimed = 36,
        IncorrectData = 37,
        WrongOrigin = 38,
        WrongSignature = 39,
        IncorrectMetadata = 40,
        MaxAttributesLimitReached = 41,
        WrongNamespace = 42,
        CollectionNotEmpty = 43,
        WitnessRequired = 44,
        MaxSupplyRequired = 45,
        InvalidItemId = 46,
        ItemIdNotSerial = 47,
        SerialMintEnabled = 48,
        AlreadyBurned = 49
    }

    /// <summary>
    /// >> 4334 - Variant[pallet_nfts.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
