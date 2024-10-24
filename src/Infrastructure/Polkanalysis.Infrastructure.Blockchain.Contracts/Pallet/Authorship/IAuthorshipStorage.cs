using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Authorship.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Authorship
{
    public interface IAuthorshipStorage : IPalletStorage
    {
        /// <summary>
        /// Uncles
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseVec<EnumUncleEntryItem>> UnclesAsync(CancellationToken token);

        /// <summary>
        /// Author of current block.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<SubstrateAccount> AuthorAsync(CancellationToken token);

        /// <summary>
        /// Whether uncles were already set in this block.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Bool> DidSetUnclesAsync(CancellationToken token);
    }
}
