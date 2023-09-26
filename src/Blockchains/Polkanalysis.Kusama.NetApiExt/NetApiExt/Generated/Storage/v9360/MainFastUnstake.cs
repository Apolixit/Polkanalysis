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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9360
{
    public sealed class FastUnstakeStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> HeadParams
        ///  The current "head of the queue" being unstaked.
        /// </summary>
        public static string HeadParams()
        {
            return RequestGenerator.GetStorage("FastUnstake", "Head", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
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
        ///  The current "head of the queue" being unstaked.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.pallet_fast_unstake.types.UnstakeRequest> Head(CancellationToken token)
        {
            string parameters = HeadParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.pallet_fast_unstake.types.UnstakeRequest>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> QueueParams
        ///  The map of all accounts wishing to be unstaked.
        /// 
        ///  Keeps track of `AccountId` wishing to unstake and it's corresponding deposit.
        /// </summary>
        public static string QueueParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("FastUnstake", "Queue", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> QueueDefault
        /// Default value as hex string
        /// </summary>
        public static string QueueDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Queue
        ///  The map of all accounts wishing to be unstaked.
        /// 
        ///  Keeps track of `AccountId` wishing to unstake and it's corresponding deposit.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U128> Queue(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = QueueParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U128>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> CounterForQueueParams
        /// Counter for the related counted storage map
        /// </summary>
        public static string CounterForQueueParams()
        {
            return RequestGenerator.GetStorage("FastUnstake", "CounterForQueue", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> CounterForQueueDefault
        /// Default value as hex string
        /// </summary>
        public static string CounterForQueueDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> CounterForQueue
        /// Counter for the related counted storage map
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> CounterForQueue(CancellationToken token)
        {
            string parameters = CounterForQueueParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ErasToCheckPerBlockParams
        ///  Number of eras to check per block.
        /// 
        ///  If set to 0, this pallet does absolutely nothing.
        /// 
        ///  Based on the amount of weight available at `on_idle`, up to this many eras of a single
        ///  nominator might be checked.
        /// </summary>
        public static string ErasToCheckPerBlockParams()
        {
            return RequestGenerator.GetStorage("FastUnstake", "ErasToCheckPerBlock", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> ErasToCheckPerBlockDefault
        /// Default value as hex string
        /// </summary>
        public static string ErasToCheckPerBlockDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> ErasToCheckPerBlock
        ///  Number of eras to check per block.
        /// 
        ///  If set to 0, this pallet does absolutely nothing.
        /// 
        ///  Based on the amount of weight available at `on_idle`, up to this many eras of a single
        ///  nominator might be checked.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> ErasToCheckPerBlock(CancellationToken token)
        {
            string parameters = ErasToCheckPerBlockParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        public FastUnstakeStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class FastUnstakeConstants
    {
        /// <summary>
        /// >> Deposit
        ///  Deposit to take for unstaking, to make sure we're able to slash the it in order to cover
        ///  the costs of resources on unsuccessful unstake.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Deposit()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x344DD2C2070000000000000000000000");
            return result;
        }
    }

    public enum FastUnstakeErrors
    {
        /// <summary>
        /// >> NotController
        /// The provided Controller account was not found.
        /// 
        /// This means that the given account is not bonded.
        /// </summary>
        NotController,
        /// <summary>
        /// >> AlreadyQueued
        /// The bonded account has already been queued.
        /// </summary>
        AlreadyQueued,
        /// <summary>
        /// >> NotFullyBonded
        /// The bonded account has active unlocking chunks.
        /// </summary>
        NotFullyBonded,
        /// <summary>
        /// >> NotQueued
        /// The provided un-staker is not in the `Queue`.
        /// </summary>
        NotQueued,
        /// <summary>
        /// >> AlreadyHead
        /// The provided un-staker is already in Head, and cannot deregister.
        /// </summary>
        AlreadyHead,
        /// <summary>
        /// >> CallNotAllowed
        /// The call is not allowed at this point because the pallet is not active.
        /// </summary>
        CallNotAllowed
    }
}