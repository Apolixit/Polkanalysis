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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.kusama_runtime
{
    public enum RuntimeEvent
    {
        System = 0,
        Indices = 3,
        Balances = 4,
        TransactionPayment = 33,
        Staking = 6,
        Offences = 7,
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
        ParaInclusion = 53,
        Paras = 56,
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
    /// >> 1746 - Variant[kusama_runtime.RuntimeEvent]
    /// </summary>
    public sealed class EnumRuntimeEvent : BaseEnumExt<RuntimeEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.frame_system.pallet.EnumEvent, BaseVoid, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_indices.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_balances.pallet.EnumEvent, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_staking.pallet.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_offences.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_session.pallet.EnumEvent, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_grandpa.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_im_online.pallet.EnumEvent, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_democracy.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_collective.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_collective.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_elections_phragmen.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_membership.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_treasury.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_runtime_common.claims.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_conviction_voting.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_referenda.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_ranked_collective.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_referenda.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_utility.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_identity.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_society.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_recovery.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_vesting.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_scheduler.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_proxy.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_multisig.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_preimage.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_transaction_payment.pallet.EnumEvent, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_bounties.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_tips.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_election_provider_multi_phase.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_nis.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_bags_list.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_child_bounties.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_nomination_pools.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_fast_unstake.pallet.EnumEvent, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_whitelist.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_balances.pallet.EnumEvent, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_runtime_parachains.inclusion.pallet.EnumEvent, BaseVoid, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_runtime_parachains.paras.pallet.EnumEvent, BaseVoid, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_runtime_parachains.ump.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_runtime_parachains.hrmp.pallet.EnumEvent, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_runtime_parachains.disputes.pallet.EnumEvent, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_runtime_common.paras_registrar.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_runtime_common.slots.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_runtime_common.auctions.pallet.EnumEvent, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_runtime_common.crowdloan.pallet.EnumEvent, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_xcm.pallet.EnumEvent>
    {
    }
}