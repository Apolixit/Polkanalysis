using AutoMapper;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Random;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Types;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Infrastructure.Blockchain.Exceptions;
using Polkanalysis.Infrastructure.Blockchain.Mapping;
using Polkanalysis.Mythos.NetApiExt.Generated.Types.Base;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.Numerics;

namespace Polkanalysis.Infrastructure.Blockchain.Mythos.Mapping
{
    public class MythosMapping : CommonMapping
    {
        public MythosMapping(ILogger<MythosMapping> logger) : base(logger)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BaseTypeProfile>();
                cfg.AddProfile<EnumProfile>();
                cfg.AddProfile<CommonMythosProfile>();
                cfg.AddProfile<NftStorageProfile>();
                cfg.AddProfile<SystemStorageProfile>();
                cfg.AddProfile<NameableProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        public class CommonMythosProfile : Profile
        {
            public CommonMythosProfile()
            {
                CreateMap<Polkanalysis.Mythos.NetApiExt.Generated.Model.vbase.account.AccountId20Base, SubstrateAccount>().ConvertUsing(new AccountId20Converter());
                CreateMap<Polkanalysis.Mythos.NetApiExt.Generated.Model.vbase.runtime_common.IncrementableU256Base, IncrementableU256>()
                    .ConvertUsing(new IncrementableU256Converter());
            }

            public class AccountId20Converter : ITypeConverter<Polkanalysis.Mythos.NetApiExt.Generated.Model.vbase.account.AccountId20Base, SubstrateAccount>
            {
                public SubstrateAccount Convert(Polkanalysis.Mythos.NetApiExt.Generated.Model.vbase.account.AccountId20Base source, SubstrateAccount destination, ResolutionContext context)
                {
                    destination = new SubstrateAccount();
                    if (source is null || source.Value is null) return destination;

                    destination = new SubstrateAccount(source.Value.Value);

                    return destination;
                }
            }

            public class IncrementableU256Converter : ITypeConverter<Polkanalysis.Mythos.NetApiExt.Generated.Model.vbase.runtime_common.IncrementableU256Base, IncrementableU256>
            {
                public IncrementableU256 Convert(Polkanalysis.Mythos.NetApiExt.Generated.Model.vbase.runtime_common.IncrementableU256Base source, IncrementableU256 destination, ResolutionContext context)
                {
                    destination = new IncrementableU256();
                    if (source is null || source.Value is null) return destination;

                    BigInteger bigInt = BigInteger.Zero;

                    for (int i = 0; i < 4; i++)
                    {
                        // Shift the part back to its original position and add to BigInteger
                        bigInt |= (BigInteger)source.Value.Value.Value[i].Value << (64 * i);
                    }

                    destination.Value = new U256(bigInt);

                    return destination;
                }
            }
        }

        public class NftStorageProfile : Profile
        {
            public NftStorageProfile()
            {
                CreateMap<Polkanalysis.Mythos.NetApiExt.Generated.Model.vbase.pallet_nfts.types.PriceWithDirectionBase, PriceWithDirection>().IncludeAllDerived();
            }
        }

        public class SystemStorageProfile : Profile
        {
            public SystemStorageProfile()
            {
                CreateMap<Polkanalysis.Mythos.NetApiExt.Generated.Model.vbase.frame_system.EventRecordBase, EventRecord>().ConvertUsing(new EventRecordConverter());
            }

            public class EventRecordConverter : ITypeConverter<Polkanalysis.Mythos.NetApiExt.Generated.Model.vbase.frame_system.EventRecordBase, EventRecord>
            {
                public EventRecord Convert(Polkanalysis.Mythos.NetApiExt.Generated.Model.vbase.frame_system.EventRecordBase source, EventRecord destination, ResolutionContext context)
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
        }

        public class NameableProfile : Profile
        {
            public NameableProfile()
            {
                CreateMap<Arr4U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr8U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr16U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr20U8, FlexibleNameable>().ConvertUsing(new NameableConverter());
                CreateMap<Arr32U8, FlexibleNameable>().ConvertUsing(new NameableConverter());

                CreateMap<BaseVec<U8>, FlexibleNameable>().ConvertUsing(x => new FlexibleNameable().FromU8(x.Value));

                CreateMap<Arr32U8, Hexa32>().ConvertUsing(x => new Hexa32(x));

                CreateMap<Arr4U8, NameableSize4>().ConvertUsing(x => new NameableSize4(x));
                CreateMap<Arr8U8, NameableSize8>().ConvertUsing(x => new NameableSize8(x));
                CreateMap<Arr16U8, NameableSize16>().ConvertUsing(x => new NameableSize16(x));
                CreateMap<Arr20U8, NameableSize20>().ConvertUsing(x => new NameableSize20(x));
                CreateMap<Arr32U8, NameableSize32>().ConvertUsing(x => new NameableSize32(x));

            }
        }
    }
}
