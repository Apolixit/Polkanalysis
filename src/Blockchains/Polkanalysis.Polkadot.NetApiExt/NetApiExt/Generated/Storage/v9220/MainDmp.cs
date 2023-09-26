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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9220
{
    public sealed class DmpStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> DownwardMessageQueuesParams
        ///  The downward messages addressed for a certain para.
        /// </summary>
        public static string DownwardMessageQueuesParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Dmp", "DownwardMessageQueues", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> DownwardMessageQueuesDefault
        /// Default value as hex string
        /// </summary>
        public static string DownwardMessageQueuesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> DownwardMessageQueues
        ///  The downward messages addressed for a certain para.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.polkadot_core_primitives.InboundDownwardMessage>> DownwardMessageQueues(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = DownwardMessageQueuesParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.polkadot_core_primitives.InboundDownwardMessage>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> DownwardMessageQueueHeadsParams
        ///  A mapping that stores the downward message queue MQC head for each para.
        /// 
        ///  Each link in this chain has a form:
        ///  `(prev_head, B, H(M))`, where
        ///  - `prev_head`: is the previous head hash or zero if none.
        ///  - `B`: is the relay-chain block number in which a message was appended.
        ///  - `H(M)`: is the hash of the message being appended.
        /// </summary>
        public static string DownwardMessageQueueHeadsParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Dmp", "DownwardMessageQueueHeads", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> DownwardMessageQueueHeadsDefault
        /// Default value as hex string
        /// </summary>
        public static string DownwardMessageQueueHeadsDefault()
        {
            return "0x0000000000000000000000000000000000000000000000000000000000000000";
        }

        /// <summary>
        /// >> DownwardMessageQueueHeads
        ///  A mapping that stores the downward message queue MQC head for each para.
        /// 
        ///  Each link in this chain has a form:
        ///  `(prev_head, B, H(M))`, where
        ///  - `prev_head`: is the previous head hash or zero if none.
        ///  - `B`: is the relay-chain block number in which a message was appended.
        ///  - `H(M)`: is the hash of the message being appended.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.primitive_types.H256> DownwardMessageQueueHeads(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = DownwardMessageQueueHeadsParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.primitive_types.H256>(parameters, blockHash, token);
            return result;
        }

        public DmpStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class DmpConstants
    {
    }
}