//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi.Model.Types.Base;
using System.Collections.Generic;


namespace Substats.Bajun.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.pallet
{
    
    
    public enum Error
    {
        
        OrganizerNotSet = 0,
        
        EarlyStartTooEarly = 1,
        
        EarlyStartTooLate = 2,
        
        SeasonStartTooLate = 3,
        
        SeasonEndTooLate = 4,
        
        UnknownSeason = 5,
        
        UnknownAvatar = 6,
        
        UnknownAvatarForSale = 7,
        
        UnknownTier = 8,
        
        NonSequentialSeasonId = 9,
        
        IncorrectRarityPercentages = 10,
        
        TooManyRarityPercentages = 11,
        
        DuplicatedRarityTier = 12,
        
        MintClosed = 13,
        
        ForgeClosed = 14,
        
        TradeClosed = 15,
        
        OutOfSeason = 16,
        
        MaxOwnershipReached = 17,
        
        Ownership = 18,
        
        IncorrectDna = 19,
        
        IncorrectAvatarId = 20,
        
        MintCooldown = 21,
        
        InsufficientFunds = 22,
        
        MaxComponentsTooLow = 23,
        
        MaxComponentsTooHigh = 24,
        
        MaxVariationsTooLow = 25,
        
        MaxVariationsTooHigh = 26,
        
        InsufficientFreeMints = 27,
        
        TooFewSacrifices = 28,
        
        TooManySacrifices = 29,
        
        LeaderSacrificed = 30,
        
        AvatarInTrade = 31,
    }
    
    /// <summary>
    /// >> 376 - Variant[pallet_ajuna_awesome_avatars.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
