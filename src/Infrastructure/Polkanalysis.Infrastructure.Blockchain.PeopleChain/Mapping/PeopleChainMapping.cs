using AutoMapper;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Core.Display;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums;
using Polkanalysis.Infrastructure.Blockchain.Exceptions;
using Polkanalysis.Infrastructure.Blockchain.Mapping;
using Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.polkadot_parachain_primitives.primitives;
using Polkanalysis.PeopleChain.NetApiExt.Generated.Model.vbase.primitive_types;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

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
                cfg.AddProfile<EnumProfile>();
                cfg.AddProfile<CommonProfile>();
                cfg.AddProfile<IdentityStorageProfile>();
                cfg.AddProfile<ParachainInfoStorageProfile>();

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
    }
}
