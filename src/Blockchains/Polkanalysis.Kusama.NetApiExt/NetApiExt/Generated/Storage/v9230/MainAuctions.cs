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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9230
{
    public sealed class AuctionsStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> AuctionCounterParams
        ///  Number of auctions started so far.
        /// </summary>
        public static string AuctionCounterParams()
        {
            return RequestGenerator.GetStorage("Auctions", "AuctionCounter", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> AuctionCounterDefault
        /// Default value as hex string
        /// </summary>
        public static string AuctionCounterDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> AuctionCounter
        ///  Number of auctions started so far.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> AuctionCounter(CancellationToken token)
        {
            string parameters = AuctionCounterParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> AuctionInfoParams
        ///  Information relating to the current auction, if there is one.
        /// 
        ///  The first item in the tuple is the lease period index that the first of the four
        ///  contiguous lease periods on auction is for. The second is the block number when the
        ///  auction will "begin to end", i.e. the first block of the Ending Period of the auction.
        /// </summary>
        public static string AuctionInfoParams()
        {
            return RequestGenerator.GetStorage("Auctions", "AuctionInfo", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> AuctionInfoDefault
        /// Default value as hex string
        /// </summary>
        public static string AuctionInfoDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> AuctionInfo
        ///  Information relating to the current auction, if there is one.
        /// 
        ///  The first item in the tuple is the lease period index that the first of the four
        ///  contiguous lease periods on auction is for. The second is the block number when the
        ///  auction will "begin to end", i.e. the first block of the Ending Period of the auction.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>> AuctionInfo(CancellationToken token)
        {
            string parameters = AuctionInfoParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ReservedAmountsParams
        ///  Amounts currently reserved in the accounts of the bidders currently winning
        ///  (sub-)ranges.
        /// </summary>
        public static string ReservedAmountsParams(Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9230.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9230.polkadot_parachain.primitives.Id> key)
        {
            return RequestGenerator.GetStorage("Auctions", "ReservedAmounts", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> ReservedAmountsDefault
        /// Default value as hex string
        /// </summary>
        public static string ReservedAmountsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> ReservedAmounts
        ///  Amounts currently reserved in the accounts of the bidders currently winning
        ///  (sub-)ranges.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U128> ReservedAmounts(Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9230.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9230.polkadot_parachain.primitives.Id> key, CancellationToken token)
        {
            string parameters = ReservedAmountsParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U128>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> WinningParams
        ///  The winning bids for each of the 10 ranges at each sample in the final Ending Period of
        ///  the current auction. The map's key is the 0-based index into the Sample Size. The
        ///  first sample of the ending period is 0; the last is `Sample Size - 1`.
        /// </summary>
        public static string WinningParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("Auctions", "Winning", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> WinningDefault
        /// Default value as hex string
        /// </summary>
        public static string WinningDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Winning
        ///  The winning bids for each of the 10 ranges at each sample in the final Ending Period of
        ///  the current auction. The map's key is the 0-based index into the Sample Size. The
        ///  first sample of the ending period is 0; the last is `Sample Size - 1`.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr36BaseOpt> Winning(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = WinningParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr36BaseOpt>(parameters, blockHash, token);
            return result;
        }

        public AuctionsStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class AuctionsConstants
    {
        /// <summary>
        /// >> EndingPeriod
        ///  The number of blocks over which an auction may be retroactively ended.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 EndingPeriod()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x40190100");
            return result;
        }

        /// <summary>
        /// >> SampleLength
        ///  The length of each sample to take during the ending period.
        /// 
        ///  `EndingPeriod` / `SampleLength` = Total # of Samples
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 SampleLength()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x14000000");
            return result;
        }

        /// <summary>
        /// >> SlotRangeCount
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 SlotRangeCount()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x24000000");
            return result;
        }

        /// <summary>
        /// >> LeasePeriodsPerSlot
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 LeasePeriodsPerSlot()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x08000000");
            return result;
        }
    }

    public enum AuctionsErrors
    {
        /// <summary>
        /// >> AuctionInProgress
        /// This auction is already in progress.
        /// </summary>
        AuctionInProgress,
        /// <summary>
        /// >> LeasePeriodInPast
        /// The lease period is in the past.
        /// </summary>
        LeasePeriodInPast,
        /// <summary>
        /// >> ParaNotRegistered
        /// Para is not registered
        /// </summary>
        ParaNotRegistered,
        /// <summary>
        /// >> NotCurrentAuction
        /// Not a current auction.
        /// </summary>
        NotCurrentAuction,
        /// <summary>
        /// >> NotAuction
        /// Not an auction.
        /// </summary>
        NotAuction,
        /// <summary>
        /// >> AuctionEnded
        /// Auction has already ended.
        /// </summary>
        AuctionEnded,
        /// <summary>
        /// >> AlreadyLeasedOut
        /// The para is already leased out for part of this range.
        /// </summary>
        AlreadyLeasedOut
    }
}