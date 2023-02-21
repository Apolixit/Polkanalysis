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
using static Substats.Domain.Contracts.Secondary.Pallet.Balances.BalanceLock;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types;
using static Substats.Infrastructure.Polkadot.Mapper.SubstrateMapper;
using Substats.Domain.Contracts.Core.Display;
using Substats.Polkadot.NetApiExt.Generated.Model.primitive_types;
using Ajuna.NetApi;
using Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.weak_bounded_vec;

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
            cfg.CreateMap<SubstrateAccount, AccountId32>().ConvertUsing(new SubstrateAccountConverter());
            cfg.CreateMap<H256, Hash>().ConvertUsing(new H256Converter());
            cfg.CreateMap<ValidationCodeHash, Hash>().ConvertUsing(new ValidationCodeHashConverter());


            cfg.CreateMap(typeof(BaseOpt<>), typeof(Nullable<>)).ConvertUsing(typeof(BaseOptConverter<>));
            cfg.CreateMap(typeof(BaseTuple<>), typeof(ValueTuple<,>)).ReverseMap().ConvertUsing(typeof(TupleConverter<,>));
            cfg.CreateMap<Arr8U8, string>().ConvertUsing(new Arr8U8Converter());
            cfg.CreateMap<Reasons, ReasonType>().ConvertUsingEnumMapping(opt => opt.MapByName());

            cfg.CreateMap<Arr0U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr1U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr2U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr3U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr4U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr5U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr6U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr7U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr8U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr9U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr10U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr11U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr12U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr13U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr14U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr15U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr16U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr17U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr18U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr19U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr20U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr21U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr22U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr23U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr24U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr25U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr26U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr27U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr28U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr29U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr30U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr31U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr32U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr32U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr32U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr32U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<Arr32U8, Nameable>().ConvertUsing(new NameableConverter());
            cfg.CreateMap<WeakBoundedVecT1, Nameable>().ConvertUsing(new NameableConverter());

        });
        

        /// <summary>
        /// Conversion from SubstrateAccount to AccountId32
        /// </summary>
        public class SubstrateAccountConverter : ITypeConverter<SubstrateAccount, AccountId32>
        {
            public AccountId32 Convert(SubstrateAccount source, AccountId32 destination, ResolutionContext context)
            {
                var account = new AccountId32();
                account.Create(source.Bytes);

                return account;
            }
        }

        public class Arr8U8Converter : ITypeConverter<Arr8U8, string>
        {
            public string Convert(Arr8U8 source, string destination, ResolutionContext context)
            {
                return source.ToString();
            }
        }

        public class NameableConverter : ITypeConverter<BaseType, Nameable>
        {
            public Nameable Convert(BaseType source, Nameable destination, ResolutionContext context)
            {
                return new Nameable(source);
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

        public class BaseOptConverter<T> : ITypeConverter<BaseOpt<T>, T?>
            where T : IType, new()
        {
            public T? Convert(BaseOpt<T> source, T? destination, ResolutionContext context)
            {
                if (!source.OptionFlag)
                    return default;

                return source.Value;
            }
        }

        public class H256Converter : ITypeConverter<H256, Hash>
        {
            public Hash Convert(H256 source, Hash destination, ResolutionContext context)
            {
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
    }
}
