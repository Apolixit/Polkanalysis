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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9220
{
    public sealed class PhragmenElectionStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> MembersParams
        ///  The current elected members.
        /// 
        ///  Invariant: Always sorted based on account id.
        /// </summary>
        public static string MembersParams()
        {
            return RequestGenerator.GetStorage("PhragmenElection", "Members", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
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
        ///  The current elected members.
        /// 
        ///  Invariant: Always sorted based on account id.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.pallet_elections_phragmen.SeatHolder>> Members(CancellationToken token)
        {
            string parameters = MembersParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.pallet_elections_phragmen.SeatHolder>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> RunnersUpParams
        ///  The current reserved runners-up.
        /// 
        ///  Invariant: Always sorted based on rank (worse to best). Upon removal of a member, the
        ///  last (i.e. _best_) runner-up will be replaced.
        /// </summary>
        public static string RunnersUpParams()
        {
            return RequestGenerator.GetStorage("PhragmenElection", "RunnersUp", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> RunnersUpDefault
        /// Default value as hex string
        /// </summary>
        public static string RunnersUpDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> RunnersUp
        ///  The current reserved runners-up.
        /// 
        ///  Invariant: Always sorted based on rank (worse to best). Upon removal of a member, the
        ///  last (i.e. _best_) runner-up will be replaced.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.pallet_elections_phragmen.SeatHolder>> RunnersUp(CancellationToken token)
        {
            string parameters = RunnersUpParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.pallet_elections_phragmen.SeatHolder>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> CandidatesParams
        ///  The present candidate list. A current member or runner-up can never enter this vector
        ///  and is always implicitly assumed to be a candidate.
        /// 
        ///  Second element is the deposit.
        /// 
        ///  Invariant: Always sorted based on account id.
        /// </summary>
        public static string CandidatesParams()
        {
            return RequestGenerator.GetStorage("PhragmenElection", "Candidates", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
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
        ///  The present candidate list. A current member or runner-up can never enter this vector
        ///  and is always implicitly assumed to be a candidate.
        /// 
        ///  Second element is the deposit.
        /// 
        ///  Invariant: Always sorted based on account id.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>> Candidates(CancellationToken token)
        {
            string parameters = CandidatesParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ElectionRoundsParams
        ///  The total number of vote rounds that have happened, excluding the upcoming one.
        /// </summary>
        public static string ElectionRoundsParams()
        {
            return RequestGenerator.GetStorage("PhragmenElection", "ElectionRounds", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> ElectionRoundsDefault
        /// Default value as hex string
        /// </summary>
        public static string ElectionRoundsDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> ElectionRounds
        ///  The total number of vote rounds that have happened, excluding the upcoming one.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> ElectionRounds(CancellationToken token)
        {
            string parameters = ElectionRoundsParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> VotingParams
        ///  Votes and locked stake of a particular voter.
        /// 
        ///  TWOX-NOTE: SAFE as `AccountId` is a crypto hash.
        /// </summary>
        public static string VotingParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("PhragmenElection", "Voting", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> VotingDefault
        /// Default value as hex string
        /// </summary>
        public static string VotingDefault()
        {
            return "0x000000000000000000000000000000000000000000000000000000000000000000";
        }

        /// <summary>
        /// >> Voting
        ///  Votes and locked stake of a particular voter.
        /// 
        ///  TWOX-NOTE: SAFE as `AccountId` is a crypto hash.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.pallet_elections_phragmen.Voter> Voting(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = VotingParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.pallet_elections_phragmen.Voter>(parameters, blockHash, token);
            return result;
        }

        public PhragmenElectionStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class PhragmenElectionConstants
    {
        /// <summary>
        /// >> PalletId
        ///  Identifier for the elections-phragmen pallet's lock
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr8U8 PalletId()
        {
            var result = new Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr8U8();
            result.Create("0x706872656C656374");
            return result;
        }

        /// <summary>
        /// >> CandidacyBond
        ///  How much should be locked up in order to submit one's candidacy.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 CandidacyBond()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x34A1AEC6000000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> VotingBondBase
        ///  Base deposit associated with voting.
        /// 
        ///  This should be sensibly high to economically ensure the pallet cannot be attacked by
        ///  creating a gigantic number of votes.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 VotingBondBase()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x10C55B920F0000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> VotingBondFactor
        ///  The amount of bond that need to be locked for each vote (32 bytes).
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 VotingBondFactor()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x80965B06000000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> DesiredMembers
        ///  Number of members to elect.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 DesiredMembers()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x13000000");
            return result;
        }

        /// <summary>
        /// >> DesiredRunnersUp
        ///  Number of runners_up to keep.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 DesiredRunnersUp()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x13000000");
            return result;
        }

        /// <summary>
        /// >> TermDuration
        ///  How long each seat is kept. This defines the next block number at which an election
        ///  round will happen. If set to zero, no elections are ever triggered and the module will
        ///  be in passive mode.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 TermDuration()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x40380000");
            return result;
        }
    }

    public enum PhragmenElectionErrors
    {
        /// <summary>
        /// >> UnableToVote
        /// Cannot vote when no candidates or members exist.
        /// </summary>
        UnableToVote,
        /// <summary>
        /// >> NoVotes
        /// Must vote for at least one candidate.
        /// </summary>
        NoVotes,
        /// <summary>
        /// >> TooManyVotes
        /// Cannot vote more than candidates.
        /// </summary>
        TooManyVotes,
        /// <summary>
        /// >> MaximumVotesExceeded
        /// Cannot vote more than maximum allowed.
        /// </summary>
        MaximumVotesExceeded,
        /// <summary>
        /// >> LowBalance
        /// Cannot vote with stake less than minimum balance.
        /// </summary>
        LowBalance,
        /// <summary>
        /// >> UnableToPayBond
        /// Voter can not pay voting bond.
        /// </summary>
        UnableToPayBond,
        /// <summary>
        /// >> MustBeVoter
        /// Must be a voter.
        /// </summary>
        MustBeVoter,
        /// <summary>
        /// >> ReportSelf
        /// Cannot report self.
        /// </summary>
        ReportSelf,
        /// <summary>
        /// >> DuplicatedCandidate
        /// Duplicated candidate submission.
        /// </summary>
        DuplicatedCandidate,
        /// <summary>
        /// >> MemberSubmit
        /// Member cannot re-submit candidacy.
        /// </summary>
        MemberSubmit,
        /// <summary>
        /// >> RunnerUpSubmit
        /// Runner cannot re-submit candidacy.
        /// </summary>
        RunnerUpSubmit,
        /// <summary>
        /// >> InsufficientCandidateFunds
        /// Candidate does not have enough funds.
        /// </summary>
        InsufficientCandidateFunds,
        /// <summary>
        /// >> NotMember
        /// Not a member.
        /// </summary>
        NotMember,
        /// <summary>
        /// >> InvalidWitnessData
        /// The provided count of number of candidates is incorrect.
        /// </summary>
        InvalidWitnessData,
        /// <summary>
        /// >> InvalidVoteCount
        /// The provided count of number of votes is incorrect.
        /// </summary>
        InvalidVoteCount,
        /// <summary>
        /// >> InvalidRenouncing
        /// The renouncing origin presented a wrong `Renouncing` parameter.
        /// </summary>
        InvalidRenouncing,
        /// <summary>
        /// >> InvalidReplacement
        /// Prediction regarding replacement after member removal is wrong.
        /// </summary>
        InvalidReplacement
    }
}