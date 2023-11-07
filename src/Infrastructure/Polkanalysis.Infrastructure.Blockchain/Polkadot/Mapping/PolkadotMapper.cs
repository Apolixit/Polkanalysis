using AutoMapper;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Domain.Contracts.Core.Display;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core.Random;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Babe;
using Polkanalysis.Domain.Contracts.Core.Empty;
using Polkanalysis.Domain.Contracts.Core.Public;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.primitive_types;
using Polkanalysis.Domain.Contracts.Core.Signature;
using Polkanalysis.Infrastructure.Blockchain.Exceptions;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Sp;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Microsoft.Extensions.Logging;
using Substrate.NetApi.Model.Types.Base.Abstraction;
using Substrate.NET.Utils;
using Ardalis.GuardClauses;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Babe.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Crowdloan;
using Polkanalysis.Domain.Contracts.Core.Multi;
using System.Collections.Generic;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums;
using static Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping.PolkadotMapping.BabeStorageProfile;
using System.ComponentModel;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ParaSessionInfo;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Paras;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Paras.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Registrar;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Session;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using System.Diagnostics;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System;
using static Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping.PolkadotMapping.BaseTypeProfile;
using Polkanalysis.Domain.Contracts.Core.DispatchInfo;
using Polkanalysis.Domain.Contracts.Core.Enum;
using Polkanalysis.Domain.Contracts.Core.Error;
using static Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping.PolkadotMapping.ParachainStorageProfile;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping
{
    public class PolkadotMapping : IBlockchainMapping
    {
        private IMapper _mapper;
        private readonly ILogger<PolkadotMapping> _logger;

        public IConfigurationProvider ConfigurationProvider => _mapper.ConfigurationProvider;

        public PolkadotMapping(ILogger<PolkadotMapping> logger)
        {
            _logger = logger;

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BaseTypeProfile>();
                cfg.AddProfile<CommonProfile>();
                cfg.AddProfile<EnumProfile>();
                cfg.AddProfile<BytesProfile>();
                cfg.AddProfile<AuctionsStorageProfile>();
                cfg.AddProfile<AuthorshipStorageProfile>();
                cfg.AddProfile<BabeStorageProfile>();
                cfg.AddProfile<BalancesStorageProfile>();
                cfg.AddProfile<CrowdloanStorageProfile>();
                cfg.AddProfile<DemocracyStorageProfile>();
                cfg.AddProfile<IdentityStorageProfile>();
                cfg.AddProfile<NominationPoolsStorageProfile>();
                cfg.AddProfile<ParaSessionInfoStorageProfile>();
                cfg.AddProfile<ParachainStorageProfile>();
                cfg.AddProfile<PolkadotRuntimeParachain>();
                cfg.AddProfile<RegistarStorageProfile>();
                cfg.AddProfile<SchedulerStorageProfile>();
                cfg.AddProfile<SessionStorageProfile>();
                cfg.AddProfile<SystemStorageProfile>();
                cfg.AddProfile<StakingStorageProfile>();
                cfg.AddProfile<XcmStorageProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        /// <summary>
        /// Map TSource to TDestination by given a specific version. Depend on pallet version (System.SpecVersion)
        /// </summary>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <typeparam name="TDestination">Destination type</typeparam>
        /// <param name="version">Substrate blockchain SpecVersion</param>
        /// <param name="source">TSource instance data</param>
        /// <returns>Mapped object</returns>
        public TDestination MapWithVersion<TSource, TDestination>(uint version, TSource source)
            where TSource : IType
            where TDestination : IType
        {
            var mapped = _mapper.Map<TSource, TDestination>(source, opts => opts.Items["version"] = version);
            return mapped;
        }

        /// <summary>
        /// Map a dynamic runtime source type to a dynamic runtime destination type
        /// </summary>
        /// <param name="source"></param>
        /// <param name="sourceType"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public object Map(object source, Type sourceType, Type destinationType)
        {
            var mapped = _mapper.Map(source, sourceType, destinationType);
            return mapped;
        }

        private object Map(uint version, object source, Type sourceType, Type destinationType)
        {
            var mapped = _mapper.Map(source, sourceType, destinationType, opts => opts.Items["version"] = version);
            return mapped;
        }

        public IType Map<TSource>(uint version, TSource source, Type destinationType)
            where TSource : IType
        {
            return (IType)Map(version, source, typeof(TSource), destinationType);
        }

        public TDestination Map<TSource, TDestination>(TSource source) where TSource : IType
        {
            var mapped = _mapper.Map<TSource, TDestination>(source);
            return mapped;
        }

        public TDestination Map<TDestination>(object source)
            where TDestination : IType
        {
            var mapped = _mapper.Map<TDestination>(source);
            return mapped;
        }

        public TDestination MapEnum<TDestination>(IBaseEnum source)
            where TDestination : IBaseEnum, new()
        {
            return (TDestination)MapEnumInternal(source, typeof(TDestination));
        }

        public IType MapEnum(IBaseEnum source, Type destinationType)
        {
            return MapEnumInternal(source, destinationType);
        }

        private static IType MapEnumInternal(IBaseEnum source, Type destinationType, ResolutionContext? context = null)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));

            object? destinationInstance = Activator.CreateInstance(destinationType);
            if (destinationInstance is null)
                throw new InvalidOperationException($"Cannot create instance of {destinationType}");

            var destination = (IBaseEnum)destinationInstance;

            var destinationEnumType = destination!.GetValue()!.GetType();
            if (!destinationEnumType.IsEnum)
                throw new InvalidCastException($"{nameof(destinationEnumType)} is not an enum");

            var destinationEnumNames = destinationEnumType.GetEnumNames();
            if (destinationEnumNames.Length == 0)
                throw new InvalidOperationException($"{nameof(destinationEnumType)} is a enum with no data");

            object? mappedEnum;
            if (!Enum.TryParse(destinationEnumType, source.GetEnum().ToString(), true, out mappedEnum))
                throw new MissingMappingException($"Impossible to cast {source.GetType()} to {destinationType}");

            var baseEnumExtBytes = new List<byte>()
                {
                    Convert.ToByte(mappedEnum)
                };

            if(source is BaseEnumType sourceBaseEnumType && context is not null)
            {
                var associatedDataType = destinationType.BaseType.GenericTypeArguments[(int)mappedEnum + 1];
                var associatedData = (IType)context.Mapper.Map(sourceBaseEnumType.GetValue2(), sourceBaseEnumType.GetValue2()!.GetType(), associatedDataType);
                baseEnumExtBytes.AddRange(associatedData.Encode());
            }
            else
            {
                baseEnumExtBytes.AddRange(source.GetValues().Encode());
            }
            
            destination.Create(baseEnumExtBytes.ToArray());

            // Check if Value2 type is valid
            int sourceTypeSize = source.GetValues().TypeSize;
            int destinationTypeSize = destination.GetValues().TypeSize;
            if (sourceTypeSize != destinationTypeSize)
            {
                throw new InvalidTypeSizeException($"Error while trying to map {source.GetType()} to {destinationType}," +
                    $"associated data (Value2) does not have same TypeSize (source = {sourceTypeSize} / " +
                    $"destination = {destinationTypeSize})");
            }

            return destination;

        }

        public class BytesProfile : Profile
        {
            public BytesProfile()
            {
                CreateMap<Arr32U8, IEnumerable<U8>>().ConvertUsing(x => x.Value);
            }
        }
        public class CommonProfile : Profile
        {
            public CommonProfile()
            {
                CreateMap<IBaseEnum, Contracts.Pallet.Balances.Enums.EnumEvent>().IncludeAllDerived().ConvertUsing(
                    new EnumConverter<Contracts.Pallet.Balances.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Contracts.Pallet.Balances.Enums.EnumError>().IncludeAllDerived().ConvertUsing(
                    new EnumConverter<Contracts.Pallet.Balances.Enums.EnumError>());

                CreateMap(typeof(BaseOpt<>), typeof(Nullable<>)).ConvertUsing(typeof(BaseOptNullConverter<>));

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base, SubstrateAccount>().IncludeAllDerived().ConvertUsing(new AccountId32Converter());
                CreateMap<SubstrateAccount, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base>().IncludeAllDerived().ConvertUsing(new SubstrateAccountConverter());

                CreateMap<H256Base, Hash>().ConvertUsing(new H256Converter());
                CreateMap<Hash, H256Base>().ConvertUsing(new HashConverter());

                CreateMap<
                    Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.ValidationCodeHashBase, Hash>().IncludeAllDerived().ConvertUsing(new ValidationCodeHashConverter());
                CreateMap<Hash, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.ValidationCodeHashBase>().ConvertUsing(new HashToValidationCodeConverter());

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.per_things.PerbillBase, Perbill>().IncludeAllDerived().ConvertUsing(new PerbillBaseConverter());
                CreateMap<Perbill, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.per_things.PerbillBase>().IncludeAllDerived().ConvertUsing(new PerbillConverter());

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_im_online.sr25519.app_sr25519.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519(x.Value.Value.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.assignment_app.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519(x.Value.Value.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.validator_app.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519(x.Value.Value.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_authority_discovery.app.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519(x.Value.Value.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_babe.app.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519(x.Value.Value.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.collator_app.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519(x.Value.Value.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.sr25519.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519(x.Value.Value));
                CreateMap<PublicSr25519, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.sr25519.PublicBase>().IncludeAllDerived().ConvertUsing(new PublicSr25519Converter());

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.ed25519.PublicBase, PublicEd25519>().ConvertUsing(x => new PublicEd25519(x.Value.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_finality_grandpa.app.PublicBase, PublicEd25519>().ConvertUsing(x => new PublicEd25519(x.Value.Value.Value));

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.sr25519.SignatureBase, SignatureSr25519>().ConvertUsing(x => new SignatureSr25519(x.Value.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.collator_app.SignatureBase, SignatureSr25519>().ConvertUsing(x => new SignatureSr25519(x.Value.Value.Value));

                //CreateMap<PublicEd25519, Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.ed25519.Public>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.bitvec.order.Lsb0Base, Lsb0>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_identity.types.BitFlagsBase, U64>().ConvertUsing(x => x.Value);

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_slots.SlotBase, Slot>()
                    .IncludeAllDerived();
                CreateMap<Slot, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_slots.SlotBase>()
                    .IncludeAllDerived().ConvertUsing(new SlotConverter());
            }

            public class SlotConverter : ITypeConverter<Slot, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_slots.SlotBase>
            {
                public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_slots.SlotBase Convert(Slot source, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_slots.SlotBase destination, ResolutionContext context)
                {
                    if (!context.Items.ContainsKey("version"))
                        throw new SpecVersionMissingException("Version is missing while mapping Slot to SlotBase");

                    destination = Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_slots.SlotBase.Create(source.Bytes ?? source.Encode(), (uint)context.Items["version"]);

                    return destination;
                }
            }

            public class PerbillBaseConverter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.per_things.PerbillBase, Perbill>
            {
                public Perbill Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.per_things.PerbillBase source, Perbill destination, ResolutionContext context)
                {
                    destination = new Perbill(source.Value);
                    return destination;
                }
            }

            public class PerbillConverter : ITypeConverter<Perbill, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.per_things.PerbillBase>
            {
                public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.per_things.PerbillBase Convert(Perbill source, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.per_things.PerbillBase destination, ResolutionContext context)
                {
                    if (!context.Items.ContainsKey("version"))
                        throw new SpecVersionMissingException("Version is missing while mapping Perbill to PerbillBase");

                    destination = Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.per_things.PerbillBase.Create(source.Bytes ?? source.Encode(), (uint)context.Items["version"]);

                    return destination;
                }
            }

            public class PublicSr25519Converter : ITypeConverter<PublicSr25519, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.sr25519.PublicBase>
            {
                public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.sr25519.PublicBase Convert(PublicSr25519 source, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.sr25519.PublicBase destination, ResolutionContext context)
                {
                    if (!context.Items.ContainsKey("version"))
                        throw new SpecVersionMissingException("Version is missing while mapping PublicSr25519 to PublicBase");

                    destination = Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.sr25519.PublicBase.Create(source.Bytes ?? source.Encode(), (uint)context.Items["version"]);

                    return destination;
                }
            }

            public class PublicBaseConverter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.sr25519.PublicBase, PublicSr25519>
            {
                public PublicSr25519 Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.sr25519.PublicBase source, PublicSr25519 destination, ResolutionContext context)
                {
                    destination = new PublicSr25519(source.Value.Value);
                    return destination;
                }
            }
        }

        public class EnumProfile : Profile
        {
            public EnumProfile()
            {
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.bounded_collections.bounded_vec.BoundedVecT3Base, BaseVec<U8>>().ConvertUsing(x => x.Value);

                /*
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_support.traits.preimages.EnumBounded, EnumBounded>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_support.traits.schedule.EnumLookupError, EnumLookupError>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.pallet.EnumError, Domain.Contracts.Secondary.Pallet.SystemCore.Enums.EnumError>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_authorship.pallet.EnumError, Domain.Contracts.Secondary.Pallet.Authorship.Enums.EnumError>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_babe.pallet.EnumError, Domain.Contracts.Secondary.Pallet.Babe.Enums.EnumError>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_bags_list.list.EnumListError, Domain.Contracts.Secondary.Pallet.BagsList.Enums.EnumListError>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_bags_list.pallet.EnumError, Domain.Contracts.Secondary.Pallet.BagsList.Enums.EnumError>();

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_bags_list.pallet.EnumEvent, Domain.Contracts.Secondary.Pallet.BagsList.Enums.EnumEvent>().ConvertUsing(typeof(BagListEnumExtConverter));

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_balances.pallet.EnumEvent, Domain.Contracts.Secondary.Pallet.Balances.Enums.EnumEvent>()
                    .ConvertUsing(typeof(BaseEnumExtConverter<,,,,,,,,,,,,,,,,,,,,,>));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_balances.EnumReleases, Domain.Contracts.Secondary.Pallet.Balances.Enums.EnumReleases>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_bounties.EnumBountyStatus, Domain.Contracts.Secondary.Pallet.Bounties.Enums.EnumBountyStatus>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_bounties.pallet.EnumError, Domain.Contracts.Secondary.Pallet.Bounties.Enums.EnumError>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_child_bounties.EnumChildBountyStatus, Domain.Contracts.Secondary.Pallet.ChildBounties.Enums.EnumChildBountyStatus>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_child_bounties.pallet.EnumError, Domain.Contracts.Secondary.Pallet.ChildBounties.Enums.EnumError>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_collective.pallet.EnumError, Domain.Contracts.Secondary.Pallet.Collective.Enums.EnumError>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_collective.EnumRawOrigin, Domain.Contracts.Secondary.Pallet.Collective.Enums.EnumRawOrigin>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_democracy.conviction.EnumConviction, EnumConviction>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_democracy.pallet.EnumError, Domain.Contracts.Secondary.Pallet.Democracy.Enums.EnumError>();
                */

                CreateMap<IBaseEnum, EnumDispatchClass>().ConvertUsing(new EnumConverter<EnumDispatchClass>());
                CreateMap<IBaseEnum, EnumPays>().ConvertUsing(new EnumConverter<EnumPays>());
                CreateMap<IBaseEnum, EnumRawOrigin>().ConvertUsing(new EnumConverter<EnumRawOrigin>());
                CreateMap<IBaseEnum, EnumResult>().ConvertUsing(new EnumConverter<EnumResult>());
                CreateMap<IBaseEnum, EnumArithmeticError>().ConvertUsing(new EnumConverter<EnumArithmeticError>());
                CreateMap<IBaseEnum, EnumDispatchError>().ConvertUsing(new EnumConverter<EnumDispatchError>());
                CreateMap<IBaseEnum, EnumTokenError>().ConvertUsing(new EnumConverter<EnumTokenError>());
                CreateMap<IBaseEnum, EnumTransactionalError>().ConvertUsing(new EnumConverter<EnumTransactionalError>());
                CreateMap<IBaseEnum, EnumMultiAddress>().ConvertUsing(new EnumConverter<EnumMultiAddress>());
                CreateMap<IBaseEnum, EnumMultiSignature>().ConvertUsing(new EnumConverter<EnumMultiSignature>());
                CreateMap<IBaseEnum, EnumMultiSigner>().ConvertUsing(new EnumConverter<EnumMultiSigner>());
                CreateMap<IBaseEnum, Contracts.Pallet.Authorship.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Authorship.Enums.EnumError>());
                CreateMap<IBaseEnum, Contracts.Pallet.Authorship.Enums.EnumUncleEntryItem>().ConvertUsing(new EnumConverter<Contracts.Pallet.Authorship.Enums.EnumUncleEntryItem>());
                CreateMap<IBaseEnum, Contracts.Pallet.Babe.Enums.EnumAllowedSlots>().ConvertUsing(new EnumConverter<Contracts.Pallet.Babe.Enums.EnumAllowedSlots>());
                CreateMap<IBaseEnum, Contracts.Pallet.Babe.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Babe.Enums.EnumError>());
                CreateMap<IBaseEnum, Contracts.Pallet.Babe.Enums.EnumNextConfigDescriptor>().ConvertUsing(new EnumConverter<Contracts.Pallet.Babe.Enums.EnumNextConfigDescriptor>());
                CreateMap<IBaseEnum, Contracts.Pallet.Babe.Enums.EnumPreDigest>().ConvertUsing(new EnumConverter<Contracts.Pallet.Babe.Enums.EnumPreDigest>());
                CreateMap<IBaseEnum, Contracts.Pallet.BagsList.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.BagsList.Enums.EnumError>());
                CreateMap<IBaseEnum, Contracts.Pallet.BagsList.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.BagsList.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Contracts.Pallet.BagsList.Enums.EnumListError>().ConvertUsing(new EnumConverter<Contracts.Pallet.BagsList.Enums.EnumListError>());
                CreateMap<IBaseEnum, Contracts.Pallet.Balances.Enums.EnumBalanceStatus>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.EnumBalanceStatus>());
                //CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.EnumError>());
                //CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.EnumReasons>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.EnumReasons>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.EnumReleases>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.EnumReleases>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Bounties.Enums.EnumBountyStatus>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Bounties.Enums.EnumBountyStatus>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Bounties.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Bounties.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Bounties.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Bounties.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ChildBounties.Enums.EnumChildBountyStatus>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ChildBounties.Enums.EnumChildBountyStatus>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ChildBounties.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ChildBounties.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ChildBounties.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ChildBounties.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Collective.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Collective.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Collective.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Collective.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Collective.Enums.EnumRawOrigin>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Collective.Enums.EnumRawOrigin>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ConvictionVoting.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ConvictionVoting.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ConvictionVoting.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ConvictionVoting.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Crowdloan.EnumLastContribution>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Crowdloan.EnumLastContribution>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums.EnumAccountVote>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums.EnumAccountVote>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums.EnumConviction>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums.EnumConviction>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums.EnumPreimageStatus>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums.EnumPreimageStatus>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums.EnumReferendumInfo>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums.EnumReferendumInfo>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums.EnumReleases>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums.EnumReleases>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums.EnumVoteThreshold>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums.EnumVoteThreshold>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums.EnumVoting>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums.EnumVoting>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ElectionProviderMultiPhase.Enums.EnumElectionCompute>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ElectionProviderMultiPhase.Enums.EnumElectionCompute>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ElectionProviderMultiPhase.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ElectionProviderMultiPhase.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ElectionProviderMultiPhase.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ElectionProviderMultiPhase.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ElectionProviderMultiPhase.Enums.EnumPhase>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ElectionProviderMultiPhase.Enums.EnumPhase>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ElectionsPhragmen.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ElectionsPhragmen.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ElectionsPhragmen.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ElectionsPhragmen.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ElectionsPhragmen.Enums.EnumRenouncing>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ElectionsPhragmen.Enums.EnumRenouncing>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.FastUnstake.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.FastUnstake.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.FastUnstake.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.FastUnstake.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.GrandPa.Enums.EnumEquivocation>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.GrandPa.Enums.EnumEquivocation>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.GrandPa.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.GrandPa.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.GrandPa.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.GrandPa.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.GrandPa.Enums.EnumStoredState>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.GrandPa.Enums.EnumStoredState>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums.EnumData>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums.EnumData>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums.EnumIdentityField>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums.EnumIdentityField>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums.EnumJudgement>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums.EnumJudgement>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ImOnline.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ImOnline.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ImOnline.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ImOnline.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Indices.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Indices.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Indices.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Indices.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Membership.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Membership.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Membership.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Membership.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.MessageQueue.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.MessageQueue.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.MessageQueue.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.MessageQueue.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Multisig.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Multisig.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Multisig.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Multisig.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.EnumBondExtra>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.EnumBondExtra>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.EnumClaimPermission>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.EnumClaimPermission>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.EnumConfigOp>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.EnumConfigOp>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.EnumDefensiveError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.EnumDefensiveError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.EnumPoolState>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.EnumPoolState>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Offences.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Offences.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Paras.Enums.EnumParaLifecycle>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Paras.Enums.EnumParaLifecycle>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Paras.Enums.EnumPvfCheckCause>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Paras.Enums.EnumPvfCheckCause>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Paras.Enums.EnumUpgradeGoAhead>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Paras.Enums.EnumUpgradeGoAhead>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Paras.Enums.EnumUpgradeRestriction>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Paras.Enums.EnumUpgradeRestriction>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ParaSessionInfo.Enums.EnumExecutorParam>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ParaSessionInfo.Enums.EnumExecutorParam>());
                CreateMap<IBaseEnum, Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotPrimitive.v2.Enum.EnumCoreOccupied>().ConvertUsing(new EnumConverter<Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotPrimitive.v2.Enum.EnumCoreOccupied>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotPrimitive.v2.Enum.EnumDisputeStatement>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotPrimitive.v2.Enum.EnumDisputeStatement>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotPrimitive.v2.Enum.EnumInvalidDisputeStatementKind>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotPrimitive.v2.Enum.EnumInvalidDisputeStatementKind>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotPrimitive.v2.Enum.EnumValidDisputeStatementKind>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotPrimitive.v2.Enum.EnumValidDisputeStatementKind>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotPrimitive.v2.Enum.EnumValidityAttestation>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotPrimitive.v2.Enum.EnumValidityAttestation>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotPrimitive.v4.EnumPvfExecTimeoutKind>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotPrimitive.v4.EnumPvfExecTimeoutKind>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotPrimitive.v4.EnumPvfPrepTimeoutKind>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotPrimitive.v4.EnumPvfPrepTimeoutKind>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime.EnumOriginCaller>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime.EnumOriginCaller>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime.EnumProxyType>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime.EnumProxyType>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime.EnumRuntimeEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime.EnumRuntimeEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Auctions.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Auctions.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Auctions.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Auctions.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Claims.Enum.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Claims.Enum.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Claims.Enum.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Claims.Enum.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums.EnumLastContribution>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums.EnumLastContribution>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.ParasRegistar.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.ParasRegistar.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.ParasRegistar.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.ParasRegistar.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Slots.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Slots.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Slots.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Slots.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Configuration.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Configuration.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Disputes.Enums.EnumDisputeLocation>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Disputes.Enums.EnumDisputeLocation>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Disputes.Enums.EnumDisputeResult>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Disputes.Enums.EnumDisputeResult>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Disputes.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Disputes.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Disputes.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Disputes.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Hrmp.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Hrmp.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Hrmp.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Hrmp.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Inclusion.Enums.EnumAggregateMessageOrigin>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Inclusion.Enums.EnumAggregateMessageOrigin>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Inclusion.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Inclusion.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Inclusion.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Inclusion.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Inclusion.Enums.EnumUmpQueueId>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Inclusion.Enums.EnumUmpQueueId>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Origin.Enums.EnumOrigin>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Origin.Enums.EnumOrigin>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.ParaInherent.Enum.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.ParaInherent.Enum.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Paras.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Paras.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Paras.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Paras.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Scheduler.Enums.EnumAssignmentKind>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Scheduler.Enums.EnumAssignmentKind>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Ump.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Ump.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Ump.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Ump.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PreImage.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PreImage.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PreImage.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PreImage.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PreImage.Enums.EnumRequestStatus>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PreImage.Enums.EnumRequestStatus>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Proxy.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Proxy.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Proxy.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Proxy.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Proxy.Enums.EnumProxyType>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Proxy.Enums.EnumProxyType>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Referenda.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Referenda.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Referenda.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Referenda.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Scheduler.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Scheduler.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Scheduler.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Scheduler.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Session.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Session.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Session.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Session.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums.EnumConfigOp>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums.EnumConfigOp>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums.EnumForcing>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums.EnumForcing>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums.EnumReleases>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums.EnumReleases>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums.EnumRewardDestination>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums.EnumRewardDestination>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Support.Enum.EnumBounded>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Support.Enum.EnumBounded>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Support.Enum.EnumLookupError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Support.Enum.EnumLookupError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Support.Enum.EnumProcessMessageError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Support.Enum.EnumProcessMessageError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums.EnumDigestItem>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums.EnumDigestItem>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums.EnumPhase>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums.EnumPhase>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Timestamp.Enums.EnumCall>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Timestamp.Enums.EnumCall>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Tips.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Tips.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Tips.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Tips.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.TransactionPayment.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.TransactionPayment.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.TransactionPayment.Enums.EnumReleases>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.TransactionPayment.Enums.EnumReleases>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Treasury.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Treasury.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Treasury.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Treasury.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Utility.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Utility.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Utility.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Utility.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Vesting.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Vesting.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Vesting.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Vesting.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Vesting.Enums.EnumReleases>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Vesting.Enums.EnumReleases>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.WhiteList.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.WhiteList.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.WhiteList.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.WhiteList.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums.EnumEvent>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums.EnumOrigin>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums.EnumOrigin>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums.EnumQueryStatus>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums.EnumQueryStatus>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums.EnumVersionedMultiAssets>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums.EnumVersionedMultiAssets>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums.EnumVersionedMultiLocation>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums.EnumVersionedMultiLocation>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums.EnumVersionedResponse>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums.EnumVersionedResponse>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums.EnumVersionedXcm>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums.EnumVersionedXcm>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums.EnumVersionMigrationStage>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums.EnumVersionMigrationStage>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums.EnumBodyId>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums.EnumBodyId>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums.EnumBodyPart>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums.EnumBodyPart>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums.EnumJunction>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums.EnumJunction>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums.EnumMultiAsset>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums.EnumMultiAsset>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums.EnumMultiLocation>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums.EnumMultiLocation>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums.EnumNetworkId>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums.EnumNetworkId>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums.EnumOrder>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums.EnumOrder>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums.EnumOriginKind>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums.EnumOriginKind>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums.EnumResponse>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums.EnumResponse>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums.EnumXcm>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v0.Enums.EnumXcm>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumAssetId>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumAssetId>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumAssetInstance>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumAssetInstance>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumBodyId>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumBodyId>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumBodyPart>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumBodyPart>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumFungibility>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumFungibility>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumJunction>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumJunction>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumJunctions>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumJunctions>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumMultiAssetFilter>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumMultiAssetFilter>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumOrder>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumOrder>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumResponse>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumResponse>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumWildFungibility>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumWildFungibility>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumWildMultiAsset>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumWildMultiAsset>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumXcm>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums.EnumXcm>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v2.Enums.EnumError>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v2.Enums.EnumError>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v2.Enums.EnumInstruction>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v2.Enums.EnumInstruction>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v2.Enums.EnumOutcome>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v2.Enums.EnumOutcome>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v2.Enums.EnumResponse>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v2.Enums.EnumResponse>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v2.Enums.EnumWeightLimit>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v2.Enums.EnumWeightLimit>());
            }
        }
        public class BaseTypeProfile : Profile
        {
            public BaseTypeProfile()
            {
                CreateMap(typeof(BaseOpt<>), typeof(Nullable<>)).ConvertUsing(typeof(BaseOptNullConverter<>));
                CreateMap(typeof(BaseOpt<>), typeof(BaseOpt<>)).ConvertUsing(typeof(BaseOptConverter<,>));
                CreateMap(typeof(BaseTuple<,>), typeof(ValueTuple<,>)).ConvertUsing(typeof(TupleConverter<,>));
                CreateMap(typeof(BaseTuple<,>), typeof(BaseTuple<,>)).ConvertUsing(typeof(BaseTupleConverter<,,,>));
                CreateMap(typeof(BaseTuple<,,>), typeof(BaseTuple<,,>)).ConvertUsing(typeof(BaseTupleConverter<,,,,,>));
                CreateMap(typeof(BaseTuple<,,,>), typeof(BaseTuple<,,,>)).ConvertUsing(typeof(BaseTupleConverter<,,,,,,,>));
                CreateMap(typeof(BaseTuple<,,,,>), typeof(BaseTuple<,,,,>)).ConvertUsing(typeof(BaseTupleConverter<,,,,,,,,,>));
                //CreateMap(typeof(IBaseEnumerable), typeof(BaseVec<>)).ConvertUsing(typeof(BaseEnumerableConverter<,>));
                CreateMap(typeof(BaseVec<>), typeof(BaseVec<>)).ConvertUsing(typeof(BaseVecConverter<,>));
                CreateMap(typeof(BaseCom<>), typeof(BaseCom<>)).ConvertUsing(typeof(BaseComConverter<,>));
                CreateMap(typeof(IBaseCom), typeof(BaseCom<>)).ConvertUsing(typeof(BaseComGenericConverter<>));

                //CreateMap<
                //    Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.sp_consensus_babe.digests.NextConfigDescriptor, 
                //    NextConfigDescriptor>().ConvertUsingEnumMapping(opt => opt.);
                //CreateMap(typeof(IBaseEnum), typeof(IBaseEnum)).IncludeAllDerived().ConvertUsing(typeof(BaseEnumConverterInherit<,,,>));


                //BaseEnum
                //CreateMap(typeof(BaseEnum<>), typeof(BaseEnum<>)).IncludeAllDerived().ConvertUsing(typeof(BaseEnumConverter<,>));

                //CreateMap(typeof(BaseEnumExt<,,,>), typeof(BaseEnumExt<,,,>)).IncludeAllDerived().ConvertUsing(typeof(BaseEnumExtConverter<,,,>));
                //CreateMap(typeof(BaseEnumExt<,,,,,,,,,,>), typeof(BaseEnumExt<,,,,,,,,,,>)).IncludeAllDerived().ConvertUsing(typeof(BaseEnumExtConverter<,,,,,,,,,,,,,,,,,,,,,>));

                BaseComMapping<I8>();
                BaseComMapping<I16>();
                BaseComMapping<I32>();
                BaseComMapping<I64>();
                BaseComMapping<I128>();
                BaseComMapping<I256>();
                BaseComMapping<U8>();
                BaseComMapping<U16>();
                BaseComMapping<U32>();
                BaseComMapping<U64>();
                BaseComMapping<U128>();
                BaseComMapping<U256>();
                //BaseComMapping<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.per_things.PerbillBase>();
                BaseComMapping<Perbill>();

                BaseComCoreMapping<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.per_things.PerbillBase, Perbill>();
            }

            private void BaseComMapping<T>()
                where T : IType, new()
            {
                CreateMap<BaseCom<T>, T>().ConvertUsing(new BaseComToGenericConverter<T>());
                CreateMap<T, BaseCom<T>>().ConvertUsing(new GenericToBaseComConverter<T>());
            }

            private void BaseComCoreMapping<T, U>()
                where T : IType
                where U : IType, new()
            {
                //CreateMap<BaseCom<T>, T>().ConvertUsing(new BaseComToGenericConverter<T>());
                CreateMap<T, BaseCom<U>>().ConvertUsing(new GenericToBaseComCoreConverter<T, U>());
            }

            public class BaseComToGenericConverter<T> : ITypeConverter<BaseCom<T>, T>
                where T : IType, new()
            {
                public T Convert(BaseCom<T> source, T destination, ResolutionContext context)
                {
                    destination = new T();
                    if (source == null) return destination;

                    destination.Create(source.Value.Value.ToByteArray());

                    return destination;
                }
            }

            public class GenericToBaseComConverter<T> : ITypeConverter<T, BaseCom<T>>
                where T : IType, new()
            {
                public BaseCom<T> Convert(T source, BaseCom<T> destination, ResolutionContext context)
                {
                    destination = new BaseCom<T>();
                    if (source == null) return destination;

                    CompactInteger compactNum = CompactIntegerMap(source);

                    destination = new BaseCom<T>(compactNum);
                    return destination;
                }
            }

            public class GenericToBaseComCoreConverter<T, U> : ITypeConverter<T, BaseCom<U>>
                where T : IType
                where U : IType, new()
            {
                public BaseCom<U> Convert(T source, BaseCom<U> destination, ResolutionContext context)
                {
                    destination = new BaseCom<U>();
                    if (source == null) return destination;

                    var mapped = context.Mapper.Map<T, U>(source);
                    CompactInteger compactNum = CompactIntegerMap(mapped);

                    destination = new BaseCom<U>(compactNum);
                    return destination;
                }
            }

            private static CompactInteger CompactIntegerMap<U>(U mapped)
                    where U : IType, new()
            {
                CompactInteger compactNum = new CompactInteger();
                switch (mapped)
                {
                    case I8 num:
                        compactNum = new CompactInteger(num);
                        break;
                    case I16 num:
                        compactNum = new CompactInteger(num);
                        break;
                    case I32 num:
                        compactNum = new CompactInteger(num);
                        break;
                    case I64 num:
                        compactNum = new CompactInteger(num);
                        break;
                    case I128 num:
                        compactNum = new CompactInteger(num);
                        break;
                    case I256 num:
                        compactNum = new CompactInteger(num);
                        break;
                    case U8 num:
                        compactNum = new CompactInteger(num);
                        break;
                    case U16 num:
                        compactNum = new CompactInteger(num);
                        break;
                    case U32 num:
                        compactNum = new CompactInteger(num);
                        break;
                    case U64 num:
                        compactNum = new CompactInteger(num);
                        break;
                    case U128 num:
                        compactNum = new CompactInteger(num);
                        break;
                    case U256 num:
                        compactNum = new CompactInteger(num);
                        break;
                    case Perbill num:
                        compactNum = new CompactInteger(num.Value);
                        break;
                }

                return compactNum;
            }

            public class BaseComConverter<T1, T2> : ITypeConverter<BaseCom<T1>, BaseCom<T2>>
                where T1 : IType, new()
                where T2 : IType, new()
            {
                public BaseCom<T2> Convert(BaseCom<T1> source, BaseCom<T2> destination, ResolutionContext context)
                {
                    destination = new BaseCom<T2>();
                    if (source == null) return destination;

                    T1? t1;
                    try
                    {
                        t1 = context.Mapper.Map<BaseCom<T1>, T1>(source);
                    } 
                    catch
                    {
                        // Ugly hack, need to find a better solution
                        var x1 = (CompactInteger)source.As<IType>().GetValue();
                        t1 = new T1();
                        t1.Create(x1.Value.ToByteArray());
                    }
                    var t2 = context.Mapper.Map<T1, T2>(t1);

                    destination = context.Mapper.Map<T2, BaseCom<T2>>(t2);

                    return destination;
                }
            }

            public class BaseComGenericConverter<T2> : ITypeConverter<IBaseCom, BaseCom<T2>>
                where T2 : IType, new()
            {
                public BaseCom<T2> Convert(IBaseCom source, BaseCom<T2> destination, ResolutionContext context)
                {
                    destination = new BaseCom<T2>();
                    if (source == null) return destination;

                    destination = new BaseCom<T2>(source.Value);
                    return destination;
                }
            }

            public class BaseEnumTypeConverter : ITypeConverter<BaseEnumType, BaseEnumType>
            {
                public BaseEnumType Convert(BaseEnumType source, BaseEnumType destination, ResolutionContext context)
                {
                    var x = 1;
                    return destination;
                }
            }

            //public class BagListEnumExtConverter : ITypeConverter<
            //    Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_bags_list.pallet.EnumEvent, Domain.Contracts.Secondary.Pallet.BagsList.Enums.EnumEvent>

            //{
            //    public Domain.Contracts.Secondary.Pallet.BagsList.Enums.EnumEvent Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_bags_list.pallet.EnumEvent source, Domain.Contracts.Secondary.Pallet.BagsList.Enums.EnumEvent destination, ResolutionContext context)
            //    {
            //        var x = new BaseEnumExtConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_bags_list.pallet.Event, BaseTuple<AccountId32, U64, U64>, BaseTuple<AccountId32, U64>, Domain.Contracts.Secondary.Pallet.BagsList.Enums.Event, BaseTuple<SubstrateAccount, U64, U64>, BaseTuple<SubstrateAccount, U64>>();
            //        var res = x.Convert(source, destination, context);

            //        destination.Create(res.Bytes);
            //        return destination;
            //        //destination = new Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.BagsList.Enums.EnumEvent();
            //        //if (source == null) return destination;

            //        ////destination.Create(context.Mapper.Map<D0>(source.Value), context.Mapper.Map<D1>(source.Value2));
            //        //return destination;
            //    }
            //}

            public class BaseEnumConverter<I0, D0> : ITypeConverter<BaseEnum<I0>, BaseEnum<D0>>
                where I0 : Enum
                where D0 : struct, Enum
            {
                public BaseEnum<D0> Convert(BaseEnum<I0> source, BaseEnum<D0> destination, ResolutionContext context)
                {
                    destination = new BaseEnum<D0>();
                    if (source == null) return destination;

                    return (BaseEnum<D0>)MapEnumInternal(source, typeof(BaseEnum<D0>));
                }
            }

            public class BaseEnumExtConverter<I0, I1, D0, D1> : ITypeConverter<BaseEnumExt<I0, I1>, BaseEnumExt<D0, D1>>
                where I0 : Enum
                where I1 : IType, new()
                where D0 : Enum
                where D1 : IType, new()
            {
                public BaseEnumExt<D0, D1> Convert(BaseEnumExt<I0, I1> source, BaseEnumExt<D0, D1> destination, ResolutionContext context)
                {
                    destination = new BaseEnumExt<D0, D1>();
                    if (source == null) return destination;

                    destination.Create(context.Mapper.Map<D0>(source.Value), context.Mapper.Map<D1>(source.Value2));
                    return destination;
                }
            }

            public class BaseEnumExtConverter<I0, I1, I2, D0, D1, D2> :
                ITypeConverter<BaseEnumExt<I0, I1, I2>, BaseEnumExt<D0, D1, D2>>
                where I0 : Enum
                where I1 : IType, new()
                where I2 : IType, new()
                where D0 : Enum
                where D1 : IType, new()
                where D2 : IType, new()
            {
                public BaseEnumExt<D0, D1, D2> Convert(BaseEnumExt<I0, I1, I2> source, BaseEnumExt<D0, D1, D2> destination, ResolutionContext context)
                {
                    destination = new BaseEnumExt<D0, D1, D2>();
                    if (source == null) return destination;

                    destination.Create(context.Mapper.Map<D0>(source.Value), context.Mapper.Map<D1>(source.Value2));
                    return destination;
                }
            }

            public class BaseEnumExtConverter<
                T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10,
                D0, D1, D2, D3, D4, D5, D6, D7, D8, D9, D10>
            where T0 : Enum
            where T1 : IType, new()
            where T2 : IType, new()
            where T3 : IType, new()
            where T4 : IType, new()
            where T5 : IType, new()
            where T6 : IType, new()
            where T7 : IType, new()
            where T8 : IType, new()
            where T9 : IType, new()
            where T10 : IType, new()
            where D0 : Enum
            where D1 : IType, new()
            where D2 : IType, new()
            where D3 : IType, new()
            where D4 : IType, new()
            where D5 : IType, new()
            where D6 : IType, new()
            where D7 : IType, new()
            where D8 : IType, new()
            where D9 : IType, new()
            where D10 : IType, new()
            {
                public BaseEnumExt<D0, D1, D2, D3, D4, D5, D6, D7, D8, D9, D10> Convert(
                    BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> source,
                    BaseEnumExt<D0, D1, D2, D3, D4, D5, D6, D7, D8, D9, D10> destination,
                    ResolutionContext context)
                {
                    destination = new BaseEnumExt<D0, D1, D2, D3, D4, D5, D6, D7, D8, D9, D10>();
                    if (source == null) return destination;

                    destination.Create(context.Mapper.Map<D0>(source.Value), context.Mapper.Map<D1>(source.Value2));
                    return destination;
                }
            }
        }

        public class NameableProfile : Profile
        {
            public NameableProfile()
            {
                CreateMap<Arr0U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr1U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr2U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr3U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr4U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr5U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr6U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr7U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr8U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr9U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr10U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr11U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr12U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr13U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr14U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr15U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr16U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr17U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr18U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr19U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr20U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr21U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr22U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr23U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr24U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr25U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr26U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr27U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr28U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr29U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr30U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr31U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr32U8, FlexibleNameable>().ConvertUsing(new NameableConverter());

                CreateMap<BaseVec<U8>, FlexibleNameable>().ConvertUsing(x => new FlexibleNameable().FromU8(x.Value));

                CreateMap<Arr32U8, Hexa>().ConvertUsing(x => new Hexa(x));

                CreateMap<Arr1U8, NameableSize1>().ConvertUsing(x => new NameableSize1(x));
                CreateMap<Arr2U8, NameableSize2>().ConvertUsing(x => new NameableSize2(x));
                CreateMap<Arr3U8, NameableSize3>().ConvertUsing(x => new NameableSize3(x));
                CreateMap<Arr4U8, NameableSize4>().ConvertUsing(x => new NameableSize4(x));
                CreateMap<Arr5U8, NameableSize5>().ConvertUsing(x => new NameableSize5(x));
                CreateMap<Arr6U8, NameableSize6>().ConvertUsing(x => new NameableSize6(x));
                CreateMap<Arr7U8, NameableSize7>().ConvertUsing(x => new NameableSize7(x));
                CreateMap<Arr8U8, NameableSize8>().ConvertUsing(x => new NameableSize8(x));
                CreateMap<Arr9U8, NameableSize9>().ConvertUsing(x => new NameableSize9(x));
                CreateMap<Arr10U8, NameableSize10>().ConvertUsing(x => new NameableSize10(x));
                CreateMap<Arr11U8, NameableSize11>().ConvertUsing(x => new NameableSize11(x));
                CreateMap<Arr12U8, NameableSize12>().ConvertUsing(x => new NameableSize12(x));
                CreateMap<Arr13U8, NameableSize13>().ConvertUsing(x => new NameableSize13(x));
                CreateMap<Arr14U8, NameableSize14>().ConvertUsing(x => new NameableSize14(x));
                CreateMap<Arr15U8, NameableSize15>().ConvertUsing(x => new NameableSize15(x));
                CreateMap<Arr16U8, NameableSize16>().ConvertUsing(x => new NameableSize16(x));
                CreateMap<Arr17U8, NameableSize17>().ConvertUsing(x => new NameableSize17(x));
                CreateMap<Arr18U8, NameableSize18>().ConvertUsing(x => new NameableSize18(x));
                CreateMap<Arr19U8, NameableSize19>().ConvertUsing(x => new NameableSize19(x));
                CreateMap<Arr20U8, NameableSize20>().ConvertUsing(x => new NameableSize20(x));
                CreateMap<Arr21U8, NameableSize21>().ConvertUsing(x => new NameableSize21(x));
                CreateMap<Arr22U8, NameableSize22>().ConvertUsing(x => new NameableSize22(x));
                CreateMap<Arr23U8, NameableSize23>().ConvertUsing(x => new NameableSize23(x));
                CreateMap<Arr24U8, NameableSize24>().ConvertUsing(x => new NameableSize24(x));
                CreateMap<Arr25U8, NameableSize25>().ConvertUsing(x => new NameableSize25(x));
                CreateMap<Arr26U8, NameableSize26>().ConvertUsing(x => new NameableSize26(x));
                CreateMap<Arr27U8, NameableSize27>().ConvertUsing(x => new NameableSize27(x));
                CreateMap<Arr28U8, NameableSize28>().ConvertUsing(x => new NameableSize28(x));
                CreateMap<Arr29U8, NameableSize29>().ConvertUsing(x => new NameableSize29(x));
                CreateMap<Arr30U8, NameableSize30>().ConvertUsing(x => new NameableSize30(x));
                CreateMap<Arr31U8, NameableSize31>().ConvertUsing(x => new NameableSize31(x));
                CreateMap<Arr32U8, NameableSize32>().ConvertUsing(x => new NameableSize32(x));

            }
        }

        public class AuthorshipStorageProfile : Profile
        {
            public AuthorshipStorageProfile()
            {
                CreateMap<IBaseEnum, Contracts.Pallet.Authorship.Enums.EnumUncleEntryItem>().IncludeAllDerived().ConvertUsing(
                    new EnumConverter<Contracts.Pallet.Authorship.Enums.EnumUncleEntryItem>());
            }
        }
        public class AuctionsStorageProfile : Profile
        {
            public AuctionsStorageProfile()
            {
                //CreateMap<Arr36BaseOpt, Winning>().ConvertUsing(typeof(Arr36BaseOptConverter));
            }

            //public class Arr36BaseOptConverter : ITypeConverter<Arr36BaseOpt, Winning>
            //{
            //    public Winning Convert(Arr36BaseOpt source, Winning destination, ResolutionContext context)
            //    {
            //        //BaseOpt<BaseTuple<SubstrateAccount, Domain.Contracts.Core.Id, U128>>[] destination
            //        destination = new Winning();
            //        if (source == null || source.Value == null) return destination;

            //        var conversions = new List<BaseOpt<BaseTuple<SubstrateAccount, Domain.Contracts.Core.Id, U128>>>();
            //        foreach (var item in source.Value)
            //        {
            //            conversions.Add(context.Mapper.Map<
            //                BaseOpt<BaseTuple<AccountId32Base, IdBase, U128>>,
            //                BaseOpt<BaseTuple<SubstrateAccount, Id, U128>>>(item));
            //        }

            //        destination.Create(conversions.ToArray());
            //        return destination;
            //    }
            //}
        }

        public class BalancesStorageProfile : Profile
        {
            public BalancesStorageProfile()
            {
                // Balance lock
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_balances.BalanceLockBase, BalanceLock>().IncludeAllDerived();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_balances.types.BalanceLockBase, BalanceLock>().IncludeAllDerived();


                // Account data
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_balances.AccountDataBase, AccountData>().IncludeAllDerived();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_balances.types.AccountDataBase, AccountData>().IncludeAllDerived();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_balances.types.ExtraFlagsBase, ExtraFlags>().IncludeAllDerived();

                // Events
                CreateMap<IBaseEnum, EnumBalanceStatus>().ConvertUsing(new EnumConverter<EnumBalanceStatus>());
                CreateMap<IBaseEnum, EnumReasons>().ConvertUsing(new EnumConverter<EnumReasons>());
                //CreateMap<IBaseEnum, Contracts.Pallet.Balances.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.Balances.Enums.EnumEvent>());
            }
        }

        public class BabeStorageProfile : Profile
        {
            public BabeStorageProfile()
            {
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_babe.BabeEpochConfigurationBase, BabeEpochConfiguration>().IncludeAllDerived();
                CreateMap<IBaseEnum, EnumNextConfigDescriptor>().ConvertUsing(new EnumConverter<EnumNextConfigDescriptor>());
                CreateMap<IBaseEnum, EnumAllowedSlots>().ConvertUsing(new EnumConverter<EnumAllowedSlots>());
            }

            public class BaseOptHexaConverter : ITypeConverter<IBaseValue, BaseOpt<Hexa>>
            {
                public BaseOpt<Hexa> Convert(IBaseValue source, BaseOpt<Hexa> destination, ResolutionContext context)
                {
                    destination = new BaseOpt<Hexa>();
                    if (source == null) return destination;

                    switch (source)
                    {
                        case BaseOpt<Arr32U8> b:
                            destination = context.Mapper.Map<BaseOpt<Hexa>>(b.Value);
                            return destination;
                        default:
                            throw new MissingMappingException($"IBaseValue -> BaseOpt<Hexa>");
                    }
                }
            }
        }

        public class CrowdloanStorageProfile : Profile
        {
            public CrowdloanStorageProfile()
            {
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_common.crowdloan.FundInfoBase, FundInfo>().IncludeAllDerived().ConvertUsing(new FundInfoConverter());
                CreateMap<IBaseEnum, EnumMultiSigner>().ConvertUsing(new EnumConverter<EnumMultiSigner>());
                CreateMap<IBaseEnum, EnumLastContribution>().ConvertUsing(new EnumConverter<EnumLastContribution>());
            }

            public class FundInfoConverter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_common.crowdloan.FundInfoBase, FundInfo>
            {
                public FundInfo Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_common.crowdloan.FundInfoBase source, FundInfo destination, ResolutionContext context)
                {
                    destination = new FundInfo();
                    if (source == null) return destination;

                    destination.Depositor = context.Mapper.Map<SubstrateAccount>(source.Depositor);

                    destination.Cap = source.Cap;
                    destination.Deposit = source.Deposit;
                    destination.Raised = source.Raised;
                    destination.End = source.End;
                    destination.FirstPeriod = source.FirstPeriod;
                    destination.LastPeriod = source.LastPeriod;
                    destination.TrieIndex = source.TrieIndex;
                    destination.FundIndex = source.FundIndex;

                    destination.Verifier = context.Mapper.Map<BaseOpt<EnumMultiSigner>>(source.Verifier);
                    destination.LastContribution = context.Mapper.Map<EnumLastContribution>(source.LastContribution);

                    return destination;
                }
            }
        }
        public class DemocracyStorageProfile : Profile
        {
            public DemocracyStorageProfile()
            {
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_democracy.types.ReferendumStatus, ReferendumStatus>();
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_democracy.types.EnumReferendumInfo, EnumReferendumInfo>();
                //CreateMap<BoundedVecT13, BaseVec<BaseTuple<U32, EnumAccountVote>>>().ConvertUsing(new BoundedVecT13Converter());
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_democracy.vote.EnumAccountVote, EnumAccountVote>();
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_democracy.types.Delegations, Delegations>();
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_democracy.vote.PriorLock, PriorLock>();
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_democracy.vote.EnumVoting, EnumVoting>();
            }

            //public class BoundedVecT13Converter : ITypeConverter<BoundedVecT13, BaseVec<BaseTuple<U32, EnumAccountVote>>>
            //{
            //    public BaseVec<BaseTuple<U32, EnumAccountVote>> Convert(BoundedVecT13 source, BaseVec<BaseTuple<U32, EnumAccountVote>> destination, ResolutionContext context)
            //    {
            //        destination = new BaseVec<BaseTuple<U32, EnumAccountVote>>();
            //        if (source == null) return destination;

            //        destination = context.Mapper.Map<BaseVec<BaseTuple<U32, EnumAccountVote>>>(source.Value);
            //        return destination;
            //    }
            //}
        }
        public class IdentityStorageProfile : Profile
        {
            public IdentityStorageProfile()
            {
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_identity.types.EnumData, EnumData>();
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_identity.types.EnumJudgement, EnumJudgement>();
                //CreateMap<BoundedVecT2, BaseVec<BaseTuple<EnumData, EnumData>>>().ConvertUsing(new BoundedVecT2Converter());
                //CreateMap<BoundedVecT19, BaseVec<BaseTuple<U32, EnumJudgement>>>().ConvertUsing(new BoundedVecT19Converter());
                //CreateMap<BoundedVecT21, BaseVec<BaseOpt<RegistrarInfo>>>().ConvertUsing(new BoundedVecT21Converter());
                //CreateMap<BoundedVecT20, BaseVec<SubstrateAccount>>().ConvertUsing(new BoundedVecT20Converter());
                //CreateMap<BaseTuple<U128, BoundedVecT20>, SubsOfResult>().ConvertUsing(new SubsOfResultInverseConverter());

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_identity.types.RegistrationBase, Registration>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_identity.types.IdentityInfoBase, IdentityInfo>();
                //.ConvertUsing(new IdentityInfoConverter());
                CreateMap<IBaseEnum, EnumData>().ConvertUsing(new EnumConverter<EnumData>());
                CreateMap<IBaseEnum, EnumJudgement>().ConvertUsing(new EnumConverter<EnumJudgement>());
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_identity.types.RegistrarInfoBase, RegistrarInfo>();
            }

            public class RegistrationConverter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_identity.types.RegistrationBase, Registration>
            {
                public Registration Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_identity.types.RegistrationBase source, Registration destination, ResolutionContext context)
                {
                    destination = new Registration();
                    if (source == null) return destination;

                    destination.Judgements = context.Mapper.Map<BaseVec<BaseTuple<U32, EnumJudgement>>>(source.Judgements);


                    return destination;
                }
            }

            public class IdentityInfoConverter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_identity.types.IdentityInfoBase, IdentityInfo>
            {
                public IdentityInfo Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_identity.types.IdentityInfoBase source, IdentityInfo destination, ResolutionContext context)
                {
                    destination = new IdentityInfo();
                    if (source == null) return destination;

                    destination.Display = (EnumData)MapEnumInternal(source.Display, typeof(EnumData));
                    destination.Legal = (EnumData)MapEnumInternal(source.Legal, typeof(EnumData));
                    destination.Web = (EnumData)MapEnumInternal(source.Web, typeof(EnumData));
                    destination.Riot = (EnumData)MapEnumInternal(source.Riot, typeof(EnumData));
                    destination.Email = (EnumData)MapEnumInternal(source.Email, typeof(EnumData));
                    destination.PgpFingerprint = context.Mapper.Map<BaseOpt<FlexibleNameable>>(source.PgpFingerprint);
                    destination.Twitter = (EnumData)MapEnumInternal(source.Twitter, typeof(EnumData));
                    destination.Image = (EnumData)MapEnumInternal(source.Image, typeof(EnumData));
                    destination.Additional = context.Mapper.Map<BaseVec<BaseTuple<EnumData, EnumData>>>(source.Additional);

                    return destination;
                }
            }

            //BaseTuple<U128, BaseVec<AccountId32>>
            //public class SubsOfResultInverseConverter : ITypeConverter<BaseTuple<U128, BoundedVecT20>, SubsOfResult>
            //{
            //    public SubsOfResult Convert(BaseTuple<U128, BoundedVecT20> source, SubsOfResult destination, ResolutionContext context)
            //    {
            //        destination = new SubsOfResult();
            //        if (source == null) return destination;

            //        destination = new SubsOfResult(
            //            (U128)source.Value[0],
            //            context.Mapper.Map<BoundedVecT20, BaseVec<SubstrateAccount>>((BoundedVecT20)source.Value[1]));

            //        return destination;
            //    }
            //}

            //public class BoundedVecT20Converter : ITypeConverter<BoundedVecT20, BaseVec<SubstrateAccount>>
            //{
            //    public BaseVec<SubstrateAccount> Convert(BoundedVecT20 source, BaseVec<SubstrateAccount> destination, ResolutionContext context)
            //    {
            //        destination = new BaseVec<SubstrateAccount>();
            //        if (source == null) return destination;

            //        destination = context.Mapper.Map<BaseVec<SubstrateAccount>>(source.Value);
            //        return destination;
            //    }
            //}

            //public class BoundedVecT21Converter : ITypeConverter<BoundedVecT21, BaseVec<BaseOpt<RegistrarInfo>>>
            //{
            //    public BaseVec<BaseOpt<RegistrarInfo>> Convert(BoundedVecT21 source, BaseVec<BaseOpt<RegistrarInfo>> destination, ResolutionContext context)
            //    {
            //        destination = new BaseVec<BaseOpt<RegistrarInfo>>();
            //        if (source == null) return destination;

            //        destination = context.Mapper.Map<BaseVec<BaseOpt<RegistrarInfo>>>(source.Value);
            //        return destination;
            //    }
            //}

            //public class BoundedVecT19Converter : ITypeConverter<BoundedVecT19, BaseVec<BaseTuple<U32, EnumJudgement>>>
            //{
            //    public BaseVec<BaseTuple<U32, EnumJudgement>> Convert(BoundedVecT19 source, BaseVec<BaseTuple<U32, EnumJudgement>> destination, ResolutionContext context)
            //    {
            //        destination = new BaseVec<BaseTuple<U32, EnumJudgement>>();
            //        if (source == null) return destination;

            //        destination = context.Mapper.Map<BaseVec<BaseTuple<U32, EnumJudgement>>>(source.Value);
            //        return destination;
            //    }
            //}

            //public class BoundedVecT2Converter : ITypeConverter<BoundedVecT2, BaseVec<BaseTuple<EnumData, EnumData>>>
            //{
            //    public BaseVec<BaseTuple<EnumData, EnumData>> Convert(BoundedVecT2 source, BaseVec<BaseTuple<EnumData, EnumData>> destination, ResolutionContext context)
            //    {
            //        destination = new BaseVec<BaseTuple<EnumData, EnumData>>();
            //        if (source == null) return destination;

            //        destination = context.Mapper.Map<BaseVec<BaseTuple<EnumData, EnumData>>>(source.Value);
            //        return destination;
            //    }
            //}
        }

        public class NominationPoolsStorageProfile : Profile
        {
            public NominationPoolsStorageProfile()
            {
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.BondedPoolInnerBase, BondedPoolInner>().IncludeAllDerived();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.PoolRolesBase, PoolRoles>().IncludeAllDerived();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.CommissionBase, Commission>().IncludeAllDerived();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.CommissionChangeRateBase, CommissionChangeRate>().IncludeAllDerived();
                CreateMap<IBaseEnum, EnumPoolState>().ConvertUsing(new EnumConverter<EnumPoolState>());
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.PoolMemberBase, PoolMember>().IncludeAllDerived();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.fixed_point.FixedU128Base, U128>().IncludeAllDerived().ConvertUsing(x => x.Value);
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.RewardPoolBase, RewardPool>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.SubPoolsBase, SubPools>().IncludeAllDerived();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.UnbondPoolBase, UnbondPool>().IncludeAllDerived();
                //CreateMap<
                //    Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_btree_map.BoundedBTreeMapT2, BaseVec<BaseTuple<U32, UnbondPool>>>().ConvertUsing(new BoundedBTreeMapT2Converter());
            }

            //public class BoundedBTreeMapT2Converter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_btree_map.BoundedBTreeMapT2, BaseVec<BaseTuple<U32, UnbondPool>>>
            //{
            //    public BaseVec<BaseTuple<U32, UnbondPool>> Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_btree_map.BoundedBTreeMapT2 source, BaseVec<BaseTuple<U32, UnbondPool>> destination, ResolutionContext context)
            //    {
            //        destination = new BaseVec<BaseTuple<U32, UnbondPool>>();
            //        if (source == null) return destination;

            //        destination = context.Mapper.Map<BaseVec<BaseTuple<U32, UnbondPool>>>(source.Value.Value);
            //        return destination;
            //    }
            //}
        }

        public class ParaSessionInfoStorageProfile : Profile
        {
            public ParaSessionInfoStorageProfile()
            {
                //CreateMap<BaseVec<
                //        Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.assignment_app.Public>, BaseVec<PublicSr25519>>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.SessionInfoBase, SessionInfo>().IncludeAllDerived();

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.ValidatorIndexBase, U32>().IncludeAllDerived().ConvertUsing(x => x.Value);
                ////CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.validator_app.Public, PublicSr25519>().ConvertUsing(x => new PublicSr25519(x.Value.Value.Value));
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.validator_app.Public, PublicSr25519>().ConvertUsing(x => Instance.Map<
                //    Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.sr25519.Public, PublicSr25519>(x.Value));
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.assignment_app.Public, PublicSr25519>().ConvertUsing(x => Instance.Map<
                //    Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.sr25519.Public, PublicSr25519>(x.Value));
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_authority_discovery.app.Public, PublicSr25519>().ConvertUsing(x => Instance.Map<
                //    Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.sr25519.Public, PublicSr25519>(x.Value));
            }

            //public class IndexedVecT1Converter : ITypeConverter<IndexedVecT1, BaseVec<PublicSr25519>>
            //{
            //    public BaseVec<PublicSr25519> Convert(IndexedVecT1 source, BaseVec<PublicSr25519> destination, ResolutionContext context)
            //    {
            //        destination = new BaseVec<PublicSr25519>();
            //        if (source == null) return destination;

            //        destination = context.Mapper.Map<BaseVec<PublicSr25519>>(source.Value);
            //        return destination;
            //    }
            //}

            //public class IndexedVecT2Converter : ITypeConverter<IndexedVecT2, BaseVec<BaseVec<U32>>>
            //{
            //    public BaseVec<BaseVec<U32>> Convert(IndexedVecT2 source, BaseVec<BaseVec<U32>> destination, ResolutionContext context)
            //    {
            //        destination = new BaseVec<BaseVec<U32>>();
            //        if (source == null) return destination;

            //        destination = context.Mapper.Map<BaseVec<BaseVec<U32>>>(source.Value);
            //        return destination;
            //    }
            //}
        }

        public class PolkadotRuntimeParachain : Profile
        {
            public PolkadotRuntimeParachain()
            {
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.CandidateReceiptBase, CandidateReceipt>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.CandidateDescriptorBase, CandidateDescriptor>();//.ConvertUsing(new CandidateDescriptorBaseConverter());
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.HeadDataBase, HeadData>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.CoreIndexBase, CoreIndex>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.GroupIndexBase, GroupIndex>();
            }

            public class CandidateDescriptorBaseConverter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.CandidateDescriptorBase, CandidateDescriptor>
            {
                public CandidateDescriptor Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.CandidateDescriptorBase source, CandidateDescriptor destination, ResolutionContext context)
                {
                    destination = new CandidateDescriptor();
                    destination.ParaId = context.Mapper.Map<Id>(source.ParaId);
                    destination.RelayParent = context.Mapper.Map<Hash>(source.RelayParent);
                    destination.PersistedValidationDataHash = context.Mapper.Map<Hash>(source.PersistedValidationDataHash);
                    destination.ErasureRoot = context.Mapper.Map<Hash>(source.ErasureRoot);
                    destination.PovHash = context.Mapper.Map<Hash>(source.PovHash);
                    destination.ParaHead = context.Mapper.Map<Hash>(source.ParaHead);
                    destination.ValidationCodeHash = context.Mapper.Map<Hash>(source.ValidationCodeHash);

                    destination.Collator = context.Mapper.Map<PublicSr25519>(source.Collator);
                    destination.Signature = context.Mapper.Map<SignatureSr25519>(source.Signature);
                    return destination;
                }
            }
        }

        public class ParachainStorageProfile : Profile
        {
            public ParachainStorageProfile()
            {
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.IdBase, Id>().IncludeAllDerived().ConvertUsing(new IdBaseConverter());
                CreateMap<Id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.IdBase>().ConvertUsing(new IdConverter());

                //CreateMap<ValidationCode, Hexa>().ConvertUsing(x => new Hexa(x)); // TODO Inverse
                //CreateMap<HeadData, Hexa>().ConvertUsing(x => new Hexa(x)); // TODO Inverse
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.HeadDataBase, DataCode>().ConvertUsing(x => new DataCode((BaseVec<U8>)x.Value));

                CreateMap<
                    Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.paras.ParaPastCodeMetaBase, ParaPastCodeMeta>();
                CreateMap<
                    Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.paras.ReplacementTimesBase, ReplacementTimes>();


                //CreateMap<ValidationCode, DataCode>().ConvertUsing(x => new DataCode(x.Value));
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.paras.ParaGenesisArgs, ParaGenesisArgs>();

                CreateMap<IBaseEnum, EnumParaLifecycle>().ConvertUsing(new EnumConverter<EnumParaLifecycle>());
                CreateMap<IBaseEnum, EnumUpgradeGoAhead>().ConvertUsing(new EnumConverter<EnumUpgradeGoAhead>());
                CreateMap<IBaseEnum, EnumUpgradeRestriction>().ConvertUsing(new EnumConverter<EnumUpgradeRestriction>());
            }

            public class IdBaseConverter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.IdBase, Id>
            {
                public Id Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.IdBase source, Id destination, ResolutionContext context)
                {
                    destination = new Id(source.Value);
                    return destination;
                }
            }

            public class IdConverter : ITypeConverter<Id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.IdBase>
            {
                public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.IdBase Convert(Id source, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.IdBase destination, ResolutionContext context)
                {
                    if (!context.Items.ContainsKey("version"))
                        throw new SpecVersionMissingException("Version is missing while mapping Id to IdBase");

                    destination = Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.IdBase.Create(source.Bytes ?? source.Encode(), (uint)context.Items["version"]);

                    return destination;
                }
            }
        }

        public class RegistarStorageProfile : Profile
        {
            public RegistarStorageProfile()
            {
                CreateMap<
                    Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_common.paras_registrar.ParaInfoBase, ParaInfo>().IncludeAllDerived();
            }
        }

        public class SessionStorageProfile : Profile
        {
            public SessionStorageProfile()
            {
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.KeyTypeIdBase, FlexibleNameable>().ConvertUsing(new KeyTypeIdConverter());
                CreateMap<FlexibleNameable, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.KeyTypeIdBase>().ConvertUsing(new KeyTypeIdReverseConverter());
                CreateMap<Hexa, BaseVec<U8>>().ConvertUsing(x => new BaseVec<U8>(x.Value));
                ////CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.SessionKeys, SessionKeysPolka>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime.SessionKeysBase, SessionKeysPolka>().ConvertUsing(new SessionKeyConverter());
            }

            public class SessionKeyConverter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime.SessionKeysBase, SessionKeysPolka>
            {
                public SessionKeysPolka Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime.SessionKeysBase source, SessionKeysPolka destination, ResolutionContext context)
                {
                    destination = new SessionKeysPolka();
                    if (source == null) return destination;

                    PublicEd25519? grandPa = null;
                    if (source.Grandpa is not null)
                        grandPa = context.Mapper.Map<PublicEd25519>(source.Grandpa);
                    else if (source.Grandpa1 is not null)
                        grandPa = context.Mapper.Map<PublicEd25519>(source.Grandpa1);
                    else
                        throw new InvalidMappingException("Error while getting GrandPa value from SessionKeys storage");

                    PublicSr25519? paraValidator = null;
                    if (source.ParaValidator is not null)
                        paraValidator = context.Mapper.Map<PublicSr25519>(source.ParaValidator);
                    else if (source.ParaValidator1 is not null)
                        paraValidator = context.Mapper.Map<PublicSr25519>(source.ParaValidator1);
                    else if (source.ParaValidator2 is not null)
                        paraValidator = context.Mapper.Map<PublicSr25519>(source.ParaValidator2);
                    else
                        throw new InvalidMappingException("Error while getting ParaValidator value from SessionKeys storage");

                    PublicSr25519? paraAssignment = null;
                    if (source.ParaAssignment is not null)
                        paraAssignment = context.Mapper.Map<PublicSr25519>(source.ParaAssignment);
                    else if (source.ParaAssignment1 is not null)
                        paraAssignment = context.Mapper.Map<PublicSr25519>(source.ParaAssignment1);
                    else if (source.ParaAssignment2 is not null)
                        paraAssignment = context.Mapper.Map<PublicSr25519>(source.ParaAssignment2);
                    else
                        throw new InvalidMappingException("Error while getting ParaAssignment value from SessionKeys storage");

                    var babe = context.Mapper.Map<PublicSr25519>(source.Babe);
                    var imOnline = context.Mapper.Map<PublicSr25519>(source.ImOnline);
                    var authorityDiscovery = context.Mapper.Map<PublicSr25519>(source.AuthorityDiscovery);

                    destination = new SessionKeysPolka(grandPa, babe, imOnline, paraValidator, paraAssignment, authorityDiscovery);
                    return destination;
                }
            }

            public class KeyTypeIdConverter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.KeyTypeIdBase, FlexibleNameable>
            {
                public FlexibleNameable Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.KeyTypeIdBase source, FlexibleNameable destination, ResolutionContext context)
                {
                    destination = new FlexibleNameable();
                    if (source == null) return destination;

                    context.Mapper.Map<FlexibleNameable>(source.Value);
                    return destination;
                }
            }

            public class KeyTypeIdReverseConverter : ITypeConverter<FlexibleNameable, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.KeyTypeIdBase>
            {
                public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.KeyTypeIdBase Convert(FlexibleNameable source, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.KeyTypeIdBase destination, ResolutionContext context)
                {
                    if (!context.Items.ContainsKey("version"))
                        throw new SpecVersionMissingException("Version is missing while mapping FlexibleNameable to KeyTypeIdBase");

                    destination = Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.KeyTypeIdBase.Create(source.Bytes ?? source.Encode(), (uint)context.Items["version"]);
                    return destination;
                }
            }
        }

        public class SchedulerStorageProfile : Profile
        {
            public SchedulerStorageProfile()
            {
                //CreateMap<BoundedVecT1, Hash>().ConvertUsing(new BoundedVecT1Converter());
            }
        }

        public class SystemStorageProfile : Profile
        {
            public SystemStorageProfile()
            {
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_system.AccountInfoBase, AccountInfo>().ConvertUsing(new AccountInfoConverter());
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_support.dispatch.PerDispatchClassT1Base, FrameSupportDispatchPerDispatchClassWeight>().IncludeAllDerived().ConvertUsing(new PerDispatchClassT1Converter());
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_weights.weight_v2.WeightBase, Weight>().IncludeAllDerived().ConvertUsing(new WeightConverter());
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_runtime.generic.digest.DigestBase, Digest>();
                CreateMap<IBaseEnum, EnumDigestItem>().ConvertUsing(new EnumConverter<EnumDigestItem>());
                CreateMap<IBaseEnum, EnumPhase>().ConvertUsing(new EnumConverter<EnumPhase>());
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_system.EventRecordBase, EventRecord>().ConvertUsing(new EventRecordConverter());
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_support.dispatch.DispatchInfoBase, DispatchInfo>();
                ////CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeEvent, EnumRuntimeEvent>().ForMember(o => o.Value2, m => m.MapFrom(s => s.Value2));
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeEvent, EnumRuntimeEvent>();

                ////CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeEvent, EnumRuntimeEvent>().ConvertUsing(typeof(BaseEnumExtConverter<,,,>));

                ////CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_balances.pallet.EnumEvent, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.EnumEvent>().ConvertUsing((s, d) =>
                ////{
                ////    d = new();
                ////    d.Value = Instance.Map<Domain.Contracts.Secondary.Pallet.Balances.Enums.Event>(s.Value);
                ////    d.Value2 = Instance.Map<BaseTuple<SubstrateAccount, U128>>(s.Value2);

                ////    return d;
                ////});
                ////CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_balances.pallet.EnumEvent, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.EnumEvent>().ConvertUsing(typeof(BaseEnumExtConverter<,,,,,,,,,,,,,,,,,,,,,>));

                ////CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_balances.pallet.EnumEvent, Domain.Contracts.Secondary.Pallet.Balances.Enums.EnumEvent>().ConvertUsing(typeof(BaseEnumTypeConverter));

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_system.LastRuntimeUpgradeInfoBase, LastRuntimeUpgradeInfo>();
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.EventRecord, EventRecord>().ConvertUsing(typeof(EventRecordConverter));
            }

            public class EventRecordConverter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_system.EventRecordBase, EventRecord>
            {
                public EventRecord Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_system.EventRecordBase source, EventRecord destination, ResolutionContext context)
                {
                    destination = new EventRecord();
                    if (source == null) return destination;

                    EnumRuntimeEvent? mappedEvents = null;
                    if (source.Event is not null)
                        mappedEvents = (EnumRuntimeEvent)MapEnumInternal(source.Event, typeof(EnumRuntimeEvent), context);
                    else if (source.Event1 is not null)
                        mappedEvents = (EnumRuntimeEvent)MapEnumInternal(source.Event1, typeof(EnumRuntimeEvent), context);
                    else
                        throw new InvalidMappingException("Error while getting Events value from EventRecord storage");

                    var mappedPhase = context.Mapper.Map<EnumPhase>(source.Phase);
                    //(EnumPhase)MapEnumInternal(source.Phase, typeof(EnumPhase));
                    var mappedTopics = context.Mapper.Map<BaseVec<Hash>>(source.Topics);

                    destination = new EventRecord(mappedPhase, mappedEvents, mappedTopics);

                    return destination;
                }
            }

            public class AccountInfoConverter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_system.AccountInfoBase, AccountInfo>
            {
                public AccountInfo Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_system.AccountInfoBase source, AccountInfo destination, ResolutionContext context)
                {
                    destination = new AccountInfo();
                    if (source == null) return destination;


                    destination.Nonce = source.Nonce;
                    destination.Consumers = source.Consumers;
                    destination.Providers = source.Providers;
                    destination.Sufficients = source.Sufficients;

                    if(source.Data is not null)
                        destination.Data = context.Mapper.Map<AccountData>(source.Data);
                    else if(source.Data1 is not null)
                        destination.Data = context.Mapper.Map<AccountData>(source.Data1);
                    else
                        throw new InvalidMappingException("Error while getting Data value from AccountInfo storage");

                    return destination;
                }
            }

            public class PerDispatchClassT1Converter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_support.dispatch.PerDispatchClassT1Base, FrameSupportDispatchPerDispatchClassWeight>
            {
                public FrameSupportDispatchPerDispatchClassWeight Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_support.dispatch.PerDispatchClassT1Base source, FrameSupportDispatchPerDispatchClassWeight destination, ResolutionContext context)
                {
                    destination = new FrameSupportDispatchPerDispatchClassWeight();
                    if (source == null) return destination;

                    destination.Normal = context.Mapper.Map<Weight>(source.Normal);
                    destination.Operational = context.Mapper.Map<Weight>(source.Operational);
                    destination.Mandatory = context.Mapper.Map<Weight>(source.Mandatory);

                    return destination;
                }
            }

            public class WeightConverter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_weights.weight_v2.WeightBase, Weight>
            {
                public Weight Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_weights.weight_v2.WeightBase source, Weight destination, ResolutionContext context)
                {
                    destination = new Weight();
                    if (source == null) return destination;

                    destination.ProofSize = context.Mapper.Map<BaseCom<U64>>(source.ProofSize);

                    if (source.RefTime is not null)
                        destination.RefTime = context.Mapper.Map<BaseCom<U64>>(source.RefTime);
                    else if (source.RefTime1 is not null)
                        destination.RefTime = context.Mapper.Map<BaseCom<U64>>(source.RefTime1);

                    return destination;
                }
            }
        }

        public class StakingStorageProfile : Profile
        {
            public StakingStorageProfile()
            {
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_arithmetic.per_things.Perbill, Perbill>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.per_things.PercentBase, Percent>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.EraRewardPointsBase, EraRewardPoints>();
                //CreateMap<BTreeMapT1, BaseVec<BaseTuple<SubstrateAccount, U32>>>().ConvertUsing(new BTreeMapT1Converter());
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.ExposureBase, Exposure>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.IndividualExposureBase, IndividualExposure>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.ValidatorPrefsBase, ValidatorPrefs>().IncludeAllDerived();
                CreateMap<IBaseEnum, EnumForcing>().ConvertUsing(new EnumConverter<EnumForcing>());
                CreateMap<IBaseEnum, EnumRewardDestination>().ConvertUsing(new EnumConverter<EnumRewardDestination>());
                CreateMap<IBaseEnum, Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums.EnumReleases>().ConvertUsing(new EnumConverter<Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums.EnumReleases>());
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.StakingLedger, StakingLedger>();
                //CreateMap<BoundedVecT8, BaseVec<UnlockChunk>>().ConvertUsing(new BoundedVecT8Converter());
                //CreateMap<BoundedVecT10, BaseVec<SubstrateAccount>>().ConvertUsing(new BoundedVecT10Converter());
                //CreateMap<BoundedVecT9, BaseVec<U32>>().ConvertUsing(x => x.Value);
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.UnlockChunk, UnlockChunk>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.NominationsBase, Nominations>();
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.EnumRewardDestination, EnumRewardDestination>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.slashing.SlashingSpansBase, SlashingSpans>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.slashing.SpanRecordBase, SpanRecord>();
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.EnumReleases, Domain.Contracts.Secondary.Pallet.Staking.Enums.EnumReleases>();
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.UnappliedSlash, UnappliedSlash>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.ActiveEraInfoBase, ActiveEraInfo>().IncludeAllDerived();
            }
        }

        public class XcmStorageProfile : Profile
        {
            public XcmStorageProfile()
            {
                //CreateMap<DoubleEncodedT2, BaseVec<U8>>().ConvertUsing(x => x.Encoded);
            }
        }

        public class SubstrateAccountConverter : ITypeConverter<SubstrateAccount, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base>
        {
            public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base Convert(SubstrateAccount source, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base destination, ResolutionContext context)
            {
                if (!context.Items.ContainsKey("version"))
                    throw new SpecVersionMissingException("Version is missing while mapping SubstrateAccount to AccountId32Base");

                destination = Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base.Create(source.Bytes ?? source.Encode(), (uint)context.Items["version"]);
                return destination;
            }
        }

        public class AccountId32Converter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base, SubstrateAccount>
        {
            public SubstrateAccount Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base source, SubstrateAccount destination, ResolutionContext context)
            {
                destination = new SubstrateAccount();
                if (source is null || source.Value is null) return destination;

                destination = new SubstrateAccount(source.Value.Value);

                return destination;
            }
        }

        //public class Arr8U8Converter : ITypeConverter<Arr8U8, string>
        //{
        //    public string Convert(Arr8U8 source, string destination, ResolutionContext context)
        //    {
        //        return source.ToString();
        //    }
        //}

        public class NameableConverter : ITypeConverter<BaseType, FlexibleNameable>
        {
            public FlexibleNameable Convert(BaseType source, FlexibleNameable destination, ResolutionContext context)
            {
                return new FlexibleNameable(source);
            }
        }

        //public class NameableSizeConverter : ITypeConverter<BaseType, Nameable>
        //{
        //    public Nameable Convert(BaseType source, Nameable destination, ResolutionContext context)
        //    {

        //    }
        //}

        public class BaseTupleConverter<I1, I2, O1, O2> : ITypeConverter<BaseTuple<I1, I2>, BaseTuple<O1, O2>>
        where I1 : IType, new()
        where I2 : IType, new()
        where O1 : IType, new()
        where O2 : IType, new()
        {
            public BaseTuple<O1, O2> Convert(BaseTuple<I1, I2> source, BaseTuple<O1, O2> destination, ResolutionContext context)
            {
                destination = new BaseTuple<O1, O2>();

                if (source == null || source.Value == null) return destination;

                var first = context.Mapper.Map<I1, O1>((I1)source.Value[0]);


                var second = context.Mapper.Map<I2, O2>((I2)source.Value[1]);
                destination.Create(first, second);

                return destination;
            }
        }

        public class BaseTupleConverter<I1, I2, I3, O1, O2, O3> : ITypeConverter<BaseTuple<I1, I2, I3>, BaseTuple<O1, O2, O3>>
        where I1 : IType, new()
        where I2 : IType, new()
        where I3 : IType, new()
        where O1 : IType, new()
        where O2 : IType, new()
        where O3 : IType, new()
        {
            public BaseTuple<O1, O2, O3> Convert(BaseTuple<I1, I2, I3> source, BaseTuple<O1, O2, O3> destination, ResolutionContext context)
            {
                destination = new BaseTuple<O1, O2, O3>();

                if (source == null) return destination;

                var first = context.Mapper.Map<I1, O1>((I1)source.Value[0]);
                var second = context.Mapper.Map<I2, O2>((I2)source.Value[1]);
                var third = context.Mapper.Map<I3, O3>((I3)source.Value[2]);
                destination.Create(first, second, third);

                return destination;
            }
        }

        public class BaseTupleConverter<I1, I2, I3, I4, O1, O2, O3, O4> : ITypeConverter<BaseTuple<I1, I2, I3, I4>, BaseTuple<O1, O2, O3, O4>>
        where I1 : IType, new()
        where I2 : IType, new()
        where I3 : IType, new()
        where I4 : IType, new()
        where O1 : IType, new()
        where O2 : IType, new()
        where O3 : IType, new()
        where O4 : IType, new()
        {
            public BaseTuple<O1, O2, O3, O4> Convert(BaseTuple<I1, I2, I3, I4> source, BaseTuple<O1, O2, O3, O4> destination, ResolutionContext context)
            {
                destination = new BaseTuple<O1, O2, O3, O4>();

                if (source == null) return destination;

                var first = context.Mapper.Map<I1, O1>((I1)source.Value[0]);
                var second = context.Mapper.Map<I2, O2>((I2)source.Value[1]);
                var third = context.Mapper.Map<I3, O3>((I3)source.Value[2]);
                var fourth = context.Mapper.Map<I4, O4>((I4)source.Value[3]);
                destination.Create(first, second, third, fourth);

                return destination;
            }
        }

        public class BaseTupleConverter<I1, I2, I3, I4, I5, O1, O2, O3, O4, O5> : ITypeConverter<BaseTuple<I1, I2, I3, I4, I5>, BaseTuple<O1, O2, O3, O4, O5>>
        where I1 : IType, new()
        where I2 : IType, new()
        where I3 : IType, new()
        where I4 : IType, new()
        where I5 : IType, new()
        where O1 : IType, new()
        where O2 : IType, new()
        where O3 : IType, new()
        where O4 : IType, new()
        where O5 : IType, new()
        {
            public BaseTuple<O1, O2, O3, O4, O5> Convert(BaseTuple<I1, I2, I3, I4, I5> source, BaseTuple<O1, O2, O3, O4, O5> destination, ResolutionContext context)
            {
                destination = new BaseTuple<O1, O2, O3, O4, O5>();

                if (source == null) return destination;

                var first = context.Mapper.Map<I1, O1>((I1)source.Value[0]);
                var second = context.Mapper.Map<I2, O2>((I2)source.Value[1]);
                var third = context.Mapper.Map<I3, O3>((I3)source.Value[2]);
                var fourth = context.Mapper.Map<I4, O4>((I4)source.Value[3]);
                var fifth = context.Mapper.Map<I5, O5>((I5)source.Value[4]);
                destination.Create(first, second, third, fourth, fifth);

                return destination;
            }
        }

        public class BaseEnumerableConverter<T> : ITypeConverter<IBaseEnumerable, BaseVec<T>>
        where T : IType, new()
        {
            public BaseVec<T> Convert(IBaseEnumerable source, BaseVec<T> destination, ResolutionContext context)
            {
                destination = new BaseVec<T>();

                if (source.GetValues() is null || !source.GetValues().Any()) return destination;

                //if (!source.GetValues().All(x => x is T))
                //    throw new InvalidCastException();

                IList<T> list = new List<T>();

                foreach (var val in source.GetValues())
                {
                    list.Add(context.Mapper.Map<T>(val));
                }

                destination.Create(list.ToArray());

                return destination;
            }
        }

        public class BaseVecConverter<T1, T2> : ITypeConverter<BaseVec<T1>, BaseVec<T2>>
        where T1 : IType, new()
        where T2 : IType, new()
        {
            public BaseVec<T2> Convert(BaseVec<T1> source, BaseVec<T2> destination, ResolutionContext context)
            {
                destination = new BaseVec<T2>();

                if (source.Value == null) return destination;
                IList<T2> list = new List<T2>();

                foreach (var val in source.Value)
                {
                    list.Add(context.Mapper.Map<T1, T2>(val));
                }

                destination.Create(list.ToArray());

                return destination;
            }
        }

        public class TupleConverter<T1, T2> : ITypeConverter<BaseTuple<T1, T2>, (T1, T2)>
            where T1 : IType, new()
            where T2 : IType, new()
        {
            public (T1, T2) Convert(BaseTuple<T1, T2> source, (T1, T2) destination, ResolutionContext context)
            {
                return ((T1)source.Value[0], (T2)source.Value[1]);
            }
        }

        public class TupleConverter<T1, T2, T3> : ITypeConverter<BaseTuple<T1, T2, T3>, (T1, T2, T3)>
            where T1 : IType, new()
            where T2 : IType, new()
            where T3 : IType, new()
        {
            public (T1, T2, T3) Convert(BaseTuple<T1, T2, T3> source, (T1, T2, T3) destination, ResolutionContext context)
            {
                return ((T1)source.Value[0], (T2)source.Value[1], (T3)source.Value[2]);
            }
        }

        public class BaseOptNullConverter<T> : ITypeConverter<BaseOpt<T>, T?>
            where T : IType, new()
        {
            public T? Convert(BaseOpt<T> source, T? destination, ResolutionContext context)
            {
                if (!source.OptionFlag)
                    return default;

                return source.Value;
            }
        }

        public class BaseOptConverter<T1, T2> : ITypeConverter<BaseOpt<T1>, BaseOpt<T2>>
            where T1 : IType, new()
            where T2 : IType, new()
        {
            public BaseOpt<T2> Convert(BaseOpt<T1> source, BaseOpt<T2> destination, ResolutionContext context)
            {
                destination = new BaseOpt<T2>();
                if (source == null || !source.OptionFlag) return destination;

                destination.Create(context.Mapper.Map<T1, T2>(source.Value));
                return destination;
            }
        }

        public class H256Converter : ITypeConverter<H256Base, Hash>
        {
            public Hash Convert(H256Base source, Hash destination, ResolutionContext context)
            {
                destination = new Hash();
                destination.Create(Utils.Bytes2HexString(source.Value.Encode()));

                return destination;
            }
        }

        public class HashConverter : ITypeConverter<Hash, H256Base>
        {
            public H256Base Convert(Hash source, H256Base destination, ResolutionContext context)
            {
                if (!context.Items.ContainsKey("version"))
                    throw new SpecVersionMissingException("Version is missing while mapping Hash to H256Base");

                destination = H256Base.Create(source.Bytes ?? source.Encode(), (uint)context.Items["version"]);
                return destination;
            }
        }

        public class ValidationCodeHashConverter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.ValidationCodeHashBase, Hash>
        {
            public Hash Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.ValidationCodeHashBase source, Hash destination, ResolutionContext context)
            {
                destination = new Hash();
                if (source == null) return destination;

                destination = context.Mapper.Map<H256Base, Hash>(source.Value);
                return destination;
            }
        }

        public class HashToValidationCodeConverter : ITypeConverter<Hash, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.ValidationCodeHashBase>
        {
            public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.ValidationCodeHashBase Convert(Hash source, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.ValidationCodeHashBase destination, ResolutionContext context)
            {
                if (!context.Items.ContainsKey("version"))
                    throw new SpecVersionMissingException("Version is missing while mapping Hash to ValidationCodeHashBase");

                destination = Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.ValidationCodeHashBase.Create(source.Bytes ?? source.Encode(), (uint)context.Items["version"]);

                return destination;
            }
        }

        public class EnumConverter<T> : ITypeConverter<IBaseEnum, T>
            where T : IType, new()
        {
            public T Convert(IBaseEnum source, T destination, ResolutionContext context)
            {
                return (T)MapEnumInternal(source, typeof(T), context);
            }
        }
    }
}
