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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9170
{
    public sealed class UtilityStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        public UtilityStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class UtilityConstants
    {
        /// <summary>
        /// >> batched_calls_limit
        ///  The limit on the number of batched calls.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 batched_calls_limit()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0xAA2A0000");
            return result;
        }
    }

    public enum UtilityErrors
    {
        /// <summary>
        /// >> TooManyCalls
        /// Too many calls batched.
        /// </summary>
        TooManyCalls
    }
}