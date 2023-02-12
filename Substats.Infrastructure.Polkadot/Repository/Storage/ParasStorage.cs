using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Core.Hash;
using Substats.Domain.Contracts.Secondary.Pallet.Paras;
using Substats.Polkadot.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
{
    public class ParasStorage : IParasStorage
    {
        private readonly SubstrateClientExt _client;
        public ParasStorage(SubstrateClientExt client)
        {
            _client = client;
        }
        public Task<IEnumerable<Id>> ActionsQueueAsync(uint key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]?> CodeByHashAsync(Hash key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<uint> CodeByHashRefs(Hash key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Hash> CurrentCodeHashAsync(Id key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Hash> FutureCodeHashAsync(Id key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<uint> FutureCodeUpgradesAsync(Id key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> HeadsAsync(Id key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Id>> ParachainsAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<ParaLifecycle> ParaLifecyclesAsync(Id key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Hash> PastCodeHashAsync((Id, uint) key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<ParaPastCodeMeta> PastCodeMetaAsync(Id key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<Id, uint>> PastCodePruningAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Hash>> PvfActiveVoteListAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<PvfCheckActiveVoteState> PvfActiveVoteMapAsync(Hash key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<ParaGenesisArgs> UpcomingParasGenesisAsync(Id key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<Id, uint>> UpcomingUpgradesAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<Id, uint>> UpgradeCooldownsAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<UpgradeGoAhead> UpgradeGoAheadSignalAsync(Id key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<UpgradeRestriction> UpgradeRestrictionSignalAsync(Id key, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
