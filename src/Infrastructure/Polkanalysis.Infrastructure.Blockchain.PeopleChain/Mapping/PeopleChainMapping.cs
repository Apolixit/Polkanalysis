using AutoMapper;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.DispatchInfo;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Random;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Infrastructure.Blockchain.Exceptions;
using Polkanalysis.Infrastructure.Blockchain.Mapping;
using Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.polkadot_parachain_primitives.primitives;
using Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.primitive_types;
using Polkanalysis.PeopleChain.NetApiExt.Generated.Types.Base;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Infrastructure.Blockchain.PeopleChain.Mapping
{
    public class PeopleChainMapping : CommonMapping
    {
        public PeopleChainMapping(ILogger<PeopleChainMapping> logger) : base(logger)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BaseTypeProfile>();
                cfg.AddProfile<EnumProfile>();
                cfg.AddProfile<CommonProfile>();
                cfg.AddProfile<BalancesStorageProfile>();
                cfg.AddProfile<IdentityStorageProfile>();
                cfg.AddProfile<ParachainInfoStorageProfile>();
                cfg.AddProfile<SystemStorageProfile>();
                cfg.AddProfile<NameableProfile>();

                //cfg.ConstructServicesUsing(type => provider.GetService(type));
            });

            _mapper = mapperConfig.CreateMapper();
        }

        public class CommonProfile : Profile
        {
            public CommonProfile()
            {
                CreateMap<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base, SubstrateAccount>().IncludeAllDerived().ConvertUsing(new AccountId32Converter());
                CreateMap<SubstrateAccount, Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base>().IncludeAllDerived().ConvertUsing(new SubstrateAccountConverter());

                CreateMap<H256Base, Hash>().ConvertUsing(new H256Converter());
                CreateMap<Hash, H256Base>().ConvertUsing(new HashConverter());
            }

            public class SubstrateAccountConverter : ITypeConverter<SubstrateAccount, Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base>
            {
                public Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base Convert(SubstrateAccount source, Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base destination, ResolutionContext context)
                {
                    if (!context.Items.ContainsKey("version"))
                        throw new SpecVersionMissingException("Version is missing while mapping SubstrateAccount to AccountId32Base");

                    destination = Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base.Create(source.Bytes ?? source.Encode(), (uint)context.Items["version"]);
                    return destination;
                }
            }

            public class AccountId32Converter : ITypeConverter<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base, SubstrateAccount>
            {
                public SubstrateAccount Convert(Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base source, SubstrateAccount destination, ResolutionContext context)
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
        }

        public class BalancesStorageProfile : Profile
        {
            public BalancesStorageProfile()
            {
                // Balance lock
                CreateMap<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.pallet_balances.types.BalanceLockBase, BalanceLock>().IncludeAllDerived();
                //CreateMap<IdAmountBase, IdAmount>().IncludeAllDerived();
                //CreateMap<IdAmountT1Base, IdAmount>().ConvertUsing(typeof(IdAmountConverter1));
                //CreateMap<IdAmountT2Base, IdAmount>().ConvertUsing(typeof(IdAmountConverter2));


                // Account data
                CreateMap<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.pallet_balances.types.AccountDataBase, AccountData>().DisableCtorValidation();
                CreateMap<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.pallet_balances.types.ExtraFlagsBase, ExtraFlags>().IncludeAllDerived();
            }
        }

        public class IdentityStorageProfile : Profile
        {
            public IdentityStorageProfile()
            {
                CreateMap<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.pallet_identity.types.RegistrationBase, Registration>().ConvertUsing(new RegistrationConverter());
                CreateMap<IType, BaseTuple<Registration, BaseOpt<BaseVec<U8>>>>();
                //CreateMap<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.people_polkadot_runtime.people.IdentityInfoBase, IdentityInfo>().ConvertUsing(new IdentityInfoConverter());
                CreateMap<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.people_polkadot_runtime.people.IdentityInfoBase, IdentityInfo>().IncludeAllDerived();
                CreateMap<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.pallet_identity.types.AuthorityPropertiesBase, AuthorityProperties>().IncludeAllDerived();

                CreateMap<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.pallet_identity.types.RegistrarInfoBase, RegistrarInfo>().ConvertUsing(new RegistrarInfoConverter());
            }

            public class RegistrarInfoConverter : ITypeConverter<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.pallet_identity.types.RegistrarInfoBase, RegistrarInfo>
            {
                public RegistrarInfo Convert(Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.pallet_identity.types.RegistrarInfoBase source, RegistrarInfo destination, ResolutionContext context)
                {
                    destination = new RegistrarInfo();
                    if (source == null) return destination;

                    destination = new RegistrarInfo(
                        context.Mapper.Map<SubstrateAccount>(source.Account),
                        source.Fee,
                        context.Mapper.Map<U64>(source.Fields));

                    return destination;
                }
            }
            public class RegistrationConverter : ITypeConverter<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.pallet_identity.types.RegistrationBase, Registration>
            {
                public Registration Convert(Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.pallet_identity.types.RegistrationBase source, Registration destination, ResolutionContext context)
                {
                    destination = new Registration();
                    if (source == null) return destination;

                    if (source.Info != null)
                    {
                        destination.Info = context.Mapper.Map<IdentityInfo>(source.Info);
                    }

                    destination.Deposit = source.Deposit;
                    destination.Judgements = context.Mapper.Map<BaseVec<BaseTuple<U32, EnumJudgement>>>(source.Judgements);


                    return destination;
                }
            }

            public class IdentityInfoConverter : ITypeConverter<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.people_polkadot_runtime.people.IdentityInfoBase, IdentityInfo>
            {
                public IdentityInfo Convert(Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.people_polkadot_runtime.people.IdentityInfoBase source, IdentityInfo destination, ResolutionContext context)
                {
                    destination = new IdentityInfo();
                    if (source == null) return destination;

                    destination = new IdentityInfo(
                        display: (EnumData)MapEnumInternal(source.Display, typeof(EnumData)),
                        legal: (EnumData)MapEnumInternal(source.Legal, typeof(EnumData)),
                        web: (EnumData)MapEnumInternal(source.Web, typeof(EnumData)),
                        matrix: (EnumData)MapEnumInternal(source.Matrix, typeof(EnumData)),
                        email: (EnumData)MapEnumInternal(source.Email, typeof(EnumData)),
                        pgpFingerprint: context.Mapper.Map<BaseOpt<FlexibleNameable>>(source.PgpFingerprint),
                        twitter: (EnumData)MapEnumInternal(source.Twitter, typeof(EnumData)),
                        image: (EnumData)MapEnumInternal(source.Image, typeof(EnumData)),
                        github: (EnumData)MapEnumInternal(source.Github, typeof(EnumData)),
                        discord: (EnumData)MapEnumInternal(source.Discord, typeof(EnumData)
                    ));

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

        public class ParachainInfoStorageProfile : Profile
        {
            public ParachainInfoStorageProfile()
            {
                CreateMap<IdBase, Id>().IncludeAllDerived().ConvertUsing(new IdBaseConverter2());
                CreateMap<Id, IdBase>().ConvertUsing(new IdConverter2());
            }

            public class IdBaseConverter2 : ITypeConverter<IdBase, Id>
            {
                public Id Convert(IdBase source, Id destination, ResolutionContext context)
                {
                    destination = new Id(source.Value);
                    return destination;
                }
            }

            public class IdConverter2 : ITypeConverter<Id, IdBase>
            {
                public IdBase Convert(Id source, IdBase destination, ResolutionContext context)
                {
                    if (!context.Items.ContainsKey("version"))
                        throw new SpecVersionMissingException("Version is missing while mapping Id to IdBase");

                    destination = IdBase.Create(source.Bytes ?? source.Encode(), (uint)context.Items["version"]);

                    return destination;
                }
            }
        }

        public class SystemStorageProfile : Profile
        {
            public SystemStorageProfile()
            {
                CreateMap<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.frame_system.AccountInfoBase, AccountInfo>().ConvertUsing(new AccountInfoConverter());
                CreateMap<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.frame_support.dispatch.PerDispatchClassT1Base, FrameSupportDispatchPerDispatchClassWeight>().IncludeAllDerived().ConvertUsing(new PerDispatchClassT1Converter());
                CreateMap<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.sp_weights.weight_v2.WeightBase, Weight>().IncludeAllDerived().ConvertUsing(new WeightConverter());
                CreateMap<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.sp_runtime.generic.digest.DigestBase, Digest>();
                CreateMap<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.frame_system.EventRecordBase, EventRecord>().ConvertUsing(new EventRecordConverter());
                CreateMap<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.frame_support.dispatch.DispatchInfoBase, DispatchInfo>();
                CreateMap<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.frame_system.LastRuntimeUpgradeInfoBase, LastRuntimeUpgradeInfo>();
            }

            public class EventRecordConverter : ITypeConverter<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.frame_system.EventRecordBase, EventRecord>
            {
                public EventRecord Convert(Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.frame_system.EventRecordBase source, EventRecord destination, ResolutionContext context)
                {
                    destination = new EventRecord();
                    if (source == null) return destination;

                    EnumRuntimeEvent? mappedEvents = null;
                    bool hasBeenMapped = true;
                    IType sourceEvent = source.Event;

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

            public class AccountInfoConverter : ITypeConverter<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.frame_system.AccountInfoBase, AccountInfo>
            {
                public AccountInfo Convert(Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.frame_system.AccountInfoBase source, AccountInfo destination, ResolutionContext context)
                {
                    destination = new AccountInfo();
                    if (source == null) return destination;

                    destination.Nonce = source.Nonce;

                    if (source.Consumers is not null)
                        destination.Consumers = source.Consumers;

                    if (source.Providers is not null)
                        destination.Providers = source.Providers;

                    if (source.Sufficients is not null)
                        destination.Sufficients = source.Sufficients;

                    if (source.Data is not null)
                        destination.Data = context.Mapper.Map<AccountData>(source.Data);
                    else
                        throw new InvalidMappingException("Error while getting Data value from AccountInfo storage");

                    return destination;
                }
            }

            public class PerDispatchClassT1Converter : ITypeConverter<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.frame_support.dispatch.PerDispatchClassT1Base, FrameSupportDispatchPerDispatchClassWeight>
            {
                public FrameSupportDispatchPerDispatchClassWeight Convert(Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.frame_support.dispatch.PerDispatchClassT1Base source, FrameSupportDispatchPerDispatchClassWeight destination, ResolutionContext context)
                {
                    destination = new FrameSupportDispatchPerDispatchClassWeight();
                    if (source == null) return destination;

                    destination.Normal = context.Mapper.Map<Weight>(source.Normal);
                    destination.Operational = context.Mapper.Map<Weight>(source.Operational);
                    destination.Mandatory = context.Mapper.Map<Weight>(source.Mandatory);

                    return destination;
                }
            }

            public class WeightConverter : ITypeConverter<Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.sp_weights.weight_v2.WeightBase, Weight>
            {
                public Weight Convert(Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.sp_weights.weight_v2.WeightBase source, Weight destination, ResolutionContext context)
                {
                    destination = new Weight();
                    if (source == null) return destination;

                    destination.ProofSize = context.Mapper.Map<BaseCom<U64>>(source.ProofSize);

                    if (source.RefTime is not null)
                        destination.RefTime = context.Mapper.Map<BaseCom<U64>>(source.RefTime);

                    return destination;
                }
            }
        }
    }
}
