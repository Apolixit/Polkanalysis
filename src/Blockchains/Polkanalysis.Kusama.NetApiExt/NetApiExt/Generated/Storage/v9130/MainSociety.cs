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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9130
{
    public sealed class SocietyStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> FounderParams
        ///  The first member.
        /// </summary>
        public static string FounderParams()
        {
            return RequestGenerator.GetStorage("Society", "Founder", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> FounderDefault
        /// Default value as hex string
        /// </summary>
        public static string FounderDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Founder
        ///  The first member.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32> Founder(CancellationToken token)
        {
            string parameters = FounderParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> RulesParams
        ///  A hash of the rules of this society concerning membership. Can only be set once and
        ///  only by the founder.
        /// </summary>
        public static string RulesParams()
        {
            return RequestGenerator.GetStorage("Society", "Rules", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> RulesDefault
        /// Default value as hex string
        /// </summary>
        public static string RulesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Rules
        ///  A hash of the rules of this society concerning membership. Can only be set once and
        ///  only by the founder.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.primitive_types.H256> Rules(CancellationToken token)
        {
            string parameters = RulesParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.primitive_types.H256>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> CandidatesParams
        ///  The current set of candidates; bidders that are attempting to become members.
        /// </summary>
        public static string CandidatesParams()
        {
            return RequestGenerator.GetStorage("Society", "Candidates", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> CandidatesDefault
        /// Default value as hex string
        /// </summary>
        public static string CandidatesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Candidates
        ///  The current set of candidates; bidders that are attempting to become members.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.pallet_society.Bid>> Candidates(CancellationToken token)
        {
            string parameters = CandidatesParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.pallet_society.Bid>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> SuspendedCandidatesParams
        ///  The set of suspended candidates.
        /// </summary>
        public static string SuspendedCandidatesParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Society", "SuspendedCandidates", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> SuspendedCandidatesDefault
        /// Default value as hex string
        /// </summary>
        public static string SuspendedCandidatesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> SuspendedCandidates
        ///  The set of suspended candidates.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U128, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.pallet_society.EnumBidKind>> SuspendedCandidates(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = SuspendedCandidatesParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U128, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.pallet_society.EnumBidKind>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> PotParams
        ///  Amount of our account balance that is specifically for the next round's bid(s).
        /// </summary>
        public static string PotParams()
        {
            return RequestGenerator.GetStorage("Society", "Pot", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> PotDefault
        /// Default value as hex string
        /// </summary>
        public static string PotDefault()
        {
            return "0x00000000000000000000000000000000";
        }

        /// <summary>
        /// >> Pot
        ///  Amount of our account balance that is specifically for the next round's bid(s).
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U128> Pot(CancellationToken token)
        {
            string parameters = PotParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U128>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> HeadParams
        ///  The most primary from the most recently approved members.
        /// </summary>
        public static string HeadParams()
        {
            return RequestGenerator.GetStorage("Society", "Head", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> HeadDefault
        /// Default value as hex string
        /// </summary>
        public static string HeadDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Head
        ///  The most primary from the most recently approved members.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32> Head(CancellationToken token)
        {
            string parameters = HeadParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> MembersParams
        ///  The current set of members, ordered.
        /// </summary>
        public static string MembersParams()
        {
            return RequestGenerator.GetStorage("Society", "Members", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> MembersDefault
        /// Default value as hex string
        /// </summary>
        public static string MembersDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Members
        ///  The current set of members, ordered.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32>> Members(CancellationToken token)
        {
            string parameters = MembersParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> SuspendedMembersParams
        ///  The set of suspended members.
        /// </summary>
        public static string SuspendedMembersParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Society", "SuspendedMembers", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> SuspendedMembersDefault
        /// Default value as hex string
        /// </summary>
        public static string SuspendedMembersDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> SuspendedMembers
        ///  The set of suspended members.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.Bool> SuspendedMembers(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = SuspendedMembersParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.Bool>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> BidsParams
        ///  The current bids, stored ordered by the value of the bid.
        /// </summary>
        public static string BidsParams()
        {
            return RequestGenerator.GetStorage("Society", "Bids", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> BidsDefault
        /// Default value as hex string
        /// </summary>
        public static string BidsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Bids
        ///  The current bids, stored ordered by the value of the bid.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.pallet_society.Bid>> Bids(CancellationToken token)
        {
            string parameters = BidsParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.pallet_society.Bid>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> VouchingParams
        ///  Members currently vouching or banned from vouching again
        /// </summary>
        public static string VouchingParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Society", "Vouching", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> VouchingDefault
        /// Default value as hex string
        /// </summary>
        public static string VouchingDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Vouching
        ///  Members currently vouching or banned from vouching again
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.pallet_society.EnumVouchingStatus> Vouching(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = VouchingParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.pallet_society.EnumVouchingStatus>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> PayoutsParams
        ///  Pending payouts; ordered by block number, with the amount that should be paid out.
        /// </summary>
        public static string PayoutsParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Society", "Payouts", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> PayoutsDefault
        /// Default value as hex string
        /// </summary>
        public static string PayoutsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Payouts
        ///  Pending payouts; ordered by block number, with the amount that should be paid out.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>> Payouts(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = PayoutsParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> StrikesParams
        ///  The ongoing number of losing votes cast by the member.
        /// </summary>
        public static string StrikesParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Society", "Strikes", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> StrikesDefault
        /// Default value as hex string
        /// </summary>
        public static string StrikesDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> Strikes
        ///  The ongoing number of losing votes cast by the member.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> Strikes(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = StrikesParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> VotesParams
        ///  Double map from Candidate -> Voter -> (Maybe) Vote.
        /// </summary>
        public static string VotesParams(Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32> key)
        {
            return RequestGenerator.GetStorage("Society", "Votes", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat, Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, key.Value);
        }

        /// <summary>
        /// >> VotesDefault
        /// Default value as hex string
        /// </summary>
        public static string VotesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Votes
        ///  Double map from Candidate -> Voter -> (Maybe) Vote.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.pallet_society.EnumVote> Votes(Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32> key, CancellationToken token)
        {
            string parameters = VotesParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.pallet_society.EnumVote>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> DefenderParams
        ///  The defending member currently being challenged.
        /// </summary>
        public static string DefenderParams()
        {
            return RequestGenerator.GetStorage("Society", "Defender", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> DefenderDefault
        /// Default value as hex string
        /// </summary>
        public static string DefenderDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Defender
        ///  The defending member currently being challenged.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32> Defender(CancellationToken token)
        {
            string parameters = DefenderParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> DefenderVotesParams
        ///  Votes for the defender.
        /// </summary>
        public static string DefenderVotesParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Society", "DefenderVotes", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> DefenderVotesDefault
        /// Default value as hex string
        /// </summary>
        public static string DefenderVotesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> DefenderVotes
        ///  Votes for the defender.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.pallet_society.EnumVote> DefenderVotes(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = DefenderVotesParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.pallet_society.EnumVote>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> MaxMembersParams
        ///  The max number of members for the society at one time.
        /// </summary>
        public static string MaxMembersParams()
        {
            return RequestGenerator.GetStorage("Society", "MaxMembers", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> MaxMembersDefault
        /// Default value as hex string
        /// </summary>
        public static string MaxMembersDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> MaxMembers
        ///  The max number of members for the society at one time.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> MaxMembers(CancellationToken token)
        {
            string parameters = MaxMembersParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        public SocietyStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class SocietyConstants
    {
        /// <summary>
        /// >> PalletId
        ///  The societies's pallet id
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.frame_support.PalletId PalletId()
        {
            var result = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.frame_support.PalletId();
            result.Create("0x70792F736F636965");
            return result;
        }

        /// <summary>
        /// >> CandidateDeposit
        ///  The minimum amount of a deposit required for a bid to be made.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 CandidateDeposit()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x084CD2C2070000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> WrongSideDeduction
        ///  The amount of the unpaid reward that gets deducted in the case that either a skeptic
        ///  doesn't vote or someone votes in the wrong way.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 WrongSideDeduction()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x68425D8D010000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> MaxStrikes
        ///  The number of times a member may vote the wrong way (or not at all, when they are a
        ///  skeptic) before they become suspended.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxStrikes()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x0A000000");
            return result;
        }

        /// <summary>
        /// >> PeriodSpend
        ///  The amount of incentive paid within each period. Doesn't include VoterTip.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 PeriodSpend()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x90D9120D840100000000000000000000");
            return result;
        }

        /// <summary>
        /// >> RotationPeriod
        ///  The number of blocks between candidate/membership rotation periods.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 RotationPeriod()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0xC0890100");
            return result;
        }

        /// <summary>
        /// >> MaxLockDuration
        ///  The maximum duration of the payout lock.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxLockDuration()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x004EED00");
            return result;
        }

        /// <summary>
        /// >> ChallengePeriod
        ///  The number of blocks between membership challenges.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 ChallengePeriod()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0xC0890100");
            return result;
        }

        /// <summary>
        /// >> MaxCandidateIntake
        ///  The maximum number of candidates that we accept per round.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxCandidateIntake()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x01000000");
            return result;
        }
    }

    public enum SocietyErrors
    {
        /// <summary>
        /// >> BadPosition
        /// An incorrect position was provided.
        /// </summary>
        BadPosition,
        /// <summary>
        /// >> NotMember
        /// User is not a member.
        /// </summary>
        NotMember,
        /// <summary>
        /// >> AlreadyMember
        /// User is already a member.
        /// </summary>
        AlreadyMember,
        /// <summary>
        /// >> Suspended
        /// User is suspended.
        /// </summary>
        Suspended,
        /// <summary>
        /// >> NotSuspended
        /// User is not suspended.
        /// </summary>
        NotSuspended,
        /// <summary>
        /// >> NoPayout
        /// Nothing to payout.
        /// </summary>
        NoPayout,
        /// <summary>
        /// >> AlreadyFounded
        /// Society already founded.
        /// </summary>
        AlreadyFounded,
        /// <summary>
        /// >> InsufficientPot
        /// Not enough in pot to accept candidate.
        /// </summary>
        InsufficientPot,
        /// <summary>
        /// >> AlreadyVouching
        /// Member is already vouching or banned from vouching again.
        /// </summary>
        AlreadyVouching,
        /// <summary>
        /// >> NotVouching
        /// Member is not vouching.
        /// </summary>
        NotVouching,
        /// <summary>
        /// >> Head
        /// Cannot remove the head of the chain.
        /// </summary>
        Head,
        /// <summary>
        /// >> Founder
        /// Cannot remove the founder.
        /// </summary>
        Founder,
        /// <summary>
        /// >> AlreadyBid
        /// User has already made a bid.
        /// </summary>
        AlreadyBid,
        /// <summary>
        /// >> AlreadyCandidate
        /// User is already a candidate.
        /// </summary>
        AlreadyCandidate,
        /// <summary>
        /// >> NotCandidate
        /// User is not a candidate.
        /// </summary>
        NotCandidate,
        /// <summary>
        /// >> MaxMembers
        /// Too many members in the society.
        /// </summary>
        MaxMembers,
        /// <summary>
        /// >> NotFounder
        /// The caller is not the founder.
        /// </summary>
        NotFounder,
        /// <summary>
        /// >> NotHead
        /// The caller is not the head.
        /// </summary>
        NotHead
    }
}