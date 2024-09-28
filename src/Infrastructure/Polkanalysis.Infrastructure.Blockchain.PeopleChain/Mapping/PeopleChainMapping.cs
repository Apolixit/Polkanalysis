using AutoMapper;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.PeopleChain.Mapping
{
    public class PeopleChainMapping : CommonMapping
    {

        public IConfigurationProvider ConfigurationProvider => _mapper.ConfigurationProvider;

        public PeopleChainMapping(ILogger logger) : base(logger)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BaseTypeProfile>();
                //cfg.AddProfile<CommonProfile>();
                //cfg.AddProfile<EnumProfile>();
                //cfg.AddProfile<BytesProfile>();
                //cfg.AddProfile<AuctionsStorageProfile>();
                //cfg.AddProfile<AuthorshipStorageProfile>();
                //cfg.AddProfile<BabeStorageProfile>();
                //cfg.AddProfile<BalancesStorageProfile>();
                //cfg.AddProfile<CrowdloanStorageProfile>();
                //cfg.AddProfile<ConvictionStorageProfile>();
                //cfg.AddProfile<IdentityStorageProfile>();
                //cfg.AddProfile<SystemStorageProfile>();

                //cfg.ConstructServicesUsing(type => provider.GetService(type));
            });
        }
    }
}
