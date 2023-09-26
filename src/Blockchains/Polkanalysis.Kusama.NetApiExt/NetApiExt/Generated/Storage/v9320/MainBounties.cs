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
using System.Threading.Tasks;
using Substrate.NetApi.Model.Meta;
using System.Threading;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Extrinsics;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9320
{
    public sealed class BountiesStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> BountyCountParams
        ///  Number of bounty proposals that have been made.
        /// </summary>
        public static string BountyCountParams()
        {
            return RequestGenerator.GetStorage("Bounties", "BountyCount", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> BountyCountDefault
        /// Default value as hex string
        /// </summary>
        public static string BountyCountDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> BountyCount
        ///  Number of bounty proposals that have been made.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> BountyCount(CancellationToken token)
        {
            string parameters = BountyCountParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> BountiesParams
        ///  Bounties that have been made.
        /// </summary>
        public static string BountiesParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("Bounties", "Bounties", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> BountiesDefault
        /// Default value as hex string
        /// </summary>
        public static string BountiesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Bounties
        ///  Bounties that have been made.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.pallet_bounties.Bounty> Bounties(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = BountiesParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.pallet_bounties.Bounty>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> BountyDescriptionsParams
        ///  The description of each bounty.
        /// </summary>
        public static string BountyDescriptionsParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("Bounties", "BountyDescriptions", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> BountyDescriptionsDefault
        /// Default value as hex string
        /// </summary>
        public static string BountyDescriptionsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> BountyDescriptions
        ///  The description of each bounty.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>> BountyDescriptions(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = BountyDescriptionsParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> BountyApprovalsParams
        ///  Bounty indices that have been approved but not yet funded.
        /// </summary>
        public static string BountyApprovalsParams()
        {
            return RequestGenerator.GetStorage("Bounties", "BountyApprovals", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> BountyApprovalsDefault
        /// Default value as hex string
        /// </summary>
        public static string BountyApprovalsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> BountyApprovals
        ///  Bounty indices that have been approved but not yet funded.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U32>> BountyApprovals(CancellationToken token)
        {
            string parameters = BountyApprovalsParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U32>>(parameters, blockHash, token);
            return result;
        }

        public BountiesStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class BountiesConstants
    {
        /// <summary>
        /// >> BountyDepositBase
        ///  The amount held on deposit for placing a bounty proposal.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 BountyDepositBase()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x34A1AEC6000000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> BountyDepositPayoutDelay
        ///  The delay period for which a bounty beneficiary need to wait before claim the payout.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 BountyDepositPayoutDelay()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x00E10000");
            return result;
        }

        /// <summary>
        /// >> BountyUpdatePeriod
        ///  Bounty duration in blocks.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 BountyUpdatePeriod()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x80C61300");
            return result;
        }

        /// <summary>
        /// >> CuratorDepositMultiplier
        ///  The curator deposit is calculated as a percentage of the curator fee.
        /// 
        ///  This deposit has optional upper and lower bounds with `CuratorDepositMax` and
        ///  `CuratorDepositMin`.
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.sp_arithmetic.per_things.Permill CuratorDepositMultiplier()
        {
            var result = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.sp_arithmetic.per_things.Permill();
            result.Create("0x20A10700");
            return result;
        }

        /// <summary>
        /// >> CuratorDepositMax
        ///  Maximum amount of funds that should be placed in a deposit for making a proposal.
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U128> CuratorDepositMax()
        {
            var result = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U128>();
            result.Create("0x01042669E1030000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> CuratorDepositMin
        ///  Minimum amount of funds that should be placed in a deposit for making a proposal.
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U128> CuratorDepositMin()
        {
            var result = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U128>();
            result.Create("0x015243DE13000000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> BountyValueMinimum
        ///  Minimum value for a bounty.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 BountyValueMinimum()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x68425D8D010000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> DataDepositPerByte
        ///  The amount held on deposit per byte within the tip report reason or bounty description.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 DataDepositPerByte()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x55A0FC01000000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> MaximumReasonLength
        ///  Maximum acceptable reason length.
        /// 
        ///  Benchmarks depend on this value, be sure to update weights file when changing this value
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaximumReasonLength()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x00400000");
            return result;
        }
    }

    public enum BountiesErrors
    {
        /// <summary>
        /// >> InsufficientProposersBalance
        /// Proposer's balance is too low.
        /// </summary>
        InsufficientProposersBalance,
        /// <summary>
        /// >> InvalidIndex
        /// No proposal or bounty at that index.
        /// </summary>
        InvalidIndex,
        /// <summary>
        /// >> ReasonTooBig
        /// The reason given is just too big.
        /// </summary>
        ReasonTooBig,
        /// <summary>
        /// >> UnexpectedStatus
        /// The bounty status is unexpected.
        /// </summary>
        UnexpectedStatus,
        /// <summary>
        /// >> RequireCurator
        /// Require bounty curator.
        /// </summary>
        RequireCurator,
        /// <summary>
        /// >> InvalidValue
        /// Invalid bounty value.
        /// </summary>
        InvalidValue,
        /// <summary>
        /// >> InvalidFee
        /// Invalid bounty fee.
        /// </summary>
        InvalidFee,
        /// <summary>
        /// >> PendingPayout
        /// A bounty payout is pending.
        /// To cancel the bounty, you must unassign and slash the curator.
        /// </summary>
        PendingPayout,
        /// <summary>
        /// >> Premature
        /// The bounties cannot be claimed/closed because it's still in the countdown period.
        /// </summary>
        Premature,
        /// <summary>
        /// >> HasActiveChildBounty
        /// The bounty cannot be closed because it has active child bounties.
        /// </summary>
        HasActiveChildBounty,
        /// <summary>
        /// >> TooManyQueued
        /// Too many approvals are already queued.
        /// </summary>
        TooManyQueued
    }
}