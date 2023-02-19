using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
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

        public Task<IEnumerable<Id>> ActionsQueueAsync(U32 key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]?> CodeByHashAsync(Hash key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> CodeByHashRefs(Hash key, CancellationToken token)
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

        public Task<U32> FutureCodeUpgradesAsync(Id key, CancellationToken token)
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

        public Task<Hash> PastCodeHashAsync((Id, U32) key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<ParaPastCodeMeta> PastCodeMetaAsync(Id key, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<Id, U32>> PastCodePruningAsync(CancellationToken token)
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

        public Task<IDictionary<Id, U32>> UpcomingUpgradesAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<Id, U32>> UpgradeCooldownsAsync(CancellationToken token)
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
