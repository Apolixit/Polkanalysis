using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substats.Domain.Contracts.Core;

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
            cfg.CreateMap<SubstrateAccount, Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>().ConvertUsing(new SubstrateAccountConverter());
        });

        public void Test()
        {
            //configuration.CreateMapper().
        }
        

        /// <summary>
        /// Conversion from SubstrateAccount to AccountId32
        /// </summary>
        public class SubstrateAccountConverter : ITypeConverter<SubstrateAccount, Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>
        {
            public AccountId32 Convert(SubstrateAccount source, AccountId32 destination, ResolutionContext context)
            {
                var account = new AccountId32();
                account.Create(source.Bytes);

                return account;
            }
        }
    }
}
