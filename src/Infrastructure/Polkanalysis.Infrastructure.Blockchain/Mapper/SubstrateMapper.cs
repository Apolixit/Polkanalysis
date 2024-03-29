﻿using System;
using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_balances;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Domain.Contracts.Core.Display;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types;
using Substrate.NetApi;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.weak_bounded_vec;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_support.traits.tokens.misc;
using static Polkanalysis.Infrastructure.Blockchain.Mapper.PolkadotMapping;
using static Polkanalysis.Infrastructure.Blockchain.Mapper.PolkadotMapping.AuctionsStorageProfile;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_im_online.sr25519.app_sr25519;
using Polkanalysis.Domain.Contracts.Core.Random;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.SystemCore;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_support.dispatch;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Auctions;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.SystemCore.Enums;
using System.Numerics;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Babe;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Identity.Enums;
using static Polkanalysis.Infrastructure.Blockchain.Mapper.PolkadotMapping.IdentityStorageProfile;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Identity;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.NominationPools;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.NominationPools.Enums;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.ParaSessionInfo;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Registrar;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Session;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Paras.Enums;
using Polkanalysis.Domain.Contracts.Core.Empty;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking;
using Polkanalysis.Domain.Contracts.Core.Enum.FrameSupport;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Authorship.Enums;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Babe.Enums;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Democracy;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Democracy.Enums;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking.Enums;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.xcm.double_encoded;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Core.Public;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntime;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Crowdloan;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Paras;
using static Polkanalysis.Infrastructure.Blockchain.Mapper.PolkadotMapping.BaseTypeProfile;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using Polkanalysis.Domain.Contracts.Core.Map;
using Polkanalysis.Domain.Contracts.Core.Multi;

namespace Polkanalysis.Infrastructure.Blockchain.Mapper
{
    public class PolkadotMapping : IBlockchainMapping
    {
        public IMapper Mapper
        {
            get
            {
                return Instance;
            }
        }

        #region Singleton
        private static IMapper? _instance;
        public static IMapper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = configuration.CreateMapper();
                }
                return _instance;
            }
        }
        #endregion

        private static MapperConfiguration configuration =
            new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<BaseTypeProfile>();
            cfg.AddProfile<CommonProfile>();
            cfg.AddProfile<EnumProfile>();
            cfg.AddProfile<BytesProfile>();
            cfg.AddProfile<AuctionsStorageProfile>();
            cfg.AddProfile<AuthorshipStorageProfile>();
            cfg.AddProfile<BalancesStorageProfile>();
            cfg.AddProfile<CrowdloanStorageProfile>();
            cfg.AddProfile<DemocracyStorageProfile>();
            cfg.AddProfile<IdentityStorageProfile>();
            cfg.AddProfile<NominationPoolsStorageProfile>();
            cfg.AddProfile<BabeStorageProfile>();
            cfg.AddProfile<ParaSessionInfoStorageProfile>();
            cfg.AddProfile<ParachainStorageProfile>();
            cfg.AddProfile<RegistarStorageProfile>();
            cfg.AddProfile<SchedulerStorageProfile>();
            cfg.AddProfile<SessionStorageProfile>();
            cfg.AddProfile<SystemStorageProfile>();
            cfg.AddProfile<StakingStorageProfile>();
            cfg.AddProfile<XcmStorageProfile>();

            //cfg.CreateMap<Arr8U8, string>().ConvertUsing((i, o) => o.ToString());
            //cfg.CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_balances.Reasons, Polkanalysis.Domain.Contracts.Secondary.Pallet.Balances.Enums.Reasons>().ConvertUsingEnumMapping(opt => opt.MapByName());
            //cfg.CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_authorship.EnumUncleEntryItem, Domain.Contracts.Secondary.Pallet.Authorship.EnumUncleEntryItem>().ConvertUsingEnumMapping(opt => opt.MapByName());







        });

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
                CreateMap<SubstrateAccount, AccountId32>().ConvertUsing(new SubstrateAccountConverter());
                CreateMap<AccountId32, SubstrateAccount>().ConvertUsing(new AccountId32Converter());

                CreateMap<H256, Hash>().ConvertUsing(new H256Converter());
                CreateMap<Hash, H256>().ConvertUsing(new HashConverter());
                CreateMap<ValidationCodeHash, Hash>().ConvertUsing(new ValidationCodeHashConverter());
                CreateMap<Hash, ValidationCodeHash>().ConvertUsing(new HashToValidationCodeConverter());

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.sr25519.Public, PublicSr25519>().ConvertUsing(x => new PublicSr25519(x.Value.Value));
                CreateMap<PublicSr25519, Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.sr25519.Public>();


                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.ed25519.Public, PublicEd25519>().ConvertUsing(x => new PublicEd25519(x.Value.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_finality_grandpa.app.Public, PublicEd25519>().ConvertUsing(x => new PublicEd25519(x.Value.Value.Value));

                CreateMap<PublicEd25519, Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.ed25519.Public>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.bitvec.order.Lsb0, Lsb0>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_identity.types.BitFlags, U64>().ConvertUsing(x => x.Value);
            }
        }

        public class EnumProfile : Profile
        {
            public EnumProfile()
            {
                CreateMap<BoundedVecT3, BaseVec<U8>>().ConvertUsing(x => x.Value);

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
                CreateMap(typeof(BaseVec<>), typeof(BaseVec<>)).ConvertUsing(typeof(BaseVecConverter<,>));
                CreateMap(typeof(BaseCom<>), typeof(BaseCom<>)).ConvertUsing(typeof(BaseComConverter<,>));

                CreateMap(typeof(BaseEnumExt<,,,>), typeof(BaseEnumExt<,,,>)).IncludeAllDerived().ConvertUsing(typeof(BaseEnumExtConverter<,,,>));
                CreateMap(typeof(BaseEnumExt<,,,,,,,,,,>), typeof(BaseEnumExt<,,,,,,,,,,>)).IncludeAllDerived().ConvertUsing(typeof(BaseEnumExtConverter<,,,,,,,,,,,,,,,,,,,,,>));

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
                BaseComMapping<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_arithmetic.per_things.Perbill>();
                BaseComMapping<Perbill>();
            }

            private void BaseComMapping<T>()
                where T : IType, new()
            {
                CreateMap<BaseCom<T>, T>().ConvertUsing(new BaseComToGenericConverter<T>());
                CreateMap<T, BaseCom<T>>().ConvertUsing(new GenericToBaseComConverter<T>());
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

                    CompactInteger compactNum = new CompactInteger();
                    switch (source)
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
                        case Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_arithmetic.per_things.Perbill num:
                            compactNum = new CompactInteger(num.Value);
                            break;
                        case Perbill num:
                            compactNum = new CompactInteger(num.Value);
                            break;
                    }

                    destination = new BaseCom<T>(compactNum);
                    return destination;
                }
            }

            public class BaseComConverter<T1, T2> : ITypeConverter<BaseCom<T1>, BaseCom<T2>>
                where T1 : IType, new()
                where T2 : IType, new()
            {
                public BaseCom<T2> Convert(BaseCom<T1> source, BaseCom<T2> destination, ResolutionContext context)
                {
                    destination = new BaseCom<T2>();
                    if (source == null) return destination;

                    var t1 = context.Mapper.Map<BaseCom<T1>, T1>(source);
                    var t2 = context.Mapper.Map<T1, T2>(t1);

                    destination = context.Mapper.Map<T2, BaseCom<T2>>(t2);

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

            public class BagListEnumExtConverter : ITypeConverter<
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_bags_list.pallet.EnumEvent, Domain.Contracts.Secondary.Pallet.BagsList.Enums.EnumEvent>

            {
                public Domain.Contracts.Secondary.Pallet.BagsList.Enums.EnumEvent Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_bags_list.pallet.EnumEvent source, Domain.Contracts.Secondary.Pallet.BagsList.Enums.EnumEvent destination, ResolutionContext context)
                {
                    var x = new BaseEnumExtConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_bags_list.pallet.Event, BaseTuple<AccountId32, U64, U64>, BaseTuple<AccountId32, U64>, Domain.Contracts.Secondary.Pallet.BagsList.Enums.Event, BaseTuple<SubstrateAccount, U64, U64>, BaseTuple<SubstrateAccount, U64>>();
                    var res = x.Convert(source, destination, context);

                    destination.Create(res.Bytes);
                    return destination;
                    //destination = new Polkanalysis.Domain.Contracts.Secondary.Pallet.BagsList.Enums.EnumEvent();
                    //if (source == null) return destination;

                    ////destination.Create(context.Mapper.Map<D0>(source.Value), context.Mapper.Map<D1>(source.Value2));
                    //return destination;
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
                CreateMap<Arr32U8, Hexa>().ConvertUsing(x => new Hexa(x));
                CreateMap<WeakBoundedVecT1, FlexibleNameable>().ConvertUsing(new NameableConverter());
            }
        }

        public class AuthorshipStorageProfile : Profile
        {
            public AuthorshipStorageProfile()
            {
                CreateMap<BoundedVecT7, BaseVec<EnumUncleEntryItem>>()
                    .ConvertUsing(x => Instance.Map<BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_authorship.EnumUncleEntryItem>, BaseVec<EnumUncleEntryItem>>(x.Value));

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_authorship.EnumUncleEntryItem, EnumUncleEntryItem>();
            }
        }
        public class AuctionsStorageProfile : Profile
        {
            public AuctionsStorageProfile()
            {
                CreateMap<Arr36BaseOpt, Winning>().ConvertUsing(typeof(Arr36BaseOptConverter));
            }

            public class Arr36BaseOptConverter : ITypeConverter<Arr36BaseOpt, Winning>
            {
                public Winning Convert(Arr36BaseOpt source, Winning destination, ResolutionContext context)
                {
                    //BaseOpt<BaseTuple<SubstrateAccount, Domain.Contracts.Core.Id, U128>>[] destination
                    destination = new Winning();
                    if (source == null || source.Value == null) return destination;

                    var conversions = new List<BaseOpt<BaseTuple<SubstrateAccount, Domain.Contracts.Core.Id, U128>>>();
                    foreach (var item in source.Value)
                    {
                        conversions.Add(context.Mapper.Map<
                            BaseOpt<BaseTuple<AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, U128>>,
                            BaseOpt<BaseTuple<SubstrateAccount, Domain.Contracts.Core.Id, U128>>>(item));
                    }

                    destination.Create(conversions.ToArray());
                    return destination;
                }
            }
        }

        public class BalancesStorageProfile : Profile
        {
            public BalancesStorageProfile()
            {
                // Balance lock
                CreateMap<WeakBoundedVecT3, BaseVec<BalanceLock>>().ConvertUsing((i, o) => i.Value);
                // Map WeakBoundedVecT3 to Domain
                CreateMap<WeakBoundedVecT3, BaseVec<Domain.Contracts.Secondary.Pallet.Balances.BalanceLock>>().ConvertUsing(x => Instance.Map<BaseVec<BalanceLock>, BaseVec<Domain.Contracts.Secondary.Pallet.Balances.BalanceLock>>(x.Value));

                CreateMap<BalanceLock, Domain.Contracts.Secondary.Pallet.Balances.BalanceLock>();

                // Account data
                CreateMap<AccountData, Domain.Contracts.Secondary.Pallet.Balances.AccountData>();


                // Reserve data
                CreateMap<BoundedVecT6, BaseVec<ReserveData>>().ConvertUsing((i, o) => i.Value);
                CreateMap<ReserveData, Domain.Contracts.Secondary.Pallet.Balances.ReserveData>();
                // Map BoundedVecT6 to Domain
                CreateMap<BoundedVecT6, BaseVec<Domain.Contracts.Secondary.Pallet.Balances.ReserveData>>().ConvertUsing(x => Instance.Map<BaseVec<ReserveData>, BaseVec<Domain.Contracts.Secondary.Pallet.Balances.ReserveData>>(x.Value));

                // Events
                CreateMap<EnumBalanceStatus, Domain.Contracts.Secondary.Pallet.Balances.Enums.EnumBalanceStatus>();
                CreateMap<EnumReasons, Domain.Contracts.Secondary.Pallet.Balances.Enums.EnumReasons>();
                //CreateMap<Polkanalysis.Domain.Contracts.Secondary.Pallet.Balances.Enums.EnumEvent, Domain.Contracts.Secondary.Pallet.Balances.Enums.EnumEvent>();
            }
        }

        public class BabeStorageProfile : Profile
        {
            public BabeStorageProfile()
            {
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.app.Public, PublicSr25519>().ConvertUsing(x => Instance.Map<
                    Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.sr25519.Public, PublicSr25519>(x.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_im_online.sr25519.app_sr25519.Public, PublicSr25519>().ConvertUsing(x => Instance.Map<
                    Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.sr25519.Public, PublicSr25519>(x.Value));

                CreateMap<WeakBoundedVecT2, BaseVec<BaseTuple<PublicSr25519, U64>>>().ConvertUsing(typeof(WeakBoundedVecT2Converter));
                CreateMap<BoundedVecT5, BaseVec<Hexa>>().ConvertUsing(typeof(BoundedVecT5Converter));

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.BabeEpochConfiguration, BabeEpochConfiguration>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.EnumAllowedSlots, EnumAllowedSlots>();
                CreateMap<
                    Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.digests.EnumNextConfigDescriptor, EnumNextConfigDescriptor>();
            }

            public class BoundedVecT5Converter : ITypeConverter<BoundedVecT5, BaseVec<Hexa>>
            {
                public BaseVec<Hexa> Convert(BoundedVecT5 source, BaseVec<Hexa> destination, ResolutionContext context)
                {
                    destination = new BaseVec<Hexa>();
                    if (source == null) return destination;

                    return context.Mapper.Map<BaseVec<Arr32U8>, BaseVec<Hexa>>(source.Value);
                }
            }

            public class WeakBoundedVecT2Converter : ITypeConverter<WeakBoundedVecT2, BaseVec<BaseTuple<PublicSr25519, U64>>>
            {
                public BaseVec<BaseTuple<PublicSr25519, U64>> Convert(WeakBoundedVecT2 source, BaseVec<BaseTuple<PublicSr25519, U64>> destination, ResolutionContext context)
                {
                    destination = new BaseVec<BaseTuple<PublicSr25519, U64>>();
                    if (source == null) return destination;

                    destination = context.Mapper.Map<
                        BaseVec<BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.app.Public, U64>>,
                        BaseVec<BaseTuple<PublicSr25519, U64>>>(source.Value);

                    return destination;
                }
            }
        }

        public class CrowdloanStorageProfile : Profile
        {
            public CrowdloanStorageProfile()
            {
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.crowdloan.FundInfo, FundInfo>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_runtime.EnumMultiSigner, EnumMultiSigner>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.crowdloan.EnumLastContribution, EnumLastContribution>();
            }
        }
        public class DemocracyStorageProfile : Profile
        {
            public DemocracyStorageProfile()
            {
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_democracy.types.ReferendumStatus, ReferendumStatus>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_democracy.types.EnumReferendumInfo, EnumReferendumInfo>();
                CreateMap<BoundedVecT13, BaseVec<BaseTuple<U32, EnumAccountVote>>>().ConvertUsing(new BoundedVecT13Converter());
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_democracy.vote.EnumAccountVote, EnumAccountVote>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_democracy.types.Delegations, Delegations>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_democracy.vote.PriorLock, PriorLock>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_democracy.vote.EnumVoting, EnumVoting>();
            }

            public class BoundedVecT13Converter : ITypeConverter<BoundedVecT13, BaseVec<BaseTuple<U32, EnumAccountVote>>>
            {
                public BaseVec<BaseTuple<U32, EnumAccountVote>> Convert(BoundedVecT13 source, BaseVec<BaseTuple<U32, EnumAccountVote>> destination, ResolutionContext context)
                {
                    destination = new BaseVec<BaseTuple<U32, EnumAccountVote>>();
                    if (source == null) return destination;

                    destination = context.Mapper.Map<BaseVec<BaseTuple<U32, EnumAccountVote>>>(source.Value);
                    return destination;
                }
            }
        }
        public class IdentityStorageProfile : Profile
        {
            public IdentityStorageProfile()
            {
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_identity.types.EnumData, EnumData>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_identity.types.EnumJudgement, EnumJudgement>();
                CreateMap<BoundedVecT2, BaseVec<BaseTuple<EnumData, EnumData>>>().ConvertUsing(new BoundedVecT2Converter());
                CreateMap<BoundedVecT19, BaseVec<BaseTuple<U32, EnumJudgement>>>().ConvertUsing(new BoundedVecT19Converter());
                CreateMap<BoundedVecT21, BaseVec<BaseOpt<RegistrarInfo>>>().ConvertUsing(new BoundedVecT21Converter());
                CreateMap<BoundedVecT20, BaseVec<SubstrateAccount>>().ConvertUsing(new BoundedVecT20Converter());
                CreateMap<BaseTuple<U128, BoundedVecT20>, SubsOfResult>().ConvertUsing(new SubsOfResultInverseConverter());

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_identity.types.Registration, Registration>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_identity.types.IdentityInfo, IdentityInfo>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_identity.types.RegistrarInfo, RegistrarInfo>();
            }

            public class SubsOfResultInverseConverter : ITypeConverter<BaseTuple<U128, BoundedVecT20>, SubsOfResult>
            {
                public SubsOfResult Convert(BaseTuple<U128, BoundedVecT20> source, SubsOfResult destination, ResolutionContext context)
                {
                    destination = new SubsOfResult();
                    if (source == null) return destination;

                    destination = new SubsOfResult(
                        (U128)source.Value[0],
                        context.Mapper.Map<BoundedVecT20, BaseVec<SubstrateAccount>>((BoundedVecT20)source.Value[1]));

                    return destination;
                }
            }

            public class BoundedVecT20Converter : ITypeConverter<BoundedVecT20, BaseVec<SubstrateAccount>>
            {
                public BaseVec<SubstrateAccount> Convert(BoundedVecT20 source, BaseVec<SubstrateAccount> destination, ResolutionContext context)
                {
                    destination = new BaseVec<SubstrateAccount>();
                    if (source == null) return destination;

                    destination = context.Mapper.Map<BaseVec<SubstrateAccount>>(source.Value);
                    return destination;
                }
            }

            public class BoundedVecT21Converter : ITypeConverter<BoundedVecT21, BaseVec<BaseOpt<RegistrarInfo>>>
            {
                public BaseVec<BaseOpt<RegistrarInfo>> Convert(BoundedVecT21 source, BaseVec<BaseOpt<RegistrarInfo>> destination, ResolutionContext context)
                {
                    destination = new BaseVec<BaseOpt<RegistrarInfo>>();
                    if (source == null) return destination;

                    destination = context.Mapper.Map<BaseVec<BaseOpt<RegistrarInfo>>>(source.Value);
                    return destination;
                }
            }

            public class BoundedVecT19Converter : ITypeConverter<BoundedVecT19, BaseVec<BaseTuple<U32, EnumJudgement>>>
            {
                public BaseVec<BaseTuple<U32, EnumJudgement>> Convert(BoundedVecT19 source, BaseVec<BaseTuple<U32, EnumJudgement>> destination, ResolutionContext context)
                {
                    destination = new BaseVec<BaseTuple<U32, EnumJudgement>>();
                    if (source == null) return destination;

                    destination = context.Mapper.Map<BaseVec<BaseTuple<U32, EnumJudgement>>>(source.Value);
                    return destination;
                }
            }

            public class BoundedVecT2Converter : ITypeConverter<BoundedVecT2, BaseVec<BaseTuple<EnumData, EnumData>>>
            {
                public BaseVec<BaseTuple<EnumData, EnumData>> Convert(BoundedVecT2 source, BaseVec<BaseTuple<EnumData, EnumData>> destination, ResolutionContext context)
                {
                    destination = new BaseVec<BaseTuple<EnumData, EnumData>>();
                    if (source == null) return destination;

                    destination = context.Mapper.Map<BaseVec<BaseTuple<EnumData, EnumData>>>(source.Value);
                    return destination;
                }
            }
        }

        public class NominationPoolsStorageProfile : Profile
        {
            public NominationPoolsStorageProfile()
            {
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.BondedPoolInner, BondedPoolInner>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.EnumPoolState, EnumPoolState>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.PoolRoles, PoolRoles>();
                CreateMap<BoundedVecT28, FlexibleNameable>().ConvertUsing(x => new FlexibleNameable().FromU8(x.Value.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_arithmetic.fixed_point.FixedU128, U128>().ConvertUsing(x => x.Value);
                CreateMap<
                    Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_btree_map.BoundedBTreeMapT1, BaseVec<BaseTuple<U32, U128>>>().ConvertUsing(x => x.Value.Value);
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.PoolMember, PoolMember>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.RewardPool, RewardPool>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.SubPools, SubPools>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.UnbondPool, UnbondPool>();
                CreateMap<
                    Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_btree_map.BoundedBTreeMapT2, BaseVec<BaseTuple<U32, UnbondPool>>>().ConvertUsing(new BoundedBTreeMapT2Converter());
            }

            public class BoundedBTreeMapT2Converter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_btree_map.BoundedBTreeMapT2, BaseVec<BaseTuple<U32, UnbondPool>>>
            {
                public BaseVec<BaseTuple<U32, UnbondPool>> Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_btree_map.BoundedBTreeMapT2 source, BaseVec<BaseTuple<U32, UnbondPool>> destination, ResolutionContext context)
                {
                    destination = new BaseVec<BaseTuple<U32, UnbondPool>>();
                    if (source == null) return destination;

                    destination = context.Mapper.Map<BaseVec<BaseTuple<U32, UnbondPool>>>(source.Value.Value);
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
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.SessionInfo, Domain.Contracts.Secondary.Pallet.ParaSessionInfo.SessionInfo>();
                CreateMap<ValidatorIndex, U32>().ConvertUsing(x => x.Value);

                CreateMap<IndexedVecT1, BaseVec<PublicSr25519>>().ConvertUsing(new IndexedVecT1Converter());
                CreateMap<IndexedVecT2, BaseVec<BaseVec<U32>>>().ConvertUsing(new IndexedVecT2Converter());
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.validator_app.Public, PublicSr25519>().ConvertUsing(x => new PublicSr25519(x.Value.Value.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.validator_app.Public, PublicSr25519>().ConvertUsing(x => Instance.Map<
                    Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.sr25519.Public, PublicSr25519>(x.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.assignment_app.Public, PublicSr25519>().ConvertUsing(x => Instance.Map<
                    Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.sr25519.Public, PublicSr25519>(x.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_authority_discovery.app.Public, PublicSr25519>().ConvertUsing(x => Instance.Map<
                    Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.sr25519.Public, PublicSr25519>(x.Value));
            }

            public class IndexedVecT1Converter : ITypeConverter<IndexedVecT1, BaseVec<PublicSr25519>>
            {
                public BaseVec<PublicSr25519> Convert(IndexedVecT1 source, BaseVec<PublicSr25519> destination, ResolutionContext context)
                {
                    destination = new BaseVec<PublicSr25519>();
                    if (source == null) return destination;

                    destination = context.Mapper.Map<BaseVec<PublicSr25519>>(source.Value);
                    return destination;
                }
            }

            public class IndexedVecT2Converter : ITypeConverter<IndexedVecT2, BaseVec<BaseVec<U32>>>
            {
                public BaseVec<BaseVec<U32>> Convert(IndexedVecT2 source, BaseVec<BaseVec<U32>> destination, ResolutionContext context)
                {
                    destination = new BaseVec<BaseVec<U32>>();
                    if (source == null) return destination;

                    destination = context.Mapper.Map<BaseVec<BaseVec<U32>>>(source.Value);
                    return destination;
                }
            }
        }

        public class ParachainStorageProfile : Profile
        {
            public ParachainStorageProfile()
            {
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Domain.Contracts.Core.Id>().ConvertUsing((s, d) => new Domain.Contracts.Core.Id(s.Value.Value));
                CreateMap<Domain.Contracts.Core.Id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>();

                CreateMap<ValidationCode, Hexa>().ConvertUsing(x => new Hexa(x)); // TODO Inverse
                CreateMap<HeadData, Hexa>().ConvertUsing(x => new Hexa(x)); // TODO Inverse
                CreateMap<HeadData, DataCode>().ConvertUsing(x => new DataCode(x.Value));

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.paras.ParaPastCodeMeta, ParaPastCodeMeta>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.paras.ReplacementTimes, ReplacementTimes>();


                CreateMap<ValidationCode, DataCode>().ConvertUsing(x => new DataCode(x.Value));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.paras.ParaGenesisArgs, ParaGenesisArgs>();

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.EnumUpgradeGoAhead, Domain.Contracts.Secondary.Pallet.Paras.EnumUpgradeGoAhead>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.EnumUpgradeRestriction, Domain.Contracts.Secondary.Pallet.Paras.EnumUpgradeRestriction>();
                CreateMap<
                    Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.paras.EnumParaLifecycle, EnumParaLifecycle>();
            }
        }

        public class RegistarStorageProfile : Profile
        {
            public RegistarStorageProfile()
            {
                CreateMap<
                    Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.paras_registrar.ParaInfo, ParaInfo>();
            }
        }

        public class SessionStorageProfile : Profile
        {
            public SessionStorageProfile()
            {
                CreateMap<KeyTypeId, FlexibleNameable>().ConvertUsing(new KeyTypeIdConverter());
                CreateMap<FlexibleNameable, KeyTypeId>().ConvertUsing(new KeyTypeIdReverseConverter());
                CreateMap<Hexa, BaseVec<U8>>().ConvertUsing(x => new BaseVec<U8>(x.Value));
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.SessionKeys, SessionKeysPolka>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.SessionKeys, SessionKeysPolka>().ConvertUsing(new SessionKeyConverter());
            }

            public class SessionKeyConverter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.SessionKeys, SessionKeysPolka>
            {
                public SessionKeysPolka Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.SessionKeys source, SessionKeysPolka destination, ResolutionContext context)
                {
                    destination = new SessionKeysPolka();
                    if (source == null) return destination;

                    var gp = context.Mapper.Map<PublicEd25519>(source.Grandpa);
                    var bb = context.Mapper.Map<PublicSr25519>(source.Babe);
                    var io = context.Mapper.Map<PublicSr25519>(source.ImOnline);
                    var pv = context.Mapper.Map<PublicSr25519>(source.ParaValidator);
                    var pa = context.Mapper.Map<PublicSr25519>(source.ParaAssignment);
                    var ad = context.Mapper.Map<PublicSr25519>(source.AuthorityDiscovery);

                    destination = new SessionKeysPolka(gp, bb, io, pv, pa, ad);
                    return destination;
                }
            }

            public class KeyTypeIdConverter : ITypeConverter<KeyTypeId, FlexibleNameable>
            {
                public FlexibleNameable Convert(KeyTypeId source, FlexibleNameable destination, ResolutionContext context)
                {
                    destination = new FlexibleNameable();
                    if (source == null) return destination;

                    context.Mapper.Map<FlexibleNameable>(source.Value);
                    return destination;
                }
            }

            public class KeyTypeIdReverseConverter : ITypeConverter<FlexibleNameable, KeyTypeId>
            {
                public KeyTypeId Convert(FlexibleNameable source, KeyTypeId destination, ResolutionContext context)
                {
                    destination = new KeyTypeId();
                    if (source == null) return destination;

                    destination.Create(source.Encode());
                    return destination;
                }
            }
        }

        public class SchedulerStorageProfile : Profile
        {
            public SchedulerStorageProfile()
            {
                CreateMap<BoundedVecT1, Hash>().ConvertUsing(new BoundedVecT1Converter());
            }
        }

        public class SystemStorageProfile : Profile
        {
            public SystemStorageProfile()
            {
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.AccountInfo, AccountInfo>();
                CreateMap<PerDispatchClassT1, FrameSupportDispatchPerDispatchClassWeight>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight, Weight>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_runtime.generic.digest.Digest, Digest>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_runtime.generic.digest.EnumDigestItem, EnumDigestItem>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.EventRecord, EventRecord>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.EnumPhase, EnumPhase>();
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeEvent, EnumRuntimeEvent>().ForMember(o => o.Value2, m => m.MapFrom(s => s.Value2));
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeEvent, EnumRuntimeEvent>();

                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeEvent, EnumRuntimeEvent>().ConvertUsing(typeof(BaseEnumExtConverter<,,,>));

                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_balances.pallet.EnumEvent, Polkanalysis.Domain.Contracts.Secondary.Pallet.Balances.Enums.EnumEvent>().ConvertUsing((s, d) =>
                //{
                //    d = new();
                //    d.Value = Instance.Map<Domain.Contracts.Secondary.Pallet.Balances.Enums.Event>(s.Value);
                //    d.Value2 = Instance.Map<BaseTuple<SubstrateAccount, U128>>(s.Value2);

                //    return d;
                //});
                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_balances.pallet.EnumEvent, Polkanalysis.Domain.Contracts.Secondary.Pallet.Balances.Enums.EnumEvent>().ConvertUsing(typeof(BaseEnumExtConverter<,,,,,,,,,,,,,,,,,,,,,>));

                //CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_balances.pallet.EnumEvent, Domain.Contracts.Secondary.Pallet.Balances.Enums.EnumEvent>().ConvertUsing(typeof(BaseEnumTypeConverter));

                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.LastRuntimeUpgradeInfo, LastRuntimeUpgradeInfo>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.EventRecord, EventRecord>().ConvertUsing(typeof(EventRecordConverter));
            }

            public class EventRecordConverter : ITypeConverter<Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.EventRecord, EventRecord>
            {
                public EventRecord Convert(Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.EventRecord source, EventRecord destination, ResolutionContext context)
                {
                    destination = new EventRecord();
                    if (source == null) return destination;

                    var mappedPhase = Instance.Map<EnumPhase>(source.Phase);
                    var mappedTopics = Instance.Map<BaseVec<Hash>>(source.Topics);
                    var maybeMappedEvents = new Maybe<EnumRuntimeEvent>();

                    try
                    {

                        var mappedEvents = Instance.Map<
                    Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeEvent, EnumRuntimeEvent>(source.Event);

                        maybeMappedEvents = new Maybe<EnumRuntimeEvent>(mappedEvents);
                    }
                    catch (Exception _)
                    {
                        maybeMappedEvents.Core = source;
                    }

                    destination = new EventRecord(mappedPhase, maybeMappedEvents, mappedTopics);

                    return destination;
                }
            }
        }

        public class StakingStorageProfile : Profile
        {
            public StakingStorageProfile()
            {
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_arithmetic.per_things.Perbill, Perbill>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_arithmetic.per_things.Percent, Percent>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.EraRewardPoints, EraRewardPoints>();
                CreateMap<BTreeMapT1, BaseVec<BaseTuple<SubstrateAccount, U32>>>().ConvertUsing(new BTreeMapT1Converter());
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.Exposure, Exposure>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.IndividualExposure, IndividualExposure>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.ValidatorPrefs, ValidatorPrefs>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.EnumForcing, EnumForcing>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.StakingLedger, StakingLedger>();
                CreateMap<BoundedVecT8, BaseVec<UnlockChunk>>().ConvertUsing(new BoundedVecT8Converter());
                CreateMap<BoundedVecT10, BaseVec<SubstrateAccount>>().ConvertUsing(new BoundedVecT10Converter());
                CreateMap<BoundedVecT9, BaseVec<U32>>().ConvertUsing(x => x.Value);
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.UnlockChunk, UnlockChunk>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.Nominations, Nominations>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.EnumRewardDestination, EnumRewardDestination>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.slashing.SlashingSpans, SlashingSpans>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.slashing.SpanRecord, SpanRecord>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.EnumReleases, Domain.Contracts.Secondary.Pallet.Staking.Enums.EnumReleases>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.UnappliedSlash, UnappliedSlash>();
                CreateMap<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_staking.ActiveEraInfo, ActiveEraInfo>();
            }

            public class BTreeMapT1Converter : ITypeConverter<BTreeMapT1, BaseVec<BaseTuple<SubstrateAccount, U32>>>
            {
                public BaseVec<BaseTuple<SubstrateAccount, U32>> Convert(BTreeMapT1 source, BaseVec<BaseTuple<SubstrateAccount, U32>> destination, ResolutionContext context)
                {
                    destination = new BaseVec<BaseTuple<SubstrateAccount, U32>>();
                    if (source == null) return destination;

                    context.Mapper.Map<BaseVec<BaseTuple<SubstrateAccount, U32>>>(source.Value);
                    return destination;
                }
            }

            public class BoundedVecT8Converter : ITypeConverter<BoundedVecT8, BaseVec<UnlockChunk>>
            {
                public BaseVec<UnlockChunk> Convert(BoundedVecT8 source, BaseVec<UnlockChunk> destination, ResolutionContext context)
                {
                    destination = new BaseVec<UnlockChunk>();
                    if (source == null) return destination;

                    context.Mapper.Map<BaseVec<UnlockChunk>>(source.Value);
                    return destination;
                }
            }

            public class BoundedVecT10Converter : ITypeConverter<BoundedVecT10, BaseVec<SubstrateAccount>>
            {
                public BaseVec<SubstrateAccount> Convert(BoundedVecT10 source, BaseVec<SubstrateAccount> destination, ResolutionContext context)
                {
                    destination = new BaseVec<SubstrateAccount>();
                    if (source == null) return destination;

                    context.Mapper.Map<BaseVec<SubstrateAccount>>(source.Value);
                    return destination;
                }
            }
        }

        public class XcmStorageProfile : Profile
        {
            public XcmStorageProfile()
            {
                CreateMap<DoubleEncodedT2, BaseVec<U8>>().ConvertUsing(x => x.Encoded);
            }
        }
        public class PerDispatchClassT1Converter : ITypeConverter<PerDispatchClassT1, FrameSupportDispatchPerDispatchClassWeight>
        {
            public FrameSupportDispatchPerDispatchClassWeight Convert(PerDispatchClassT1 source, FrameSupportDispatchPerDispatchClassWeight destination, ResolutionContext context)
            {
                destination = new FrameSupportDispatchPerDispatchClassWeight();
                if (source == null) return destination;

                destination.Create(source.Bytes);
                return destination;
            }
        }
        public class SubstrateAccountConverter : ITypeConverter<SubstrateAccount, AccountId32>
        {
            public AccountId32 Convert(SubstrateAccount source, AccountId32 destination, ResolutionContext context)
            {
                var account = new AccountId32();
                account.Create(source.Encode());

                return account;
            }
        }

        public class AccountId32Converter : ITypeConverter<AccountId32, SubstrateAccount>
        {
            public SubstrateAccount Convert(AccountId32 source, SubstrateAccount destination, ResolutionContext context)
            {
                //var hash = new Hash(source.Value.Encode());                
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
                if (source == null) return destination;

                destination.Create(context.Mapper.Map<T1, T2>(source.Value));
                return destination;
            }
        }

        public class H256Converter : ITypeConverter<H256, Hash>
        {
            public Hash Convert(H256 source, Hash destination, ResolutionContext context)
            {
                destination = new Hash();
                destination.Create(Utils.Bytes2HexString(source.Value.Encode()));

                return destination;
            }
        }

        public class HashConverter : ITypeConverter<Hash, H256>
        {
            public H256 Convert(Hash source, H256 destination, ResolutionContext context)
            {
                destination = new H256();
                destination.Create(source.Encode());

                return destination;
            }
        }

        public class ValidationCodeHashConverter : ITypeConverter<ValidationCodeHash, Hash>
        {
            public Hash Convert(ValidationCodeHash source, Hash destination, ResolutionContext context)
            {
                destination = new Hash();
                if (source == null) return destination;

                return context.Mapper.Map<H256, Hash>(source.Value);
            }
        }

        public class HashToValidationCodeConverter : ITypeConverter<Hash, ValidationCodeHash>
        {
            public ValidationCodeHash Convert(Hash source, ValidationCodeHash destination, ResolutionContext context)
            {
                destination = new ValidationCodeHash();
                if (source == null) return destination;

                destination.Create(source.Encode());

                return destination;
            }
        }

        public class BoundedVecT1Converter : ITypeConverter<BoundedVecT1, Hash>
        {
            public Hash Convert(BoundedVecT1 source, Hash destination, ResolutionContext context)
            {
                destination.Create(source.Bytes);
                return destination;
            }
        }
    }
}
