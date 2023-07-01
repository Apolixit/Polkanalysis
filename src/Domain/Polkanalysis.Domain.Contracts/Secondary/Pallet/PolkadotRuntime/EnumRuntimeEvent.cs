using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.SystemCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntime
{
    public enum RuntimeEvent
    {

        System = 0,

        Scheduler = 1,

        Preimage = 10,

        Indices = 4,

        Balances = 5,

        TransactionPayment = 32,

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

        ChildBounties = 38,

        Tips = 35,

        ElectionProviderMultiPhase = 36,

        VoterList = 37,

        NominationPools = 39,

        FastUnstake = 40,

        ParaInclusion = 53,

        Paras = 56,

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
    /// >> 19 - Variant[polkadot_runtime.RuntimeEvent]
    /// </summary>
    public sealed class EnumRuntimeEvent : BaseEnumExt<RuntimeEvent,
        EnumEvent,
        Scheduler.Enums.EnumEvent,
        BaseVoid,
        BaseVoid,
        Indices.Enums.EnumEvent,
        Balances.Enums.EnumEvent,
        BaseVoid,
        Staking.Enums.EnumEvent,
        Offences.Enums.EnumEvent,
        Session.Enums.EnumEvent,
        PreImage.Enums.EnumEvent,
        GrandPa.Enums.EnumEvent,
        EnumEvent,
        BaseVoid,
        Democracy.Enums.EnumEvent,
        Collective.Enums.EnumEvent,
        Collective.Enums.EnumEvent,
        ElectionsPhragmen.Enums.EnumEvent,
        Membership.Enums.EnumEvent,
        Treasury.Enums.EnumEvent,
        BaseVoid,
        BaseVoid,
        BaseVoid,
        BaseVoid,
        PolkadotRuntimeCommon.Enums.EnumEvent,
        Vesting.Enums.EnumEvent,
        Utility.Enums.EnumEvent,
        BaseVoid,
        Identity.Enums.EnumEvent,
        Proxy.Enums.EnumEvent,
        Multisig.Enums.EnumEvent,
        BaseVoid,
        TransactionPayment.Enums.EnumEvent,
        BaseVoid,
        Bounties.Enums.EnumEvent,
        Tips.Enums.EnumEvent,
        ElectionProviderMultiPhase.Enums.EnumEvent,
        BagsList.Enums.EnumEvent,
        ChildBounties.Enums.EnumEvent,
        NominationPools.Enums.EnumEvent,
        FastUnstake.Enums.EnumEvent,
        BaseVoid,
        BaseVoid,
        BaseVoid,
        BaseVoid,
        BaseVoid,
        BaseVoid,
        BaseVoid,
        BaseVoid,
        BaseVoid,
        BaseVoid,
        BaseVoid,
        BaseVoid,
        PolkadotRuntimeParachain.Inclusion.Enums.EnumEvent,
        BaseVoid,
        BaseVoid,
        PolkadotRuntimeParachain.Paras.Enums.EnumEvent,
        BaseVoid,
        BaseVoid,
        PolkadotRuntimeParachain.Ump.Enums.EnumEvent,
        PolkadotRuntimeParachain.Hrmp.Enums.EnumEvent,
        BaseVoid,
        PolkadotRuntimeParachain.Disputes.Enums.EnumEvent,
        BaseVoid,
        BaseVoid,
        BaseVoid,
        BaseVoid,
        BaseVoid,
        BaseVoid,
        BaseVoid,
        PolkadotRuntimeCommon.ParasRegistar.Enums.EnumEvent,
        PolkadotRuntimeCommon.Slots.Enums.EnumEvent,
        PolkadotRuntimeCommon.Auctions.Enums.EnumEvent,
        PolkadotRuntimeCommon.Crowdloan.Enums.EnumEvent,
        BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid,
        Xcm.Enums.EnumEvent>
    {
    }
}
