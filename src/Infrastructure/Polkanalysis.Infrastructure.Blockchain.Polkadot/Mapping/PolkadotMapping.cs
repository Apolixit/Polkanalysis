using AutoMapper;
using Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Babe;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.primitive_types;
using Polkanalysis.Infrastructure.Blockchain.Exceptions;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Sp;
using Microsoft.Extensions.Logging;
using Substrate.NET.Utils;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Crowdloan;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ParaSessionInfo;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Paras;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Registrar;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Session;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Auctions;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_common.paras_registrar;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Babe.Enums;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_balances.types;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums;
using Polkanalysis.Infrastructure.Blockchain.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.DispatchInfo;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Public;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Random;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Empty;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Multi;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Signature;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Error;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping
{
    public class PolkadotMapping : CommonMapping
    {
        public IConfigurationProvider ConfigurationProvider => _mapper.ConfigurationProvider;

        public PolkadotMapping(ILogger<PolkadotMapping> logger) : base(logger)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BaseTypeProfile>();
                cfg.AddProfile<PolkadotBaseTypeProfile>();
                cfg.AddProfile<CommonProfile>();
                cfg.AddProfile<EnumProfile>();
                cfg.AddProfile<BytesProfile>();
                cfg.AddProfile<AuctionsStorageProfile>();
                cfg.AddProfile<AuthorshipStorageProfile>();
                cfg.AddProfile<BabeStorageProfile>();
                cfg.AddProfile<BalancesStorageProfile>();
                cfg.AddProfile<CrowdloanStorageProfile>();
                cfg.AddProfile<ConvictionStorageProfile>();
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

                //cfg.ConstructServicesUsing(type => provider.GetService(type));
            });

            _mapper = mapperConfig.CreateMapper();
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
                //CreateMap<IType, Contracts.Pallet.Balances.Enums.EnumEvent>().IncludeAllDerived().ConvertUsing(
                //    new EnumConverter<Contracts.Pallet.Balances.Enums.EnumEvent>());
                //CreateMap<IType, Contracts.Pallet.Balances.Enums.EnumError>().IncludeAllDerived().ConvertUsing(
                //    new EnumConverter<Contracts.Pallet.Balances.Enums.EnumError>());

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base, SubstrateAccount>().IncludeAllDerived().ConvertUsing(new AccountId32Converter());
                CreateMap<SubstrateAccount, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base>().IncludeAllDerived().ConvertUsing(new SubstrateAccountConverter());

                CreateMap<H256Base, Hash>().ConvertUsing(new H256Converter());
                CreateMap<Hash, H256Base>().ConvertUsing(new HashConverter());

                CreateMap<
                    Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain_primitives.primitives.ValidationCodeHashBase, Hash>().IncludeAllDerived().ConvertUsing(new ValidationCodeHashConverter2());
                CreateMap<
                    Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.ValidationCodeHashBase, Hash>().IncludeAllDerived().ConvertUsing(new ValidationCodeHashConverter());

                CreateMap<Hash, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.ValidationCodeHashBase>().ConvertUsing(new HashToValidationCodeConverter());

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.per_things.PerbillBase, Perbill>().IncludeAllDerived().ConvertUsing(new PerbillBaseConverter());
                CreateMap<Perbill, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.per_things.PerbillBase>().IncludeAllDerived().ConvertUsing(new PerbillConverter());

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_beefy.ecdsa_crypto.PublicBase, PublicEcdsa>().IncludeAllDerived().ConvertUsing(x => new PublicEcdsa((x.Value != null ? x.Value.Value : x.Value1).Value));

                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v1.assignment_app.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519(x.Value.Value.Value));
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v5.assignment_app.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519(x.Value.Value.Value));
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v6.assignment_app.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519(x.Value.Value.Value));

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.vbase.assignment_app.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519((x.Value != null ? x.Value.Value : x.Value1).Value));

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_im_online.sr25519.app_sr25519.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519(x.Value.Value.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.assignment_app.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519(x.Value.Value.Value));

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.assignment_app.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519(x.Value.Value.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.validator_app.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519(x.Value.Value.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_authority_discovery.app.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519((x.Value != null ? x.Value.Value : x.Value1).Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_babe.app.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519((x.Value != null ? x.Value.Value : x.Value1).Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.collator_app.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519(x.Value.Value.Value));

                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v0.validator_app.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519(x.Value.Value.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.vbase.validator_app.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519((x.Value != null ? x.Value.Value : x.Value1).Value));

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.validator_app.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519(x.Value.Value.Value));
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v5.validator_app.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519(x.Value.Value.Value));
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v6.validator_app.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519(x.Value.Value.Value));
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.vbase.validator_app.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519(x.Value.Value.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9431.polkadot_primitives.v4.collator_app.Public, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519(x.Value.Value.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.sr25519.PublicBase, PublicSr25519>().IncludeAllDerived().ConvertUsing(x => new PublicSr25519(x.Value.Value));
                CreateMap<PublicSr25519, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.sr25519.PublicBase>().IncludeAllDerived().ConvertUsing(new PublicSr25519Converter());

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.ed25519.PublicBase, PublicEd25519>().ConvertUsing(x => new PublicEd25519(x.Value.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_finality_grandpa.app.PublicBase, PublicEd25519>().ConvertUsing(x => new PublicEd25519(x.Value.Value.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_grandpa.app.PublicBase, PublicEd25519>().ConvertUsing(x => new PublicEd25519((x.Value != null ? x.Value.Value : x.Value1).Value));

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.sr25519.SignatureBase, SignatureSr25519>().ConvertUsing(x => new SignatureSr25519(x.Value.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.collator_app.SignatureBase, SignatureSr25519>().ConvertUsing(x => new SignatureSr25519(x.Value.Value.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.collator_app.SignatureBase, SignatureSr25519>().ConvertUsing(x => new SignatureSr25519(x.Value.Value.Value));

                //CreateMap<PublicEd25519, Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.ed25519.Public>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.bitvec.order.Lsb0Base, Lsb0>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_identity.types.BitFlagsBase, U64>().ConvertUsing(x => x.Value);

                CreateMap<U64, Slot>().ConvertUsing(x => new Slot(x));
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


        public class PolkadotBaseTypeProfile : BaseTypeProfile
        {
            public PolkadotBaseTypeProfile()
            {
                BaseComCoreMapping<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.per_things.PerbillBase, Perbill>();
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

            }
        }

        public class AuctionsStorageProfile : Profile
        {
            public AuctionsStorageProfile()
            {
                CreateMap<Arr36BaseOpt, Winning>();//.ConvertUsing(typeof(Arr36BaseOptConverter));
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
                CreateMap<IdAmountBase, IdAmount>().IncludeAllDerived();
                CreateMap<IdAmountT1Base, IdAmount>().ConvertUsing(typeof(IdAmountConverter1));
                CreateMap<IdAmountT2Base, IdAmount>().ConvertUsing(typeof(IdAmountConverter2));


                // Account data
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_balances.AccountDataBase, AccountData>().DisableCtorValidation();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_balances.types.AccountDataBase, AccountData>().DisableCtorValidation();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_balances.types.ExtraFlagsBase, ExtraFlags>().IncludeAllDerived();
            }

            public class IdAmountConverter1 : ITypeConverter<IdAmountT1Base, IdAmount>
            {
                public IdAmount Convert(IdAmountT1Base source, IdAmount destination, ResolutionContext context)
                {
                    destination = new IdAmount();
                    if (source == null) return destination;

                    destination.Amount = source.Amount;

                    if (source.Id is not null)
                        destination.Id = context.Mapper.Map<BaseTuple>(source.Id);

                    return destination;
                }
            }

            public class IdAmountConverter2 : ITypeConverter<IdAmountT2Base, IdAmount>
            {
                public IdAmount Convert(IdAmountT2Base source, IdAmount destination, ResolutionContext context)
                {
                    destination = new IdAmount();
                    if (source == null) return destination;

                    destination.Amount = source.Amount;

                    if (source.Id is not null)
                        destination.Id = context.Mapper.Map<BaseTuple>(source.Id);

                    if (source.Id1 is not null)
                        destination.IdFreezeReason = context.Mapper.Map<EnumRuntimeFreezeReason>(source.Id1);

                    return destination;
                }
            }
        }

        public class BabeStorageProfile : Profile
        {
            public BabeStorageProfile()
            {
                // When <= v29 => EnumNextConfigDescriptor. First we map the NetApiExt enum to our EnumNextConfigDescriptor, then EnumNextConfigDescriptor to BabeEpochConfiguration
                CreateMap<EnumNextConfigDescriptor, BabeEpochConfiguration>().ConvertUsing(typeof(RegistrationConverter));

                // When >= v30
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_babe.BabeEpochConfigurationBase, BabeEpochConfiguration>().IncludeAllDerived();
            }

            public class RegistrationConverter : ITypeConverter<EnumNextConfigDescriptor, BabeEpochConfiguration>
            {
                public BabeEpochConfiguration Convert(EnumNextConfigDescriptor source, BabeEpochConfiguration destination, ResolutionContext context)
                {
                    destination = new BabeEpochConfiguration();
                    if (source == null) return destination;

                    var tuple = source.Value2.As<BaseTuple<BaseTuple<U64, U64>, EnumAllowedSlots>>();
                    destination.Create(tuple.Value[0].As<BaseTuple<U64, U64>>(), tuple.Value[1].As<EnumAllowedSlots>());

                    return destination;
                }
            }

            //public class BaseOptHexaConverter : ITypeConverter<IBaseValue, BaseOpt<Hexa>>
            //{
            //    public BaseOpt<Hexa> Convert(IBaseValue source, BaseOpt<Hexa> destination, ResolutionContext context)
            //    {
            //        destination = new BaseOpt<Hexa>();
            //        if (source == null) return destination;

            //        switch (source)
            //        {
            //            case BaseOpt<Arr32U8> b:
            //                destination = context.Mapper.Map<BaseOpt<Hexa>>(b.Value);
            //                return destination;
            //            default:
            //                throw new MissingMappingException($"IBaseValue -> BaseOpt<Hexa>");
            //        }
            //    }
            //}
        }

        public class CrowdloanStorageProfile : Profile
        {
            public CrowdloanStorageProfile()
            {
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_common.crowdloan.FundInfoBase, FundInfo>().IncludeAllDerived().ConvertUsing(new FundInfoConverter());
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

        public class ConvictionStorageProfile : Profile
        {
            public ConvictionStorageProfile()
            {
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_conviction_voting.vote.VoteBase, Vote>();
            }
        }

        public class DemocracyStorageProfile : Profile
        {
            public DemocracyStorageProfile()
            {
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_democracy.vote.VoteBase, Vote>();
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
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_identity.types.RegistrationBase, Registration>().ConvertUsing(new RegistrationConverter());
                CreateMap<IType, BaseTuple<Registration, BaseOpt<BaseVec<U8>>>>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_identity.types.IdentityInfoBase, IdentityInfo>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_identity.simple.IdentityInfoBase, IdentityInfo>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_identity.legacy.IdentityInfoBase, IdentityInfo>();

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_identity.types.RegistrarInfoBase, RegistrarInfo>().ConvertUsing(new RegistrarInfoConverter());
            }

            public class RegistrarInfoConverter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_identity.types.RegistrarInfoBase, RegistrarInfo>
            {
                public RegistrarInfo Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_identity.types.RegistrarInfoBase source, RegistrarInfo destination, ResolutionContext context)
                {
                    destination = new RegistrarInfo();
                    if (source == null) return destination;

                    destination = new RegistrarInfo(
                        context.Mapper.Map<SubstrateAccount>(source.Account),
                        source.Fee,
                        source.Fields is not null ? context.Mapper.Map<U64>(source.Fields) : source.Fields1);

                    return destination;
                }
            }
            public class RegistrationConverter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_identity.types.RegistrationBase, Registration>
            {
                public Registration Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_identity.types.RegistrationBase source, Registration destination, ResolutionContext context)
                {
                    destination = new Registration();
                    if (source == null) return destination;

                    if (source.Info != null)
                    {
                        destination.Info = context.Mapper.Map<IdentityInfo>(source.Info);
                    }

                    if (source.Info1 != null)
                    {
                        destination.Info = context.Mapper.Map<IdentityInfo>(source.Info1);
                    }

                    if (source.Info2 != null)
                    {
                        destination.Info = context.Mapper.Map<IdentityInfo>(source.Info2);
                    }

                    destination.Deposit = source.Deposit;
                    destination.Judgements = context.Mapper.Map<BaseVec<BaseTuple<U32, EnumJudgement>>>(source.Judgements);


                    return destination;
                }
            }

            //public class IdentityInfoConverter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_identity.types.IdentityInfoBase, IdentityInfo>
            //{
            //    public IdentityInfo Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_identity.types.IdentityInfoBase source, IdentityInfo destination, ResolutionContext context)
            //    {
            //        destination = new IdentityInfo();
            //        if (source == null) return destination;

            //        destination.Display = (EnumData)MapEnumInternal(source.Display, typeof(EnumData));
            //        destination.Legal = (EnumData)MapEnumInternal(source.Legal, typeof(EnumData));
            //        destination.Web = (EnumData)MapEnumInternal(source.Web, typeof(EnumData));
            //        destination.Riot = (EnumData)MapEnumInternal(source.Riot, typeof(EnumData));
            //        destination.Email = (EnumData)MapEnumInternal(source.Email, typeof(EnumData));
            //        destination.PgpFingerprint = context.Mapper.Map<BaseOpt<FlexibleNameable>>(source.PgpFingerprint);
            //        destination.Twitter = (EnumData)MapEnumInternal(source.Twitter, typeof(EnumData));
            //        destination.Image = (EnumData)MapEnumInternal(source.Image, typeof(EnumData));
            //        destination.Additional = context.Mapper.Map<BaseVec<BaseTuple<EnumData, EnumData>>>(source.Additional);

            //        return destination;
            //    }
            //}
        }

        public class NominationPoolsStorageProfile : Profile
        {
            public NominationPoolsStorageProfile()
            {
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.BondedPoolInnerBase, BondedPoolInner>().IncludeAllDerived();//.ConvertUsing(new BondedPoolInnerConverter());
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.PoolRolesBase, PoolRoles>().IncludeAllDerived();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.CommissionBase, Commission>().IncludeAllDerived();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.CommissionChangeRateBase, CommissionChangeRate>().IncludeAllDerived();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.PoolMemberBase, PoolMember>().IncludeAllDerived();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.fixed_point.FixedU128Base, U128>().IncludeAllDerived().ConvertUsing(x => x.Value);
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.RewardPoolBase, RewardPool>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.SubPoolsBase, SubPools>().IncludeAllDerived();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.UnbondPoolBase, UnbondPool>().IncludeAllDerived();
            }

            public class BondedPoolInnerConverter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.BondedPoolInnerBase, BondedPoolInner>
            {
                public BondedPoolInner Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools.BondedPoolInnerBase source, BondedPoolInner destination, ResolutionContext context)
                {
                    destination = new BondedPoolInner();
                    destination.Points = context.Mapper.Map<U128>(source.Points);
                    destination.State = context.Mapper.Map<EnumPoolState>(source.State);
                    destination.MemberCounter = context.Mapper.Map<U32>(source.MemberCounter);
                    destination.Roles = context.Mapper.Map<PoolRoles>(source.Roles);
                    destination.Commission = context.Mapper.Map<Commission>(source.Commission);

                    return destination;
                }
            }
        }

        public class ParaSessionInfoStorageProfile : Profile
        {
            public ParaSessionInfoStorageProfile()
            {
                //CreateMap<BaseVec<
                //        Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.assignment_app.Public>, BaseVec<PublicSr25519>>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.SessionInfoBase, SessionInfo>().IncludeAllDerived();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.SessionInfoBase, SessionInfo>().IncludeAllDerived();
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v5.SessionInfoBase, SessionInfo>().IncludeAllDerived();
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v6.SessionInfoBase, SessionInfo>().IncludeAllDerived();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.vbase.SessionInfoBase, SessionInfo>().IncludeAllDerived();

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.ValidatorIndexBase, U32>().IncludeAllDerived().ConvertUsing(x => x.Value);
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.ValidatorIndexBase, U32>().IncludeAllDerived().ConvertUsing(x => x.Value);
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v5.ValidatorIndexBase, U32>().IncludeAllDerived().ConvertUsing(x => x.Value);
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v6.ValidatorIndexBase, U32>().IncludeAllDerived().ConvertUsing(x => x.Value);
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.vbase.ValidatorIndexBase, U32>().IncludeAllDerived().ConvertUsing(x => x.Value);

                //ExecutorParamsBase
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.executor_params.ExecutorParamsBase, ExecutorParams>().IncludeAllDerived();
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v5.executor_params.ExecutorParamsBase, ExecutorParams>().IncludeAllDerived();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.vbase.executor_params.ExecutorParamsBase, ExecutorParams>().IncludeAllDerived();

                ////CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.validator_app.Public, PublicSr25519>().ConvertUsing(x => new PublicSr25519(x.Value.Value.Value));
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.validator_app.Public, PublicSr25519>().ConvertUsing(x => Instance.Map<
                //    Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.sr25519.Public, PublicSr25519>(x.Value));
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.assignment_app.Public, PublicSr25519>().ConvertUsing(x => Instance.Map<
                //    Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.sr25519.Public, PublicSr25519>(x.Value));
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_authority_discovery.app.Public, PublicSr25519>().ConvertUsing(x => Instance.Map<
                //    Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.sr25519.Public, PublicSr25519>(x.Value));
            }
        }

        public class PolkadotRuntimeParachain : Profile
        {
            public PolkadotRuntimeParachain()
            {
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.CandidateReceiptBase, CandidateReceipt>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.CandidateReceiptBase, CandidateReceipt>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.CandidateDescriptorBase, CandidateDescriptor>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.CandidateDescriptorBase, CandidateDescriptor>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.HeadDataBase, HeadData>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.CoreIndexBase, CoreIndex>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.CoreIndexBase, CoreIndex>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2.GroupIndexBase, GroupIndex>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.GroupIndexBase, GroupIndex>();
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
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain_primitives.primitives.IdBase, Id>().IncludeAllDerived().ConvertUsing(new IdBaseConverter2());
                CreateMap<Id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.IdBase>().ConvertUsing(new IdConverter());
                CreateMap<Id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain_primitives.primitives.IdBase>().ConvertUsing(new IdConverter2());

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.HeadDataBase, DataCode>().ConvertUsing(x => new DataCode((BaseVec<U8>)x.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain_primitives.primitives.HeadDataBase, DataCode>().ConvertUsing(x => new DataCode((BaseVec<U8>)x.Value));

                CreateMap<
                    Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.paras.ParaPastCodeMetaBase, ParaPastCodeMeta>();
                CreateMap<
                    Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.paras.ReplacementTimesBase, ReplacementTimes>();
            }

            public class IdBaseConverter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.IdBase, Id>
            {
                public Id Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives.IdBase source, Id destination, ResolutionContext context)
                {
                    destination = new Id(source.Value);
                    return destination;
                }
            }

            public class IdBaseConverter2 : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain_primitives.primitives.IdBase, Id>
            {
                public Id Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain_primitives.primitives.IdBase source, Id destination, ResolutionContext context)
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

            public class IdConverter2 : ITypeConverter<Id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain_primitives.primitives.IdBase>
            {
                public Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain_primitives.primitives.IdBase Convert(Id source, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain_primitives.primitives.IdBase destination, ResolutionContext context)
                {
                    if (!context.Items.ContainsKey("version"))
                        throw new SpecVersionMissingException("Version is missing while mapping Id to IdBase");

                    destination = Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain_primitives.primitives.IdBase.Create(source.Bytes ?? source.Encode(), (uint)context.Items["version"]);

                    return destination;
                }
            }
        }

        public class RegistarStorageProfile : Profile
        {
            public RegistarStorageProfile()
            {
                CreateMap<ParaInfoBase, ParaInfo>().ConvertUsing(new ParaInfoConverter());
            }

            public class ParaInfoConverter : ITypeConverter<ParaInfoBase, ParaInfo>
            {
                public ParaInfo Convert(ParaInfoBase source, ParaInfo destination, ResolutionContext context)
                {
                    if (source == null) return new ParaInfo();

                    BaseOpt<Bool> locked;
                    if (source.Locked is not null)
                        locked = new BaseOpt<Bool>(source.Locked);
                    else if (source.Locked1 is not null)
                        locked = source.Locked1.As<BaseOpt<Bool>>();
                    else
                        throw new InvalidMappingException("Error while getting Locked value from ParaInfo storage");

                    destination = new ParaInfo(
                        context.Mapper.Map<SubstrateAccount>(source.Manager),
                        source.Deposit,
                        locked
                    );

                    return destination;
                }
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
                    else if (source.ParaValidator3 is not null)
                        paraValidator = context.Mapper.Map<PublicSr25519>(source.ParaValidator3);
                    else if (source.ParaValidator4 is not null)
                        paraValidator = context.Mapper.Map<PublicSr25519>(source.ParaValidator4);
                    else if (source.ParaValidator5 is not null)
                        paraValidator = context.Mapper.Map<PublicSr25519>(source.ParaValidator5);
                    else
                        throw new InvalidMappingException("Error while getting ParaValidator value from SessionKeys storage");

                    PublicSr25519? paraAssignment = null;
                    if (source.ParaAssignment is not null)
                        paraAssignment = context.Mapper.Map<PublicSr25519>(source.ParaAssignment);
                    else if (source.ParaAssignment1 is not null)
                        paraAssignment = context.Mapper.Map<PublicSr25519>(source.ParaAssignment1);
                    else if (source.ParaAssignment2 is not null)
                        paraAssignment = context.Mapper.Map<PublicSr25519>(source.ParaAssignment2);
                    else if (source.ParaAssignment3 is not null)
                        paraAssignment = context.Mapper.Map<PublicSr25519>(source.ParaAssignment3);
                    else if (source.ParaAssignment4 is not null)
                        paraAssignment = context.Mapper.Map<PublicSr25519>(source.ParaAssignment4);
                    else if (source.ParaAssignment5 is not null)
                        paraAssignment = context.Mapper.Map<PublicSr25519>(source.ParaAssignment5);
                    else
                        throw new InvalidMappingException("Error while getting ParaAssignment value from SessionKeys storage");

                    var babe = context.Mapper.Map<PublicSr25519>(source.Babe);

                    PublicSr25519? imOnline = null;
                    if (source.ImOnline is not null)
                        imOnline = context.Mapper.Map<PublicSr25519>(source.ImOnline);

                    var authorityDiscovery = context.Mapper.Map<PublicSr25519>(source.AuthorityDiscovery);

                    PublicEcdsa? beefy = null;
                    if (source.Beefy is not null)
                    {
                        beefy = context.Mapper.Map<PublicEcdsa>(source.Beefy);
                    }

                    destination = new SessionKeysPolka(grandPa, babe, imOnline, paraValidator, paraAssignment, authorityDiscovery, beefy);
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
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_system.EventRecordBase, EventRecord>().ConvertUsing(new EventRecordConverter());
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_support.dispatch.DispatchInfoBase, DispatchInfo>();

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_runtime.ModuleErrorBase, ModuleError>().ConvertUsing(new ModuleErrorConverter());
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

            public class ModuleErrorConverter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_runtime.ModuleErrorBase, ModuleError>
            {
                public ModuleError Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_runtime.ModuleErrorBase source, ModuleError destination, ResolutionContext context)
                {
                    destination = new ModuleError();
                    if (source == null) return destination;

                    var errors = source.Error != null ? [source.Error] : source.Error1.Value;

                    destination = new ModuleError(source.Index, errors);

                    return destination;
                }
            }

            public class EventRecordConverter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_system.EventRecordBase, EventRecord>
            {
                public EventRecord Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_system.EventRecordBase source, EventRecord destination, ResolutionContext context)
                {
                    destination = new EventRecord();
                    if (source == null) return destination;

                    EnumRuntimeEvent? mappedEvents = null;
                    bool hasBeenMapped = true;
                    IType sourceEvent = source.Event ?? source.Event1;

                    if (sourceEvent is null)
                        throw new InvalidMappingException("Error while getting Events value from EventRecord storage");

                    try
                    {
                        mappedEvents = (EnumRuntimeEvent)MapEnumInternal(sourceEvent, typeof(EnumRuntimeEvent), context);
                    }
                    catch (Exception)
                    {
                        hasBeenMapped = false;
                    }

                    var mappedPhase = context.Mapper.Map<EnumPhase>(source.Phase);
                    //(EnumPhase)MapEnumInternal(source.Phase, typeof(EnumPhase));
                    var mappedTopics = context.Mapper.Map<BaseVec<Hash>>(source.Topics);

                    var eventRuntime = hasBeenMapped ? new Maybe<EnumRuntimeEvent>(mappedEvents!, sourceEvent) : new Maybe<EnumRuntimeEvent>(sourceEvent);
                    destination = new EventRecord(mappedPhase, eventRuntime, mappedTopics);

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

                    if (source.Refcount is not null)
                        destination.RefCount = new U32(source.Refcount.Value);

                    if (source.Refcount1 is not null)
                        destination.RefCount = source.Refcount1;

                    if (source.Consumers is not null)
                        destination.Consumers = source.Consumers;

                    if (source.Providers is not null)
                        destination.Providers = source.Providers;

                    if (source.Sufficients is not null)
                        destination.Sufficients = source.Sufficients;

                    if (source.Data is not null)
                        destination.Data = context.Mapper.Map<AccountData>(source.Data);
                    else if (source.Data1 is not null)
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
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.per_things.PercentBase, Percent>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.EraRewardPointsBase, EraRewardPoints>().ConvertUsing(typeof(EraRewardPointsConverter));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.ExposureBase, Exposure>();

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_staking.ExposurePageBase, ExposurePage>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_staking.IndividualExposureBase, IndividualExposure>();

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_staking.PagedExposureMetadataBase, Exposure>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.IndividualExposureBase, IndividualExposure>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.ValidatorPrefsBase, ValidatorPrefs>().IncludeAllDerived();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.NominationsBase, Nominations>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.slashing.SlashingSpansBase, SlashingSpans>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.slashing.SpanRecordBase, SpanRecord>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.ActiveEraInfoBase, ActiveEraInfo>().IncludeAllDerived();
            }

            public class EraRewardPointsConverter : ITypeConverter<EraRewardPointsBase, EraRewardPoints>
            {
                public EraRewardPoints Convert(EraRewardPointsBase source, EraRewardPoints destination, ResolutionContext context)
                {
                    destination = new EraRewardPoints();
                    if (source is null) return destination;

                    destination.Total = source.Total;

                    destination.Individual = context.Mapper.Map<BaseVec<BaseTuple<SubstrateAccount, U32>>>(source.Individual ?? source.Individual1);

                    return destination;
                }
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

        public class ValidationCodeHashConverter2 : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain_primitives.primitives.ValidationCodeHashBase, Hash>
        {
            public Hash Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain_primitives.primitives.ValidationCodeHashBase source, Hash destination, ResolutionContext context)
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


    }
}
