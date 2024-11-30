using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Common;
using Polkanalysis.Infrastructure.Blockchain.Mythos.Mapping;
using Polkanalysis.Mythos.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Mythos
{
    public abstract class MythosAbstractStorage : AbstractStorage
    {
        protected readonly SubstrateClientExt _client;
        protected MythosAbstractStorage(SubstrateClientExt client, MythosMapping mapper, ILogger logger) : base(client, mapper, logger)
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

                _client.SystemStorage.blockHash = _blockHash;
                _client.TimestampStorage.blockHash = _blockHash;
            }
        }
    }
}
