﻿using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Threading;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Core.Public;
using Polkanalysis.Domain.Contracts.Core.Random;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Babe;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Babe.Enums;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.weak_bounded_vec;
using Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base;
using BabeStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.BabeStorage;
using Polkanalysis.Infrastructure.Blockchain.Mapper;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage
{
    /// <summary>
    /// Babe storage mapping from Polkadot blockchain to Domain
    /// Mapping is define from <see cref="PolkadotMapping.AuthorshipStorageProfile"/>
    /// </summary>
    public class BabeStorage : MainStorage, IBabeStorage
    {
        public BabeStorage(SubstrateClientExt client, ILogger logger) : base(client, logger) { }

        public async Task<BaseVec<BaseTuple<PublicSr25519, U64>>> AuthoritiesAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                WeakBoundedVecT2,
                BaseVec<BaseTuple<PublicSr25519, U64>>>
                (BabeStorageExt.AuthoritiesParams, token);
        }

        public async Task<BaseOpt<Hexa>> AuthorVrfRandomnessAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                BaseOpt<Arr32U8>,
                BaseOpt<Hexa>>
                (BabeStorageExt.AuthorVrfRandomnessParams, token);

            //var result = await GetStorageAsync<BaseOpt<Arr32U8>>(BabeStorageExt.AuthorVrfRandomnessParams(), token);

            //if(result == null) return new BaseOpt<Hexa>();
            //return SubstrateMapper.Instance.Map<BaseOpt<Arr32U8>, BaseOpt<Hexa>>(result);
        }

        public async Task<U64> CurrentSlotAsync(CancellationToken token)
        {
            return await GetStorageAsync<U64>(BabeStorageExt.CurrentSlotParams, token);
        }

        public async Task<BabeEpochConfiguration> EpochConfigAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.BabeEpochConfiguration,
                BabeEpochConfiguration>
                (BabeStorageExt.EpochConfigParams, token);

            //var result = await GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.BabeEpochConfiguration>(BabeStorageExt.EpochConfigParams(), token);

            //if (result == null) return new BabeEpochConfiguration();

            //return SubstrateMapper.Instance.Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.BabeEpochConfiguration, BabeEpochConfiguration>(result);
        }

        public async Task<U64> EpochIndexAsync(CancellationToken token)
        {
            return await GetStorageAsync<U64>(BabeStorageExt.EpochIndexParams, token);
        }

        public async Task<BaseTuple<U32, U32>> EpochStartAsync(CancellationToken token)
        {
            return await GetStorageAsync<BaseTuple<U32, U32>>(BabeStorageExt.EpochStartParams, token);
        }

        public async Task<U64> GenesisSlotAsync(CancellationToken token)
        {
            return await GetStorageAsync<U64>(BabeStorageExt.GenesisSlotParams, token);
        }

        public async Task<BaseOpt<EnumPreDigest>> InitializedAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.digests.EnumPreDigest>,
                BaseOpt<EnumPreDigest>>
                (BabeStorageExt.InitializedParams, token);

            //var result = await GetStorageAsync<BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.digests.EnumPreDigest>>(BabeStorageExt.InitializedParams(), token);

            //if (result == null) return new BaseOpt<EnumPreDigest>();

            //return SubstrateMapper.Instance.Map<
            //    BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.digests.EnumPreDigest>, BaseOpt<EnumPreDigest>>
            //    (result);
        }

        public async Task<U32> LatenessAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(BabeStorageExt.LatenessParams, token);
        }

        public async Task<BaseVec<BaseTuple<PublicSr25519, U64>>> NextAuthoritiesAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                WeakBoundedVecT2,
                BaseVec<BaseTuple<PublicSr25519, U64>>>
                (BabeStorageExt.NextAuthoritiesParams, token);

            //var result = await GetStorageAsync<WeakBoundedVecT2>(BabeStorageExt.NextAuthoritiesParams(), token);

            //if (result == null) return new BaseVec<BaseTuple<PublicSr25519, U64>>();

            //return SubstrateMapper.Instance.Map<WeakBoundedVecT2, BaseVec<BaseTuple<PublicSr25519, U64>>>(result);
        }

        public async Task<BabeEpochConfiguration> NextEpochConfigAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.BabeEpochConfiguration,
                BabeEpochConfiguration>
                (BabeStorageExt.NextEpochConfigParams, token);

            //var result = await GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.BabeEpochConfiguration>(BabeStorageExt.NextEpochConfigParams(), token);

            //if (result == null) return new BabeEpochConfiguration();

            //return SubstrateMapper.Instance.Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.BabeEpochConfiguration, BabeEpochConfiguration>(result);
        }

        public async Task<Hexa> NextRandomnessAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                Arr32U8,
                Hexa>
                (BabeStorageExt.NextRandomnessParams, token);

            //var result = await GetStorageAsync<Arr32U8>(BabeStorageExt.NextRandomnessParams(), token);

            //if (result == null) return new Hexa();

            //return SubstrateMapper.Instance.Map<Arr32U8, Hexa>(result);
        }

        public async Task<EnumNextConfigDescriptor> PendingEpochConfigChangeAsync(CancellationToken token)
        {
            return await GetStorageAsync<
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.digests.EnumNextConfigDescriptor,
                EnumNextConfigDescriptor>
                (BabeStorageExt.PendingEpochConfigChangeParams, token);

            //var result = await GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.digests.EnumNextConfigDescriptor>(BabeStorageExt.PendingEpochConfigChangeParams(), token);

            //if (result == null) return new EnumNextConfigDescriptor();

            //return SubstrateMapper.Instance.Map<
            //    Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.digests.EnumNextConfigDescriptor, EnumNextConfigDescriptor>
            //    (result);
        }

        public async Task<Hexa> RandomnessAsync(CancellationToken token)
        {
            return await GetStorageAsync<Arr32U8, Hexa>(BabeStorageExt.RandomnessParams, token);

            //var result = await GetStorageAsync<Arr32U8>(BabeStorageExt.RandomnessParams(), token);

            //if (result == null) return new Hexa();

            //return SubstrateMapper.Instance.Map<Arr32U8, Hexa>(result);
        }

        public async Task<U32> SegmentIndexAsync(CancellationToken token)
        {
            return await GetStorageAsync<U32>(BabeStorageExt.SegmentIndexParams, token);
        }

        public async Task<BaseVec<Hexa>> UnderConstructionAsync(U32 key, CancellationToken token)
        {
            return await GetStorageWithParamsAsync<U32, BoundedVecT5, BaseVec<Hexa>>(key, BabeStorageExt.UnderConstructionParams, token);
        }
    }
}
