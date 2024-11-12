using Microsoft.Extensions.Logging;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Substrate.NetApi;
using Ardalis.GuardClauses;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Infrastructure.Blockchain.Common;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot
{
    public abstract class PolkadotAbstractStorage : AbstractStorage
    {
        protected readonly SubstrateClientExt _client;

        private string? _blockHash = null;
        public override string? BlockHash
        {
            get
            {
                return _blockHash;
            }
            set
            {
                _blockHash = value;

                // TODO : change it in Toolchain SDK to get blockHash property as interface member
                _client.AuctionsStorage.blockHash = _blockHash;
                _client.AuthorshipStorage.blockHash = _blockHash;
                _client.BabeStorage.blockHash = _blockHash;
                _client.BalancesStorage.blockHash = _blockHash;
                _client.CrowdloanStorage.blockHash = _blockHash;
                _client.IdentityStorage.blockHash = _blockHash;
                _client.NominationPoolsStorage.blockHash = _blockHash;
                _client.ParaSessionInfoStorage.blockHash = _blockHash;
                _client.ParasStorage.blockHash = _blockHash;
                _client.RegistrarStorage.blockHash = _blockHash;
                _client.SessionStorage.blockHash = _blockHash;
                _client.StakingStorage.blockHash = _blockHash;
                _client.SystemStorage.blockHash = _blockHash;
                _client.TimestampStorage.blockHash = _blockHash;
            }
        }

        protected PolkadotAbstractStorage(SubstrateClientExt client, PolkadotMapping mapper, ILogger logger) : base(client, mapper, logger)
        {
            _client = client;
        }

        /// <summary>
        /// Shortcut to build an AccountId32Base (often used as input)
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        protected async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base> MapAccoundId32Async(SubstrateAccount account, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            return _mapper.MapWithVersion<
                SubstrateAccount, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base>(version, account);
        }

        protected async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.IdBase> MapIdAsync(Id key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            return _mapper.MapWithVersion<
                Id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.IdBase>(version, key);
        }

        protected async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.ValidationCodeHashBase> MapHashAsync(Hash key, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            return _mapper.MapWithVersion<
                Hash, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.ValidationCodeHashBase>(version, key);
        }
    }
}
