using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping.PolkadotMapping;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping
{
    public static class PolkadotMapperExtension
    {
        public static IServiceCollection AddPolkadotMapper(this IServiceCollection services)
        {
            //var mapperConfig = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<BaseTypeProfile>();
            //    cfg.AddProfile<CommonProfile>();
            //    cfg.AddProfile<EnumProfile>();
            //    cfg.AddProfile<BytesProfile>();
            //    cfg.AddProfile<AuctionsStorageProfile>();
            //    cfg.AddProfile<AuthorshipStorageProfile>();
            //    cfg.AddProfile<BalancesStorageProfile>();
            //    cfg.AddProfile<CrowdloanStorageProfile>();
            //    cfg.AddProfile<DemocracyStorageProfile>();
            //    cfg.AddProfile<IdentityStorageProfile>();
            //    cfg.AddProfile<NominationPoolsStorageProfile>();
            //    //cfg.AddProfile<BabeStorageProfile>();
            //    cfg.AddProfile<ParaSessionInfoStorageProfile>();
            //    cfg.AddProfile<ParachainStorageProfile>();
            //    cfg.AddProfile<RegistarStorageProfile>();
            //    cfg.AddProfile<SchedulerStorageProfile>();
            //    cfg.AddProfile<SessionStorageProfile>();
            //    cfg.AddProfile<SystemStorageProfile>();
            //    cfg.AddProfile<StakingStorageProfile>();
            //    cfg.AddProfile<XcmStorageProfile>();
            //});

            //IMapper mapper = mapperConfig.CreateMapper();

            //services.AddSingleton(mapper);
            services.AddTransient<IBlockchainMapping, PolkadotMapping>();
            return services;
        }
    }
}
