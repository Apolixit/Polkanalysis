using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Secondary.Common;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Crowdloan
{
    public interface ICrowdloanStorage : IPalletStorage
    {
        /// <summary>
        /// Info on all of the funds.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<FundInfo> FundsAsync(Id key, CancellationToken token);

        /// <summary>
        /// Query crowdloans
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public QueryStorage<Id, FundInfo> FundsQuery();

        /// <summary>
        ///  The funds that have had additional contributions during the last block. This is used
        ///  in order to determine which funds should submit new or updated bids.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseVec<Id>> NewRaiseAsync(CancellationToken token);

        /// <summary>
        /// The number of auctions that have entered into their ending period so far.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U32> EndingsCountAsync(CancellationToken token);

        /// <summary>
        /// >> NextFundIndex
        ///  Tracker for the next available fund index
        /// </summary>
        Task<U32> NextFundIndexAsync(CancellationToken token);

        /// <summary>
        /// >> NextTrieIndex
        ///  Tracker for the next available trie index
        /// </summary>
        Task<U32> NextTrieIndexAsync(CancellationToken token);
    }
}
