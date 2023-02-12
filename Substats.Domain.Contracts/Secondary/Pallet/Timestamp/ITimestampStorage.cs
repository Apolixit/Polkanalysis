using Substats.Domain.Contracts.Secondary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Timestamp
{
    public interface ITimestampStorage : IPalletStorage
    {
        /// <summary>
        /// Current time for the current block.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Ajuna.NetApi.Model.Types.Primitive.U64> NowAsync(CancellationToken token);

        /// <summary>
        /// Did the timestamp get updated in this block?
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Ajuna.NetApi.Model.Types.Primitive.Bool> DidUpdateAsync(CancellationToken token);
    }
}
