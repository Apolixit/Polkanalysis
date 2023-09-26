//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.polkadot_runtime
{
    public enum Call
    {
        System = 0,
        Scheduler = 1,
        Preimage = 10,
        Babe = 2,
        Timestamp = 3,
        Indices = 4,
        Balances = 5,
        Authorship = 6,
        Staking = 7,
        Session = 9,
        Grandpa = 11,
        ImOnline = 12,
        Democracy = 14,
        Council = 15,
        TechnicalCommittee = 16,
        PhragmenElection = 17,
        TechnicalMembership = 18,
        Treasury = 19,
        Claims = 24,
        Vesting = 25,
        Utility = 26,
        Identity = 28,
        Proxy = 29,
        Multisig = 30,
        Bounties = 34,
        ChildBounties = 38,
        Tips = 35,
        ElectionProviderMultiPhase = 36,
        VoterList = 37,
        NominationPools = 39,
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
        XcmPallet = 99
    }

    /// <summary>
    /// >> 9665 - Variant[polkadot_runtime.Call]
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.frame_system.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_scheduler.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_babe.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_timestamp.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_indices.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_balances.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_authorship.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_staking.pallet.pallet.EnumCall, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_session.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_preimage.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_grandpa.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_im_online.pallet.EnumCall, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_democracy.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_collective.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_collective.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_elections_phragmen.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_membership.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_treasury.pallet.EnumCall, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.polkadot_runtime_common.claims.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_vesting.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_utility.pallet.EnumCall, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_identity.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_proxy.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_multisig.pallet.EnumCall, BaseVoid, BaseVoid, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_bounties.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_tips.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_election_provider_multi_phase.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_bags_list.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_child_bounties.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_nomination_pools.pallet.EnumCall, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.polkadot_runtime_parachains.configuration.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.polkadot_runtime_parachains.shared.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.polkadot_runtime_parachains.inclusion.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.polkadot_runtime_parachains.paras_inherent.pallet.EnumCall, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.polkadot_runtime_parachains.paras.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.polkadot_runtime_parachains.initializer.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.polkadot_runtime_parachains.dmp.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.polkadot_runtime_parachains.ump.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.polkadot_runtime_parachains.hrmp.pallet.EnumCall, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.polkadot_runtime_parachains.disputes.pallet.EnumCall, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.polkadot_runtime_common.paras_registrar.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.polkadot_runtime_common.slots.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.polkadot_runtime_common.auctions.pallet.EnumCall, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.polkadot_runtime_common.crowdloan.pallet.EnumCall, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_xcm.pallet.EnumCall>
    {
    }
}