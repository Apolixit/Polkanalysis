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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_runtime
{
    public enum Event
    {
        System = 0,
        Scheduler = 1,
        Preimage = 10,
        Indices = 4,
        Balances = 5,
        Staking = 7,
        Offences = 8,
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
        Tips = 35,
        ElectionProviderMultiPhase = 36,
        BagsList = 37,
        ParaInclusion = 53,
        Paras = 56,
        Ump = 59,
        Hrmp = 60,
        Registrar = 70,
        Slots = 71,
        Auctions = 72,
        Crowdloan = 73,
        XcmPallet = 99
    }

    /// <summary>
    /// >> 2509 - Variant[polkadot_runtime.Event]
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.frame_system.pallet.EnumEvent, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_scheduler.pallet.EnumEvent, BaseVoid, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_indices.pallet.EnumEvent, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_balances.pallet.EnumEvent, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_staking.pallet.pallet.EnumEvent, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_offences.pallet.EnumEvent, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_session.pallet.EnumEvent, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_preimage.pallet.EnumEvent, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_grandpa.pallet.EnumEvent, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_im_online.pallet.EnumEvent, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_democracy.pallet.EnumEvent, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_collective.pallet.EnumEvent, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_collective.pallet.EnumEvent, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_elections_phragmen.pallet.EnumEvent, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_membership.pallet.EnumEvent, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_treasury.pallet.EnumEvent, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_runtime_common.claims.pallet.EnumEvent, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_vesting.pallet.EnumEvent, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_utility.pallet.EnumEvent, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_identity.pallet.EnumEvent, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_proxy.pallet.EnumEvent, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_multisig.pallet.EnumEvent, BaseVoid, BaseVoid, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_bounties.pallet.EnumEvent, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_tips.pallet.EnumEvent, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_election_provider_multi_phase.pallet.EnumEvent, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_bags_list.pallet.EnumEvent, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_runtime_parachains.inclusion.pallet.EnumEvent, BaseVoid, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_runtime_parachains.paras.pallet.EnumEvent, BaseVoid, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_runtime_parachains.ump.pallet.EnumEvent, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_runtime_parachains.hrmp.pallet.EnumEvent, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_runtime_common.paras_registrar.pallet.EnumEvent, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_runtime_common.slots.pallet.EnumEvent, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_runtime_common.auctions.pallet.EnumEvent, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_runtime_common.crowdloan.pallet.EnumEvent, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_xcm.pallet.EnumEvent>
    {
    }
}