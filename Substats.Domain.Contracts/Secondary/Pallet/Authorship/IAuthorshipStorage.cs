using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary.Contracts;
using Substats.Domain.Contracts.Secondary.Pallet.Authorship.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Authorship
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
