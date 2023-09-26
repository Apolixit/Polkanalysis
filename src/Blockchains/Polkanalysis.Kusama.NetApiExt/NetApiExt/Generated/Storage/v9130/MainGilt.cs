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
    public sealed class GiltStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> QueueTotalsParams
        ///  The totals of items and balances within each queue. Saves a lot of storage reads in the
        ///  case of sparsely packed queues.
        /// 
        ///  The vector is indexed by duration in `Period`s, offset by one, so information on the queue
        ///  whose duration is one `Period` would be storage `0`.
        /// </summary>
        public static string QueueTotalsParams()
        {
            return RequestGenerator.GetStorage("Gilt", "QueueTotals", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> QueueTotalsDefault
        /// Default value as hex string
        /// </summary>
        public static string QueueTotalsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> QueueTotals
        ///  The totals of items and balances within each queue. Saves a lot of storage reads in the
        ///  case of sparsely packed queues.
        /// 
        ///  The vector is indexed by duration in `Period`s, offset by one, so information on the queue
        ///  whose duration is one `Period` would be storage `0`.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>> QueueTotals(CancellationToken token)
        {
            string parameters = QueueTotalsParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> QueuesParams
        ///  The queues of bids ready to become gilts. Indexed by duration (in `Period`s).
        /// </summary>
        public static string QueuesParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("Gilt", "Queues", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> QueuesDefault
        /// Default value as hex string
        /// </summary>
        public static string QueuesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Queues
        ///  The queues of bids ready to become gilts. Indexed by duration (in `Period`s).
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.pallet_gilt.pallet.GiltBid>> Queues(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = QueuesParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.pallet_gilt.pallet.GiltBid>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ActiveTotalParams
        ///  Information relating to the gilts currently active.
        /// </summary>
        public static string ActiveTotalParams()
        {
            return RequestGenerator.GetStorage("Gilt", "ActiveTotal", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> ActiveTotalDefault
        /// Default value as hex string
        /// </summary>
        public static string ActiveTotalDefault()
        {
            return "0x000000000000000000000000000000000000000000000000000000000000000000000000";
        }

        /// <summary>
        /// >> ActiveTotal
        ///  Information relating to the gilts currently active.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.pallet_gilt.pallet.ActiveGiltsTotal> ActiveTotal(CancellationToken token)
        {
            string parameters = ActiveTotalParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.pallet_gilt.pallet.ActiveGiltsTotal>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ActiveParams
        ///  The currently active gilts, indexed according to the order of creation.
        /// </summary>
        public static string ActiveParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("Gilt", "Active", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> ActiveDefault
        /// Default value as hex string
        /// </summary>
        public static string ActiveDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Active
        ///  The currently active gilts, indexed according to the order of creation.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.pallet_gilt.pallet.ActiveGilt> Active(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = ActiveParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.pallet_gilt.pallet.ActiveGilt>(parameters, blockHash, token);
            return result;
        }

        public GiltStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class GiltConstants
    {
        /// <summary>
        /// >> QueueCount
        ///  Number of duration queues in total. This sets the maximum duration supported, which is
        ///  this value multiplied by `Period`.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 QueueCount()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x2C010000");
            return result;
        }

        /// <summary>
        /// >> MaxQueueLen
        ///  Maximum number of items that may be in each duration queue.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxQueueLen()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0xE8030000");
            return result;
        }

        /// <summary>
        /// >> FifoQueueLen
        ///  Portion of the queue which is free from ordering and just a FIFO.
        /// 
        ///  Must be no greater than `MaxQueueLen`.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 FifoQueueLen()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0xFA000000");
            return result;
        }

        /// <summary>
        /// >> Period
        ///  The base period for the duration queues. This is the common multiple across all
        ///  supported freezing durations that can be bid upon.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Period()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x80970600");
            return result;
        }

        /// <summary>
        /// >> MinFreeze
        ///  The minimum amount of funds that may be offered to freeze for a gilt. Note that this
        ///  does not actually limit the amount which may be frozen in a gilt since gilts may be
        ///  split up in order to satisfy the desired amount of funds under gilts.
        /// 
        ///  It should be at least big enough to ensure that there is no possible storage spam attack
        ///  or queue-filling attack.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 MinFreeze()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x50F8369C4D0000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> IntakePeriod
        ///  The number of blocks between consecutive attempts to issue more gilts in an effort to
        ///  get to the target amount to be frozen.
        /// 
        ///  A larger value results in fewer storage hits each block, but a slower period to get to
        ///  the target.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 IntakePeriod()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x32000000");
            return result;
        }

        /// <summary>
        /// >> MaxIntakeBids
        ///  The maximum amount of bids that can be turned into issued gilts each block. A larger
        ///  value here means less of the block available for transactions should there be a glut of
        ///  bids to make into gilts to reach the target.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxIntakeBids()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x64000000");
            return result;
        }
    }

    public enum GiltErrors
    {
        /// <summary>
        /// >> DurationTooSmall
        /// The duration of the bid is less than one.
        /// </summary>
        DurationTooSmall,
        /// <summary>
        /// >> DurationTooBig
        /// The duration is the bid is greater than the number of queues.
        /// </summary>
        DurationTooBig,
        /// <summary>
        /// >> AmountTooSmall
        /// The amount of the bid is less than the minimum allowed.
        /// </summary>
        AmountTooSmall,
        /// <summary>
        /// >> BidTooLow
        /// The queue for the bid's duration is full and the amount bid is too low to get in
        /// through replacing an existing bid.
        /// </summary>
        BidTooLow,
        /// <summary>
        /// >> Unknown
        /// Gilt index is unknown.
        /// </summary>
        Unknown,
        /// <summary>
        /// >> NotOwner
        /// Not the owner of the gilt.
        /// </summary>
        NotOwner,
        /// <summary>
        /// >> NotExpired
        /// Gilt not yet at expiry date.
        /// </summary>
        NotExpired,
        /// <summary>
        /// >> NotFound
        /// The given bid for retraction is not found.
        /// </summary>
        NotFound
    }
}