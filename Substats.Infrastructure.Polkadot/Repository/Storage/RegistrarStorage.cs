using Microsoft.Extensions.Logging;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary.Pallet.Registrar;
using Substats.Polkadot.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
{
    public class RegistrarStorage : MainStorage, IRegistrarStorage
    {
        public RegistrarStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public Task<Id> NextFreeParaIdAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<ParaInfo> ParasAsync(Id key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Id> PendingSwapAsync(Id key, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
