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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9350
{
    public sealed class ParaInherentStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> IncludedParams
        ///  Whether the paras inherent was included within this block.
        /// 
        ///  The `Option<()>` is effectively a `bool`, but it never hits storage in the `None` variant
        ///  due to the guarantees of FRAME's storage APIs.
        /// 
        ///  If this is `None` at the end of the block, we panic and render the block invalid.
        /// </summary>
        public static string IncludedParams()
        {
            return RequestGenerator.GetStorage("ParaInherent", "Included", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> IncludedDefault
        /// Default value as hex string
        /// </summary>
        public static string IncludedDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Included
        ///  Whether the paras inherent was included within this block.
        /// 
        ///  The `Option<()>` is effectively a `bool`, but it never hits storage in the `None` variant
        ///  due to the guarantees of FRAME's storage APIs.
        /// 
        ///  If this is `None` at the end of the block, we panic and render the block invalid.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple> Included(CancellationToken token)
        {
            string parameters = IncludedParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> OnChainVotesParams
        ///  Scraped on chain data for extracting resolved disputes as well as backing votes.
        /// </summary>
        public static string OnChainVotesParams()
        {
            return RequestGenerator.GetStorage("ParaInherent", "OnChainVotes", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> OnChainVotesDefault
        /// Default value as hex string
        /// </summary>
        public static string OnChainVotesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> OnChainVotes
        ///  Scraped on chain data for extracting resolved disputes as well as backing votes.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.polkadot_primitives.v2.ScrapedOnChainVotes> OnChainVotes(CancellationToken token)
        {
            string parameters = OnChainVotesParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.polkadot_primitives.v2.ScrapedOnChainVotes>(parameters, blockHash, token);
            return result;
        }

        public ParaInherentStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class ParaInherentConstants
    {
    }

    public enum ParaInherentErrors
    {
        /// <summary>
        /// >> TooManyInclusionInherents
        /// Inclusion inherent called more than once per block.
        /// </summary>
        TooManyInclusionInherents,
        /// <summary>
        /// >> InvalidParentHeader
        /// The hash of the submitted parent header doesn't correspond to the saved block hash of
        /// the parent.
        /// </summary>
        InvalidParentHeader,
        /// <summary>
        /// >> CandidateConcludedInvalid
        /// Disputed candidate that was concluded invalid.
        /// </summary>
        CandidateConcludedInvalid,
        /// <summary>
        /// >> InherentOverweight
        /// The data given to the inherent will result in an overweight block.
        /// </summary>
        InherentOverweight,
        /// <summary>
        /// >> DisputeStatementsUnsortedOrDuplicates
        /// The ordering of dispute statements was invalid.
        /// </summary>
        DisputeStatementsUnsortedOrDuplicates,
        /// <summary>
        /// >> DisputeInvalid
        /// A dispute statement was invalid.
        /// </summary>
        DisputeInvalid
    }
}