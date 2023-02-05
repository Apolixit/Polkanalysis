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
            cfg.CreateMap<Arr8U8, string>().ConvertUsing(new Arr8U8Converter());
            cfg.CreateMap<Reasons, ReasonType>().ConvertUsingEnumMapping(opt => opt.MapByName());
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
    }
}
