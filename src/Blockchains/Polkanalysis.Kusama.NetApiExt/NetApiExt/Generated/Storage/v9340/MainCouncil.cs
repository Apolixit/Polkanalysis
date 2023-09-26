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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9340
{
    public sealed class CouncilStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> ProposalsParams
        ///  The hashes of the active proposals.
        /// </summary>
        public static string ProposalsParams()
        {
            return RequestGenerator.GetStorage("Council", "Proposals", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
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
        ///  The hashes of the active proposals.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.primitive_types.H256>> Proposals(CancellationToken token)
        {
            string parameters = ProposalsParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.primitive_types.H256>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ProposalOfParams
        ///  Actual proposal for a given hash, if it's current.
        /// </summary>
        public static string ProposalOfParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("Council", "ProposalOf", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Identity }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> ProposalOfDefault
        /// Default value as hex string
        /// </summary>
        public static string ProposalOfDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> ProposalOf
        ///  Actual proposal for a given hash, if it's current.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.kusama_runtime.EnumRuntimeCall> ProposalOf(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.primitive_types.H256 key, CancellationToken token)
        {
            string parameters = ProposalOfParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.kusama_runtime.EnumRuntimeCall>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> VotingParams
        ///  Votes on a given proposal, if it is ongoing.
        /// </summary>
        public static string VotingParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("Council", "Voting", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Identity }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> VotingDefault
        /// Default value as hex string
        /// </summary>
        public static string VotingDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Voting
        ///  Votes on a given proposal, if it is ongoing.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.pallet_collective.Votes> Voting(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.primitive_types.H256 key, CancellationToken token)
        {
            string parameters = VotingParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.pallet_collective.Votes>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ProposalCountParams
        ///  Proposals so far.
        /// </summary>
        public static string ProposalCountParams()
        {
            return RequestGenerator.GetStorage("Council", "ProposalCount", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
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
        ///  Proposals so far.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> ProposalCount(CancellationToken token)
        {
            string parameters = ProposalCountParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> MembersParams
        ///  The current members of the collective. This is stored sorted (just by value).
        /// </summary>
        public static string MembersParams()
        {
            return RequestGenerator.GetStorage("Council", "Members", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
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
        ///  The current members of the collective. This is stored sorted (just by value).
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.sp_core.crypto.AccountId32>> Members(CancellationToken token)
        {
            string parameters = MembersParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.sp_core.crypto.AccountId32>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> PrimeParams
        ///  The prime member that helps determine the default vote behavior in case of absentations.
        /// </summary>
        public static string PrimeParams()
        {
            return RequestGenerator.GetStorage("Council", "Prime", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> PrimeDefault
        /// Default value as hex string
        /// </summary>
        public static string PrimeDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Prime
        ///  The prime member that helps determine the default vote behavior in case of absentations.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.sp_core.crypto.AccountId32> Prime(CancellationToken token)
        {
            string parameters = PrimeParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.sp_core.crypto.AccountId32>(parameters, blockHash, token);
            return result;
        }

        public CouncilStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class CouncilConstants
    {
    }

    public enum CouncilErrors
    {
        /// <summary>
        /// >> NotMember
        /// Account is not a member
        /// </summary>
        NotMember,
        /// <summary>
        /// >> DuplicateProposal
        /// Duplicate proposals not allowed
        /// </summary>
        DuplicateProposal,
        /// <summary>
        /// >> ProposalMissing
        /// Proposal must exist
        /// </summary>
        ProposalMissing,
        /// <summary>
        /// >> WrongIndex
        /// Mismatched index
        /// </summary>
        WrongIndex,
        /// <summary>
        /// >> DuplicateVote
        /// Duplicate vote ignored
        /// </summary>
        DuplicateVote,
        /// <summary>
        /// >> AlreadyInitialized
        /// Members are already initialized!
        /// </summary>
        AlreadyInitialized,
        /// <summary>
        /// >> TooEarly
        /// The close call was made too early, before the end of the voting.
        /// </summary>
        TooEarly,
        /// <summary>
        /// >> TooManyProposals
        /// There can only be a maximum of `MaxProposals` active proposals.
        /// </summary>
        TooManyProposals,
        /// <summary>
        /// >> WrongProposalWeight
        /// The given weight bound for the proposal was too low.
        /// </summary>
        WrongProposalWeight,
        /// <summary>
        /// >> WrongProposalLength
        /// The given length bound for the proposal was too low.
        /// </summary>
        WrongProposalLength
    }
}