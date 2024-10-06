using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Common;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Mapping;
using Polkanalysis.PeopleChain.NetApiExt.Generated;

namespace Polkanalysis.Infrastructure.Blockchain.PeopleChain
{
    public abstract class PeopleChainAbstractStorage : AbstractStorage
    {
        protected readonly SubstrateClientExt _client;
        protected PeopleChainAbstractStorage(SubstrateClientExt client, PeopleChainMapping mapper, ILogger logger) : base(client, mapper, logger)
        {
            _client = client;
        }

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

                _client.ParachainInfoStorage.blockHash = _blockHash;
                _client.BalancesStorage.blockHash = _blockHash;
                _client.IdentityStorage.blockHash = _blockHash;
                _client.IdentityMigratorStorage.blockHash = _blockHash;
                _client.SystemStorage.blockHash = _blockHash;
                _client.TimestampStorage.blockHash = _blockHash;
            }
        }

        /// <summary>
        /// Shortcut to build an AccountId32Base (often used as input)
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        protected async Task<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base> MapAccoundId32Async(SubstrateAccount account, CancellationToken token)
        {
            var version = await GetVersionAsync(token);
            return _mapper.MapWithVersion<
                SubstrateAccount, Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base>(version, account);
        }
    }
}
