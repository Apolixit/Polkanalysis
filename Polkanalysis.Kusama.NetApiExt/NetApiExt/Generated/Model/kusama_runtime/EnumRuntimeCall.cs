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


namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.kusama_runtime
{
    
    
    public enum RuntimeCall
    {
        
        System = 0,
        
        Babe = 1,
        
        Timestamp = 2,
        
        Indices = 3,
        
        Balances = 4,
        
        Authorship = 5,
        
        Staking = 6,
        
        Session = 8,
        
        Grandpa = 10,
        
        ImOnline = 11,
        
        Democracy = 13,
        
        Council = 14,
        
        TechnicalCommittee = 15,
        
        PhragmenElection = 16,
        
        TechnicalMembership = 17,
        
        Treasury = 18,
        
        ConvictionVoting = 20,
        
        Referenda = 21,
        
        FellowshipCollective = 22,
        
        FellowshipReferenda = 23,
        
        Whitelist = 44,
        
        Claims = 19,
        
        Utility = 24,
        
        Identity = 25,
        
        Society = 26,
        
        Recovery = 27,
        
        Vesting = 28,
        
        Scheduler = 29,
        
        Proxy = 30,
        
        Multisig = 31,
        
        Preimage = 32,
        
        Bounties = 35,
        
        ChildBounties = 40,
        
        Tips = 36,
        
        ElectionProviderMultiPhase = 37,
        
        Nis = 38,
        
        NisCounterpartBalances = 45,
        
        VoterList = 39,
        
        NominationPools = 41,
        
        FastUnstake = 42,
        
        Configuration = 51,
        
        ParasShared = 52,
        
        ParaInclusion = 53,
        
        ParaInherent = 54,
        
        Paras = 56,
        
        Initializer = 57,
        
        Dmp = 58,
        
        Ump = 59,
        
        Hrmp = 60,
        
        ParasDisputes = 62,
        
        Registrar = 70,
        
        Slots = 71,
        
        Auctions = 72,
        
        Crowdloan = 73,
        
        XcmPallet = 99,
    }
    
    /// <summary>
    /// >> 72 - Variant[kusama_runtime.RuntimeCall]
    /// </summary>
    public sealed class EnumRuntimeCall : BaseEnumExt<RuntimeCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.frame_system.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_babe.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_timestamp.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_indices.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_balances.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_authorship.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_staking.pallet.pallet.EnumCall, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_session.pallet.EnumCall, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_grandpa.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_im_online.pallet.EnumCall, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_democracy.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_collective.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_collective.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_elections_phragmen.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_membership.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_treasury.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_common.claims.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_conviction_voting.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_referenda.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_ranked_collective.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_referenda.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_utility.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_identity.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_society.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_recovery.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_vesting.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_scheduler.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_proxy.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_multisig.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_preimage.pallet.EnumCall, BaseVoid, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_bounties.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_tips.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_nis.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_bags_list.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_child_bounties.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_nomination_pools.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_fast_unstake.pallet.EnumCall, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_whitelist.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_balances.pallet.EnumCall, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_parachains.configuration.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_parachains.shared.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_parachains.inclusion.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_parachains.paras_inherent.pallet.EnumCall, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_parachains.paras.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_parachains.initializer.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_parachains.dmp.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_parachains.ump.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_parachains.hrmp.pallet.EnumCall, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_parachains.disputes.pallet.EnumCall, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_common.paras_registrar.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_common.slots.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_common.auctions.pallet.EnumCall, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_common.crowdloan.pallet.EnumCall, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_xcm.pallet.EnumCall>
    {
    }
}
