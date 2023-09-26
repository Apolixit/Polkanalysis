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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9250
{
    public sealed class TreasuryStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> ProposalCountParams
        ///  Number of proposals that have been made.
        /// </summary>
        public static string ProposalCountParams()
        {
            return RequestGenerator.GetStorage("Treasury", "ProposalCount", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> ProposalCountDefault
        /// Default value as hex string
        /// </summary>
        public static string ProposalCountDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> ProposalCount
        ///  Number of proposals that have been made.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> ProposalCount(CancellationToken token)
        {
            string parameters = ProposalCountParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ProposalsParams
        ///  Proposals that have been made.
        /// </summary>
        public static string ProposalsParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("Treasury", "Proposals", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> ProposalsDefault
        /// Default value as hex string
        /// </summary>
        public static string ProposalsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Proposals
        ///  Proposals that have been made.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.pallet_treasury.Proposal> Proposals(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = ProposalsParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.pallet_treasury.Proposal>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ApprovalsParams
        ///  Proposal indices that have been approved but not yet awarded.
        /// </summary>
        public static string ApprovalsParams()
        {
            return RequestGenerator.GetStorage("Treasury", "Approvals", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> ApprovalsDefault
        /// Default value as hex string
        /// </summary>
        public static string ApprovalsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Approvals
        ///  Proposal indices that have been approved but not yet awarded.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U32>> Approvals(CancellationToken token)
        {
            string parameters = ApprovalsParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U32>>(parameters, blockHash, token);
            return result;
        }

        public TreasuryStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class TreasuryConstants
    {
        /// <summary>
        /// >> ProposalBond
        ///  Fraction of a proposal's value that should be bonded in order to place the proposal.
        ///  An accepted proposal gets these back. A rejected proposal does not.
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.sp_arithmetic.per_things.Permill ProposalBond()
        {
            var result = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.sp_arithmetic.per_things.Permill();
            result.Create("0x50C30000");
            return result;
        }

        /// <summary>
        /// >> ProposalBondMinimum
        ///  Minimum amount of funds that should be placed in a deposit for making a proposal.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 ProposalBondMinimum()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x0010A5D4E80000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> ProposalBondMaximum
        ///  Maximum amount of funds that should be placed in a deposit for making a proposal.
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U128> ProposalBondMaximum()
        {
            var result = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U128>();
            result.Create("0x01005039278C0400000000000000000000");
            return result;
        }

        /// <summary>
        /// >> SpendPeriod
        ///  Period between successive spends.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 SpendPeriod()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x00460500");
            return result;
        }

        /// <summary>
        /// >> Burn
        ///  Percentage of spare funds (if any) that are burnt per spend period.
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.sp_arithmetic.per_things.Permill Burn()
        {
            var result = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.sp_arithmetic.per_things.Permill();
            result.Create("0x10270000");
            return result;
        }

        /// <summary>
        /// >> PalletId
        ///  The treasury's pallet id, used for deriving its sovereign account ID.
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.frame_support.PalletId PalletId()
        {
            var result = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.frame_support.PalletId();
            result.Create("0x70792F7472737279");
            return result;
        }

        /// <summary>
        /// >> MaxApprovals
        ///  The maximum number of approvals that can wait in the spending queue.
        /// 
        ///  NOTE: This parameter is also used within the Bounties Pallet extension if enabled.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxApprovals()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x64000000");
            return result;
        }
    }

    public enum TreasuryErrors
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
        /// >> TooManyApprovals
        /// Too many approvals in the queue.
        /// </summary>
        TooManyApprovals,
        /// <summary>
        /// >> InsufficientPermission
        /// The spend origin is valid but the amount it is allowed to spend is lower than the
        /// amount to be spent.
        /// </summary>
        InsufficientPermission,
        /// <summary>
        /// >> ProposalNotApproved
        /// Proposal has not been approved.
        /// </summary>
        ProposalNotApproved
    }
}