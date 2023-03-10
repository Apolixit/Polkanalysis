using System;
using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using Substats.Domain.Contracts.Core;
using Substats.Polkadot.NetApiExt.Generated.Types.Base;
using Substats.Polkadot.NetApiExt.Generated.Model.pallet_balances;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types;
using Substats.Domain.Contracts.Core.Display;
using Substats.Polkadot.NetApiExt.Generated.Model.primitive_types;
using Ajuna.NetApi;
using Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.weak_bounded_vec;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec;
using Substats.AjunaExtension.Encoding;
using Substats.Polkadot.NetApiExt.Generated.Model.frame_support.traits.tokens.misc;
using static Substats.Infrastructure.Polkadot.Mapper.SubstrateMapper;
using Org.BouncyCastle.Math.EC.Rfc7748;
using static Substats.Infrastructure.Polkadot.Mapper.SubstrateMapper.AuctionsStorageProfile;
using Substats.Polkadot.NetApiExt.Generated.Model.pallet_im_online.sr25519.app_sr25519;
using Substats.Domain.Contracts.Core.Random;
using Substats.Domain.Contracts.Secondary.Pallet.SystemCore;
using Substats.Polkadot.NetApiExt.Generated.Model.frame_support.dispatch;
using Substats.Domain.Contracts.Secondary.Pallet.Auctions;
using Substats.Domain.Contracts.Secondary.Pallet.SystemCore.Enums;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System.Numerics;
using Substats.Domain.Contracts.Secondary.Pallet.Authorship;

namespace Substats.Infrastructure.Polkadot.Mapper
{
    public class SubstrateMapper
    {
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
            cfg.AddProfile<BytesProfile>();
            cfg.AddProfile<AuctionsStorageProfile>();
            cfg.AddProfile<AuthorshipStorageProfile>();
            cfg.AddProfile<BalancesStorageProfile>();
            cfg.AddProfile<BabeStorageProfile>();
            cfg.AddProfile<ParachainStorageProfile>();
            cfg.AddProfile<SchedulerStorageProfile>();
            cfg.AddProfile<SystemStorageProfile>();

            //cfg.CreateMap<Arr8U8, string>().ConvertUsing((i, o) => o.ToString());
            //cfg.CreateMap<Substats.Polkadot.NetApiExt.Generated.Model.pallet_balances.Reasons, Substats.Domain.Contracts.Secondary.Pallet.Balances.Enums.Reasons>().ConvertUsingEnumMapping(opt => opt.MapByName());
            //cfg.CreateMap<Substats.Polkadot.NetApiExt.Generated.Model.pallet_authorship.EnumUncleEntryItem, Domain.Contracts.Secondary.Pallet.Authorship.EnumUncleEntryItem>().ConvertUsingEnumMapping(opt => opt.MapByName());

            
            
            

            

        });

        public class BytesProfile : Profile
        {
            public BytesProfile() {
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
                CreateMap<ValidationCodeHash, Hash>().ConvertUsing(new ValidationCodeHashConverter());
                
                CreateMap<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.sr25519.Public, PublicSr25519>().ConvertUsing(x => new PublicSr25519(x.Value.Value));
                CreateMap<PublicSr25519, Substats.Polkadot.NetApiExt.Generated.Model.sp_core.sr25519.Public>();
                
                CreateMap<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.ed25519.Public, PublicEd25519>().ConvertUsing(x => new PublicEd25519(x.Value.Value));
                CreateMap<PublicEd25519, Substats.Polkadot.NetApiExt.Generated.Model.sp_core.ed25519.Public>();
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
            }

            private void BaseComMapping<T>()
                where T : IType, new()
                => CreateMap<BaseCom<T>, T>().ConvertUsing(new BaseComConverter<T>());

            public class BaseComConverter<T> : ITypeConverter<BaseCom<T>, T>
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
        }

        public class NameableProfile : Profile
        {
            public NameableProfile()
            {
                CreateMap<Arr0U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr1U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr2U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr3U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr4U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr5U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr6U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr7U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr8U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr9U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr10U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr11U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr12U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr13U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr14U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr15U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr16U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr17U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr18U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr19U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr20U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr21U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr22U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr23U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr24U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr25U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr26U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr27U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr28U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr29U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr30U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr31U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr32U8, Nameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr32U8, Hexa>().ConvertUsing(x => new Hexa(x));
                CreateMap<WeakBoundedVecT1, Nameable>().ConvertUsing(new NameableConverter());
            }
        }

        public class AuthorshipStorageProfile : Profile
        {
            public AuthorshipStorageProfile()
            {
                CreateMap<BoundedVecT7, BaseVec<EnumUncleEntryItem>>()
                    .ConvertUsing(x => Instance.Map<BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.pallet_authorship.EnumUncleEntryItem>, BaseVec<EnumUncleEntryItem>>(x.Value));

                CreateMap<Substats.Polkadot.NetApiExt.Generated.Model.pallet_authorship.EnumUncleEntryItem, EnumUncleEntryItem>();
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
                            BaseOpt<BaseTuple<AccountId32, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, U128>>, 
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
                CreateMap<ReserveData, Substats.Domain.Contracts.Secondary.Pallet.Balances.ReserveData>();
                // Map BoundedVecT6 to Domain
                CreateMap<BoundedVecT6, BaseVec<Domain.Contracts.Secondary.Pallet.Balances.ReserveData>>().ConvertUsing(x => Instance.Map<BaseVec<ReserveData>, BaseVec<Domain.Contracts.Secondary.Pallet.Balances.ReserveData>>(x.Value));

                // Events
                CreateMap<EnumBalanceStatus, Substats.Domain.Contracts.Secondary.Pallet.Balances.Enums.EnumBalanceStatus>();
                CreateMap<EnumReasons, Domain.Contracts.Secondary.Pallet.Balances.Enums.EnumReasons>();
                CreateMap<Substats.Domain.Contracts.Secondary.Pallet.Balances.Enums.EnumEvent, Domain.Contracts.Secondary.Pallet.Balances.Enums.EnumEvent>();
            }
        }

        public class BabeStorageProfile : Profile
        {
            public BabeStorageProfile()
            {
                CreateMap<Substats.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.app.Public, PublicSr25519>().ConvertUsing(x => Instance.Map<
                    Substats.Polkadot.NetApiExt.Generated.Model.sp_core.sr25519.Public, PublicSr25519>(x.Value));
                CreateMap<WeakBoundedVecT2, BaseVec<BaseTuple<PublicSr25519, U64>>>().ConvertUsing(typeof(WeakBoundedVecT2Converter));
                CreateMap<BoundedVecT5, BaseVec<Hexa>>().ConvertUsing(typeof(WeakBoundedVecT2Converter));


                CreateMap<Substats.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.BabeEpochConfiguration, Domain.Contracts.Secondary.Pallet.Babe.BabeEpochConfiguration>();
                CreateMap<Substats.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.EnumAllowedSlots, Domain.Contracts.Secondary.Pallet.Babe.EnumAllowedSlots>();
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
                        BaseVec<BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.app.Public, U64>>,
                        BaseVec<BaseTuple<PublicSr25519, U64>>>(source.Value);

                    return destination;
                }
            }
        }

        public class ParachainStorageProfile : Profile
        {
            public ParachainStorageProfile()
            {
                CreateMap<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Domain.Contracts.Core.Id>().ConvertUsing((s, d) => new Domain.Contracts.Core.Id(s.Value.Value));
                CreateMap<Domain.Contracts.Core.Id, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>();
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
                CreateMap<Substats.Polkadot.NetApiExt.Generated.Model.frame_system.AccountInfo, AccountInfo>();
                //CreateMap<PerDispatchClassT1, FrameSupportDispatchPerDispatchClassWeight>().ConvertUsing(new PerDispatchClassT1Converter());
                CreateMap<PerDispatchClassT1, FrameSupportDispatchPerDispatchClassWeight>();
                CreateMap<Substats.Polkadot.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight, Weight>();
                CreateMap<Substats.Polkadot.NetApiExt.Generated.Model.sp_runtime.generic.digest.Digest, Digest>();
                CreateMap<Substats.Polkadot.NetApiExt.Generated.Model.frame_system.EventRecord, EventRecord>();
            }
        }

        /// <summary>
        /// Conversion from SubstrateAccount to AccountId32
        /// </summary>
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
                account.Create(source.Bytes);

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

        public class NameableConverter : ITypeConverter<BaseType, Nameable>
        {
            public Nameable Convert(BaseType source, Nameable destination, ResolutionContext context)
            {
                return new Nameable(source);
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

                if (source == null) return destination;

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

        public class ValidationCodeHashConverter : ITypeConverter<ValidationCodeHash, Hash>
        {
            public Hash Convert(ValidationCodeHash source, Hash destination, ResolutionContext context)
            {
                return context.Mapper.Map<Hash>(source.Value);
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
