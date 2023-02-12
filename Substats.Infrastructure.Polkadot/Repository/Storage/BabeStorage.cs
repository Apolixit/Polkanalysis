using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary.Pallet.Babe;
using Substats.Polkadot.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
{
    public class BabeStorage : IBabeStorage
    {
        private readonly SubstrateClientExt _client;
        public BabeStorage(SubstrateClientExt client)
        {
            _client = client;
        }

        public Task<IDictionary<Public, U64>> AuthoritiesAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Hash?> AuthorVrfRandomnessAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U64> CurrentSlotAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<BabeEpochConfiguration> EpochConfigAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U64> EpochIndexAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<(U32, U32)> EpochStartAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U64> GenesisSlotAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<EnumPreDigest?> InitializedAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> LatenessAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<Public, U64>> NextAuthoritiesAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<BabeEpochConfiguration> NextEpochConfigAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Hash> NextRandomnessAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<EnumNextConfigDescriptor> PendingEpochConfigChangeAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Hash> RandomnessAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<U32> SegmentIndexAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Hash>> UnderConstructionAsync(U32 key, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
