﻿using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime
{
    public enum RuntimeEvent
    {
        System = 0,
        Scheduler = 1,
        Preimage = 2,
        Indices = 3,
        Balances = 4,
        TransactionPayment = 5,
        Staking = 6,
        Offences = 7,
        Session = 8,
        Grandpa = 9,
        ImOnline = 10,
        Democracy = 11,
        Council = 12,
        TechnicalCommittee = 13,
        PhragmenElection = 14,
        TechnicalMembership = 15,
        Treasury = 16,
        Claims = 17,
        Vesting = 18,
        Utility = 19,
        Identity = 20,
        Proxy = 21,
        Multisig = 22,
        Bounties = 23,
        ChildBounties = 24,
        Tips = 25,
        ElectionProviderMultiPhase = 26,
        VoterList = 27,
        NominationPools = 28,
        FastUnstake = 29,
        ParaInclusion = 30,
        Paras = 31,
        Ump = 32,
        Hrmp = 33,
        ParasDisputes = 34,
        Registrar = 35,
        Slots = 36,
        Auctions = 37,
        Crowdloan = 38,
        XcmPallet = 39,
        ConvictionVoting = 40,
        Referenda = 41,
        Whitelist = 42,
        MessageQueue = 43
    }

    /// <summary>
    /// >> 19 - Variant[polkadot_runtime.RuntimeEvent]
    /// </summary>
    public sealed class EnumRuntimeEvent : BaseEnumExt<RuntimeEvent,
        System.Enums.EnumEvent,
        Scheduler.Enums.EnumEvent,
        PreImage.Enums.EnumEvent,
        Indices.Enums.EnumEvent,
        Balances.Enums.EnumEvent,
        TransactionPayment.Enums.EnumEvent,
        Staking.Enums.EnumEvent,
        Offences.Enums.EnumEvent,
        Session.Enums.EnumEvent,
        GrandPa.Enums.EnumEvent,
        ImOnline.Enums.EnumEvent,
        Democracy.Enums.EnumEvent,
        Collective.Enums.EnumEvent, // Council
        Collective.Enums.EnumEvent, // TechnicalCommittee
        ElectionsPhragmen.Enums.EnumEvent,
        Membership.Enums.EnumEvent,
        Treasury.Enums.EnumEvent,
        PolkadotRuntimeCommon.Claims.Enum.EnumEvent,
        Vesting.Enums.EnumEvent,
        Utility.Enums.EnumEvent,
        Identity.Enums.EnumEvent,
        Proxy.Enums.EnumEvent,
        Multisig.Enums.EnumEvent,
        Bounties.Enums.EnumEvent,
        ChildBounties.Enums.EnumEvent,
        Tips.Enums.EnumEvent,
        ElectionProviderMultiPhase.Enums.EnumEvent,
        BagsList.Enums.EnumEvent, // VoterList
        NominationPools.Enums.EnumEvent,
        FastUnstake.Enums.EnumEvent,
        PolkadotRuntimeParachain.Inclusion.Enums.EnumEvent,
        PolkadotRuntimeParachain.Paras.Enums.EnumEvent,
        PolkadotRuntimeParachain.Ump.Enums.EnumEvent,
        PolkadotRuntimeParachain.Hrmp.Enums.EnumEvent,
        PolkadotRuntimeParachain.Disputes.Enums.EnumEvent,
        PolkadotRuntimeCommon.ParasRegistar.Enums.EnumEvent,
        PolkadotRuntimeCommon.Slots.Enums.EnumEvent,
        PolkadotRuntimeCommon.Auctions.Enums.EnumEvent,
        PolkadotRuntimeCommon.Crowdloan.Enums.EnumEvent,
        Xcm.Enums.EnumEvent,
        ConvictionVoting.Enums.EnumEvent,
        Referenda.Enums.EnumEvent,
        WhiteList.Enums.EnumEvent,
        MessageQueue.Enums.EnumEvent
        >
    {
    }
}
