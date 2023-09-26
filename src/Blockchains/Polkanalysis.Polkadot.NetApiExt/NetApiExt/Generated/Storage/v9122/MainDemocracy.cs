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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9122
{
    public sealed class DemocracyStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> PublicPropCountParams
        ///  The number of (public) proposals that have been made so far.
        /// </summary>
        public static string PublicPropCountParams()
        {
            return RequestGenerator.GetStorage("Democracy", "PublicPropCount", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> PublicPropCountDefault
        /// Default value as hex string
        /// </summary>
        public static string PublicPropCountDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> PublicPropCount
        ///  The number of (public) proposals that have been made so far.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> PublicPropCount(CancellationToken token)
        {
            string parameters = PublicPropCountParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> PublicPropsParams
        ///  The public proposals. Unsorted. The second item is the proposal's hash.
        /// </summary>
        public static string PublicPropsParams()
        {
            return RequestGenerator.GetStorage("Democracy", "PublicProps", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> PublicPropsDefault
        /// Default value as hex string
        /// </summary>
        public static string PublicPropsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> PublicProps
        ///  The public proposals. Unsorted. The second item is the proposal's hash.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.primitive_types.H256, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32>>> PublicProps(CancellationToken token)
        {
            string parameters = PublicPropsParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.primitive_types.H256, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32>>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> DepositOfParams
        ///  Those who have locked a deposit.
        /// 
        ///  TWOX-NOTE: Safe, as increasing integer keys are safe.
        /// </summary>
        public static string DepositOfParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("Democracy", "DepositOf", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> DepositOfDefault
        /// Default value as hex string
        /// </summary>
        public static string DepositOfDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> DepositOf
        ///  Those who have locked a deposit.
        /// 
        ///  TWOX-NOTE: Safe, as increasing integer keys are safe.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32>, Substrate.NetApi.Model.Types.Primitive.U128>> DepositOf(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = DepositOfParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32>, Substrate.NetApi.Model.Types.Primitive.U128>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> PreimagesParams
        ///  Map of hashes to the proposal preimage, along with who registered it and their deposit.
        ///  The block number is the block at which it was deposited.
        /// </summary>
        public static string PreimagesParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("Democracy", "Preimages", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Identity }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> PreimagesDefault
        /// Default value as hex string
        /// </summary>
        public static string PreimagesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Preimages
        ///  Map of hashes to the proposal preimage, along with who registered it and their deposit.
        ///  The block number is the block at which it was deposited.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_democracy.EnumPreimageStatus> Preimages(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.primitive_types.H256 key, CancellationToken token)
        {
            string parameters = PreimagesParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_democracy.EnumPreimageStatus>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ReferendumCountParams
        ///  The next free referendum index, aka the number of referenda started so far.
        /// </summary>
        public static string ReferendumCountParams()
        {
            return RequestGenerator.GetStorage("Democracy", "ReferendumCount", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> ReferendumCountDefault
        /// Default value as hex string
        /// </summary>
        public static string ReferendumCountDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> ReferendumCount
        ///  The next free referendum index, aka the number of referenda started so far.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> ReferendumCount(CancellationToken token)
        {
            string parameters = ReferendumCountParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> LowestUnbakedParams
        ///  The lowest referendum index representing an unbaked referendum. Equal to
        ///  `ReferendumCount` if there isn't a unbaked referendum.
        /// </summary>
        public static string LowestUnbakedParams()
        {
            return RequestGenerator.GetStorage("Democracy", "LowestUnbaked", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> LowestUnbakedDefault
        /// Default value as hex string
        /// </summary>
        public static string LowestUnbakedDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> LowestUnbaked
        ///  The lowest referendum index representing an unbaked referendum. Equal to
        ///  `ReferendumCount` if there isn't a unbaked referendum.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> LowestUnbaked(CancellationToken token)
        {
            string parameters = LowestUnbakedParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ReferendumInfoOfParams
        ///  Information concerning any given referendum.
        /// 
        ///  TWOX-NOTE: SAFE as indexes are not under an attacker���s control.
        /// </summary>
        public static string ReferendumInfoOfParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("Democracy", "ReferendumInfoOf", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> ReferendumInfoOfDefault
        /// Default value as hex string
        /// </summary>
        public static string ReferendumInfoOfDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> ReferendumInfoOf
        ///  Information concerning any given referendum.
        /// 
        ///  TWOX-NOTE: SAFE as indexes are not under an attacker���s control.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_democracy.types.EnumReferendumInfo> ReferendumInfoOf(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = ReferendumInfoOfParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_democracy.types.EnumReferendumInfo>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> VotingOfParams
        ///  All votes for a particular voter. We store the balance for the number of votes that we
        ///  have recorded. The second item is the total amount of delegations, that will be added.
        /// 
        ///  TWOX-NOTE: SAFE as `AccountId`s are crypto hashes anyway.
        /// </summary>
        public static string VotingOfParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Democracy", "VotingOf", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> VotingOfDefault
        /// Default value as hex string
        /// </summary>
        public static string VotingOfDefault()
        {
            return "0x000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
        }

        /// <summary>
        /// >> VotingOf
        ///  All votes for a particular voter. We store the balance for the number of votes that we
        ///  have recorded. The second item is the total amount of delegations, that will be added.
        /// 
        ///  TWOX-NOTE: SAFE as `AccountId`s are crypto hashes anyway.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_democracy.vote.EnumVoting> VotingOf(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = VotingOfParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_democracy.vote.EnumVoting>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> LocksParams
        ///  Accounts for which there are locks in action which may be removed at some point in the
        ///  future. The value is the block number at which the lock expires and may be removed.
        /// 
        ///  TWOX-NOTE: OK ��� `AccountId` is a secure hash.
        /// </summary>
        public static string LocksParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Democracy", "Locks", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> LocksDefault
        /// Default value as hex string
        /// </summary>
        public static string LocksDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Locks
        ///  Accounts for which there are locks in action which may be removed at some point in the
        ///  future. The value is the block number at which the lock expires and may be removed.
        /// 
        ///  TWOX-NOTE: OK ��� `AccountId` is a secure hash.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> Locks(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = LocksParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> LastTabledWasExternalParams
        ///  True if the last referendum tabled was submitted externally. False if it was a public
        ///  proposal.
        /// </summary>
        public static string LastTabledWasExternalParams()
        {
            return RequestGenerator.GetStorage("Democracy", "LastTabledWasExternal", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> LastTabledWasExternalDefault
        /// Default value as hex string
        /// </summary>
        public static string LastTabledWasExternalDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> LastTabledWasExternal
        ///  True if the last referendum tabled was submitted externally. False if it was a public
        ///  proposal.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.Bool> LastTabledWasExternal(CancellationToken token)
        {
            string parameters = LastTabledWasExternalParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.Bool>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> NextExternalParams
        ///  The referendum to be tabled whenever it would be valid to table an external proposal.
        ///  This happens when a referendum needs to be tabled and one of two conditions are met:
        ///  - `LastTabledWasExternal` is `false`; or
        ///  - `PublicProps` is empty.
        /// </summary>
        public static string NextExternalParams()
        {
            return RequestGenerator.GetStorage("Democracy", "NextExternal", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> NextExternalDefault
        /// Default value as hex string
        /// </summary>
        public static string NextExternalDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> NextExternal
        ///  The referendum to be tabled whenever it would be valid to table an external proposal.
        ///  This happens when a referendum needs to be tabled and one of two conditions are met:
        ///  - `LastTabledWasExternal` is `false`; or
        ///  - `PublicProps` is empty.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.primitive_types.H256, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_democracy.vote_threshold.EnumVoteThreshold>> NextExternal(CancellationToken token)
        {
            string parameters = NextExternalParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.primitive_types.H256, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_democracy.vote_threshold.EnumVoteThreshold>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> BlacklistParams
        ///  A record of who vetoed what. Maps proposal hash to a possible existent block number
        ///  (until when it may not be resubmitted) and who vetoed it.
        /// </summary>
        public static string BlacklistParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("Democracy", "Blacklist", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Identity }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> BlacklistDefault
        /// Default value as hex string
        /// </summary>
        public static string BlacklistDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Blacklist
        ///  A record of who vetoed what. Maps proposal hash to a possible existent block number
        ///  (until when it may not be resubmitted) and who vetoed it.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32>>> Blacklist(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.primitive_types.H256 key, CancellationToken token)
        {
            string parameters = BlacklistParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32>>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> CancellationsParams
        ///  Record of all proposals that have been subject to emergency cancellation.
        /// </summary>
        public static string CancellationsParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("Democracy", "Cancellations", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Identity }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> CancellationsDefault
        /// Default value as hex string
        /// </summary>
        public static string CancellationsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Cancellations
        ///  Record of all proposals that have been subject to emergency cancellation.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.Bool> Cancellations(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.primitive_types.H256 key, CancellationToken token)
        {
            string parameters = CancellationsParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.Bool>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> StorageVersionParams
        ///  Storage version of the pallet.
        /// 
        ///  New networks start with last version.
        /// </summary>
        public static string StorageVersionParams()
        {
            return RequestGenerator.GetStorage("Democracy", "StorageVersion", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> StorageVersionDefault
        /// Default value as hex string
        /// </summary>
        public static string StorageVersionDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> StorageVersion
        ///  Storage version of the pallet.
        /// 
        ///  New networks start with last version.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_democracy.EnumReleases> StorageVersion(CancellationToken token)
        {
            string parameters = StorageVersionParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_democracy.EnumReleases>(parameters, blockHash, token);
            return result;
        }

        public DemocracyStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class DemocracyConstants
    {
        /// <summary>
        /// >> EnactmentPeriod
        ///  The period between a proposal being approved and enacted.
        /// 
        ///  It should generally be a little more than the unstake period to ensure that
        ///  voting stakers have an opportunity to remove themselves from the system in the case
        ///  where they are on the losing side of a vote.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 EnactmentPeriod()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x00270600");
            return result;
        }

        /// <summary>
        /// >> LaunchPeriod
        ///  How often (in blocks) new public referenda are launched.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 LaunchPeriod()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x00270600");
            return result;
        }

        /// <summary>
        /// >> VotingPeriod
        ///  How often (in blocks) to check for new votes.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 VotingPeriod()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x00270600");
            return result;
        }

        /// <summary>
        /// >> VoteLockingPeriod
        ///  The minimum period of vote locking.
        /// 
        ///  It should be no shorter than enactment period to ensure that in the case of an approval,
        ///  those successful voters are locked into the consequences that their votes entail.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 VoteLockingPeriod()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x00270600");
            return result;
        }

        /// <summary>
        /// >> MinimumDeposit
        ///  The minimum amount to be used as a deposit for a public referendum proposal.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 MinimumDeposit()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x0010A5D4E80000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> InstantAllowed
        ///  Indicator for whether an emergency origin is even allowed to happen. Some chains may
        ///  want to set this permanently to `false`, others may want to condition it on things such
        ///  as an upgrade having happened recently.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.Bool InstantAllowed()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.Bool();
            result.Create("0x01");
            return result;
        }

        /// <summary>
        /// >> FastTrackVotingPeriod
        ///  Minimum voting period allowed for a fast-track referendum.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 FastTrackVotingPeriod()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x08070000");
            return result;
        }

        /// <summary>
        /// >> CooloffPeriod
        ///  Period in blocks where an external proposal may not be re-submitted after being vetoed.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 CooloffPeriod()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0xC0890100");
            return result;
        }

        /// <summary>
        /// >> PreimageByteDeposit
        ///  The amount of balance that must be deposited per byte of preimage stored.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 PreimageByteDeposit()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x00E1F505000000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> MaxVotes
        ///  The maximum number of votes for an account.
        /// 
        ///  Also used to compute weight, an overly big value can
        ///  lead to extrinsic with very big weight: see `delegate` for instance.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxVotes()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x64000000");
            return result;
        }

        /// <summary>
        /// >> MaxProposals
        ///  The maximum number of public proposals that can exist at any time.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxProposals()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x64000000");
            return result;
        }
    }

    public enum DemocracyErrors
    {
        /// <summary>
        /// >> ValueLow
        /// Value too low
        /// </summary>
        ValueLow,
        /// <summary>
        /// >> ProposalMissing
        /// Proposal does not exist
        /// </summary>
        ProposalMissing,
        /// <summary>
        /// >> AlreadyCanceled
        /// Cannot cancel the same proposal twice
        /// </summary>
        AlreadyCanceled,
        /// <summary>
        /// >> DuplicateProposal
        /// Proposal already made
        /// </summary>
        DuplicateProposal,
        /// <summary>
        /// >> ProposalBlacklisted
        /// Proposal still blacklisted
        /// </summary>
        ProposalBlacklisted,
        /// <summary>
        /// >> NotSimpleMajority
        /// Next external proposal not simple majority
        /// </summary>
        NotSimpleMajority,
        /// <summary>
        /// >> InvalidHash
        /// Invalid hash
        /// </summary>
        InvalidHash,
        /// <summary>
        /// >> NoProposal
        /// No external proposal
        /// </summary>
        NoProposal,
        /// <summary>
        /// >> AlreadyVetoed
        /// Identity may not veto a proposal twice
        /// </summary>
        AlreadyVetoed,
        /// <summary>
        /// >> DuplicatePreimage
        /// Preimage already noted
        /// </summary>
        DuplicatePreimage,
        /// <summary>
        /// >> NotImminent
        /// Not imminent
        /// </summary>
        NotImminent,
        /// <summary>
        /// >> TooEarly
        /// Too early
        /// </summary>
        TooEarly,
        /// <summary>
        /// >> Imminent
        /// Imminent
        /// </summary>
        Imminent,
        /// <summary>
        /// >> PreimageMissing
        /// Preimage not found
        /// </summary>
        PreimageMissing,
        /// <summary>
        /// >> ReferendumInvalid
        /// Vote given for invalid referendum
        /// </summary>
        ReferendumInvalid,
        /// <summary>
        /// >> PreimageInvalid
        /// Invalid preimage
        /// </summary>
        PreimageInvalid,
        /// <summary>
        /// >> NoneWaiting
        /// No proposals waiting
        /// </summary>
        NoneWaiting,
        /// <summary>
        /// >> NotVoter
        /// The given account did not vote on the referendum.
        /// </summary>
        NotVoter,
        /// <summary>
        /// >> NoPermission
        /// The actor has no permission to conduct the action.
        /// </summary>
        NoPermission,
        /// <summary>
        /// >> AlreadyDelegating
        /// The account is already delegating.
        /// </summary>
        AlreadyDelegating,
        /// <summary>
        /// >> InsufficientFunds
        /// Too high a balance was provided that the account cannot afford.
        /// </summary>
        InsufficientFunds,
        /// <summary>
        /// >> NotDelegating
        /// The account is not currently delegating.
        /// </summary>
        NotDelegating,
        /// <summary>
        /// >> VotesExist
        /// The account currently has votes attached to it and the operation cannot succeed until
        /// these are removed, either through `unvote` or `reap_vote`.
        /// </summary>
        VotesExist,
        /// <summary>
        /// >> InstantNotAllowed
        /// The instant referendum origin is currently disallowed.
        /// </summary>
        InstantNotAllowed,
        /// <summary>
        /// >> Nonsense
        /// Delegation to oneself makes no sense.
        /// </summary>
        Nonsense,
        /// <summary>
        /// >> WrongUpperBound
        /// Invalid upper bound.
        /// </summary>
        WrongUpperBound,
        /// <summary>
        /// >> MaxVotesReached
        /// Maximum number of votes reached.
        /// </summary>
        MaxVotesReached,
        /// <summary>
        /// >> TooManyProposals
        /// Maximum number of proposals reached.
        /// </summary>
        TooManyProposals
    }
}