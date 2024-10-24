using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.IdentityMigration;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Mapping;
using Polkanalysis.PeopleChain.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.PeopleChain.Storage
{
    internal class IdentityMigrationStorage : PeopleChainAbstractStorage, IIdentityMigrationStorage
    {
        public IdentityMigrationStorage(SubstrateClientExt client, PeopleChainMapping mapper, ILogger logger) : base(client, mapper, logger)
        {
        }
    }
}
