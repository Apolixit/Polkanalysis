using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.AwesomeAvatars
{
    public interface IAwesomeAvatarsStorage : IPalletStorage
    {
        public Task<SubstrateAccount> OrganizerAsync(CancellationToken token);

        public Task<ushort> CurrentSeasonIdAsync(CancellationToken token);

        public Task<Bool> IsSeasonActiveAsync(CancellationToken token);

        /// <summary>
        /// Storage for the seasons.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Season> SeasonsAsync(ushort key, CancellationToken token);

        public Task<GlobalConfig> GlobalConfigsAsync(CancellationToken token);

        public Task<(SubstrateAccount, Avatar)> AvatarsAsync(Hash key, CancellationToken token);

        public Task<IEnumerable<Hash>> OwnersAsync(SubstrateAccount key, CancellationToken token);

        public Task<U32> LastMintedBlockNumbersAsync(SubstrateAccount key, CancellationToken token);
        public Task<ushort> FreeMintsAsync(SubstrateAccount key, CancellationToken token);

        public Task<U128> TradeAsync(Hash key, CancellationToken token);
    }
}
