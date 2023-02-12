﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.System
{
    public class EnumRuntimeEvent
    {
        // TODO
        //  method: CandidateIncluded
        //section: paraInclusion
        //index: 0x3501
        //data:[]

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
        public sealed class EnumRuntimeEvent : BaseEnumExt<RuntimeEvent, Substats.Polkadot.NetApiExt.Generated.Model.frame_system.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.pallet_scheduler.pallet.EnumEvent, BaseVoid, BaseVoid, Substats.Polkadot.NetApiExt.Generated.Model.pallet_indices.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.pallet_balances.pallet.EnumEvent, BaseVoid, Substats.Polkadot.NetApiExt.Generated.Model.pallet_staking.pallet.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.pallet_offences.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.pallet_session.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.pallet_preimage.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.pallet_grandpa.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.pallet_im_online.pallet.EnumEvent, BaseVoid, Substats.Polkadot.NetApiExt.Generated.Model.pallet_democracy.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.pallet_collective.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.pallet_collective.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.pallet_elections_phragmen.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.pallet_membership.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.pallet_treasury.pallet.EnumEvent, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.claims.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.pallet_vesting.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.pallet_utility.pallet.EnumEvent, BaseVoid, Substats.Polkadot.NetApiExt.Generated.Model.pallet_identity.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.pallet_proxy.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.pallet_multisig.pallet.EnumEvent, BaseVoid, Substats.Polkadot.NetApiExt.Generated.Model.pallet_transaction_payment.pallet.EnumEvent, BaseVoid, Substats.Polkadot.NetApiExt.Generated.Model.pallet_bounties.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.pallet_tips.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.pallet_election_provider_multi_phase.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.pallet_bags_list.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.pallet_child_bounties.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.pallet_fast_unstake.pallet.EnumEvent, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.inclusion.pallet.EnumEvent, BaseVoid, BaseVoid, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.paras.pallet.EnumEvent, BaseVoid, BaseVoid, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.ump.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.hrmp.pallet.EnumEvent, BaseVoid, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.disputes.pallet.EnumEvent, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.paras_registrar.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.slots.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.auctions.pallet.EnumEvent, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.crowdloan.pallet.EnumEvent, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Substats.Polkadot.NetApiExt.Generated.Model.pallet_xcm.pallet.EnumEvent>
        {
        }

    }
}
