﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Auctions
{
    public interface IAuctionsStorage : IPalletStorage
    {
        /// <summary>
        /// Number of auctions started so far.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U32> AuctionCounterAsync(CancellationToken token);

        /// <summary>
        ///  Information relating to the current auction, if there is one.
        /// 
        ///  The first item in the tuple is the lease period index that the first of the four
        ///  contiguous lease periods on auction is for. The second is the block number when the
        ///  auction will "begin to end", i.e. the first block of the Ending Period of the auction.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseTuple<U32, U32>> AuctionInfoAsync(CancellationToken token);

        /// <summary>
        ///  Amounts currently reserved in the accounts of the bidders currently winning
        ///  (sub-)ranges.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U128> ReservedAmountsAsync(BaseTuple<SubstrateAccount, Id> key, CancellationToken token);

        /// <summary>
        ///  The winning bids for each of the 10 ranges at each sample in the final Ending Period of
        ///  the current auction. The map's key is the 0-based index into the Sample Size. The
        ///  first sample of the ending period is 0; the last is `Sample Size - 1`.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Winning> WinningAsync(U32 key, CancellationToken token);
    }
}
