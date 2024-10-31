using AutoMapper;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;
using Polkanalysis.Infrastructure.Blockchain.Exceptions;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using System.Diagnostics;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Multi;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.DispatchInfo;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Enum;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Error;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Mapping
{
    public abstract class CommonMapping : IBlockchainMapping
    {
        protected IMapper _mapper = default!;
        protected readonly ILogger _logger;

        public CommonMapping(ILogger logger)
        {
            _logger = logger;
        }

        public IConfigurationProvider ConfigurationProvider => _mapper.ConfigurationProvider;

        public class BaseTypeProfile : Profile
        {
            public BaseTypeProfile()
            {
                CreateMap(typeof(BaseOpt<>), typeof(Nullable<>)).ConvertUsing(typeof(BaseOptNullConverter<>));
                CreateMap(typeof(BaseOpt<>), typeof(BaseOpt<>)).ConvertUsing(typeof(BaseOptConverter<,>));
                CreateMap(typeof(BaseTuple<,>), typeof(ValueTuple<,>)).ConvertUsing(typeof(TupleConverter<,>));
                CreateMap(typeof(BaseTuple<,>), typeof(BaseTuple<,>)).ConvertUsing(typeof(BaseTupleConverter<,,,>));
                CreateMap(typeof(BaseTuple<,,>), typeof(BaseTuple<,,>)).ConvertUsing(typeof(BaseTupleConverter<,,,,,>));
                CreateMap(typeof(BaseTuple<,,,>), typeof(BaseTuple<,,,>)).ConvertUsing(typeof(BaseTupleConverter<,,,,,,,>));
                CreateMap(typeof(BaseTuple<,,,,>), typeof(BaseTuple<,,,,>)).ConvertUsing(typeof(BaseTupleConverter<,,,,,,,,,>));
                CreateMap(typeof(BaseVec<>), typeof(BaseVec<>)).ConvertUsing(typeof(BaseVecConverter<,>));
                CreateMap(typeof(BaseCom<>), typeof(BaseCom<>)).ConvertUsing(typeof(BaseComConverter<,>));

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
                //BaseComMapping<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.per_things.PerbillBase>();
                BaseComMapping<Perbill>();
            }

            protected void BaseComMapping<T>()
                where T : IType, new()
            {
                CreateMap<BaseCom<T>, T>().ConvertUsing(new BaseComToGenericConverter<T>());
                CreateMap<T, BaseCom<T>>().ConvertUsing(new GenericToBaseComConverter<T>());
            }

            protected void BaseComCoreMapping<T, U>()
                where T : IType
                where U : IType, new()
            {
                CreateMap<T, BaseCom<U>>().ConvertUsing(new GenericToBaseComCoreConverter<T, U>());
            }

            protected class BaseComToGenericConverter<T> : ITypeConverter<BaseCom<T>, T>
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

            protected class GenericToBaseComConverter<T> : ITypeConverter<T, BaseCom<T>>
                where T : IType, new()
            {
                public BaseCom<T> Convert(T source, BaseCom<T> destination, ResolutionContext context)
                {
                    CompactInteger compactNum = CompactIntegerMap(source);

                    destination = new BaseCom<T>(compactNum);
                    return destination;
                }
            }

            protected class GenericToBaseComCoreConverter<T, U> : ITypeConverter<T, BaseCom<U>>
                where T : IType
                where U : IType, new()
            {
                public BaseCom<U> Convert(T source, BaseCom<U> destination, ResolutionContext context)
                {
                    destination = new BaseCom<U>();

                    var mapped = context.Mapper.Map<T, U>(source);
                    CompactInteger compactNum = CompactIntegerMap(mapped);

                    destination = new BaseCom<U>(compactNum);
                    return destination;
                }
            }

            protected static CompactInteger CompactIntegerMap<U>(U mapped)
                    where U : IType, new()
            {
                CompactInteger compactNum = new CompactInteger();
                switch (mapped)
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
                    case Perbill num:
                        compactNum = new CompactInteger(num.Value);
                        break;
                }

                return compactNum;
            }

            protected class BaseComConverter<T1, T2> : ITypeConverter<BaseCom<T1>, BaseCom<T2>>
                where T1 : IType, new()
                where T2 : IType, new()
            {
                public BaseCom<T2> Convert(BaseCom<T1> source, BaseCom<T2> destination, ResolutionContext context)
                {
                    destination = new BaseCom<T2>();
                    if (source == null) return destination;

                    T1? t1;
                    try
                    {
                        t1 = context.Mapper.Map<BaseCom<T1>, T1>(source);
                    }
                    catch
                    {
                        // Ugly hack, need to find a better solution
                        t1 = new T1();
                        var bytes = source.Value.Value.ToByteArray().CompleteByteArray(4);
                        t1.Create(bytes);
                    }
                    var t2 = context.Mapper.Map<T1, T2>(t1);

                    destination = context.Mapper.Map<T2, BaseCom<T2>>(t2);

                    return destination;
                }
            }

            protected class BaseEnumConverter<I0, D0> : ITypeConverter<BaseEnum<I0>, BaseEnum<D0>>
                where I0 : Enum
                where D0 : struct, Enum
            {
                public BaseEnum<D0> Convert(BaseEnum<I0> source, BaseEnum<D0> destination, ResolutionContext context)
                {
                    destination = new BaseEnum<D0>();
                    if (source == null) return destination;

                    return (BaseEnum<D0>)MapEnumInternal(source, typeof(BaseEnum<D0>));
                }
            }

            protected class BaseEnumExtConverter<I0, I1, D0, D1> : ITypeConverter<BaseEnumExt<I0, I1>, BaseEnumExt<D0, D1>>
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

            protected class BaseEnumExtConverter<I0, I1, I2, D0, D1, D2> :
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

            protected class BaseEnumExtConverter<
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

        public class EnumProfile : Profile
        {
            public EnumProfile()
            {
                CreateMap<IType, EnumDispatchClass>().ConvertUsing(new EnumConverter<EnumDispatchClass>());
                CreateMap<IType, EnumPays>().ConvertUsing(new EnumConverter<EnumPays>());
                CreateMap<IType, EnumRawOrigin>().ConvertUsing(new EnumConverter<EnumRawOrigin>());
                CreateMap<IType, EnumResult>().ConvertUsing(new EnumConverter<EnumResult>());
                CreateMap<IType, EnumArithmeticError>().ConvertUsing(new EnumConverter<EnumArithmeticError>());
                CreateMap<IType, EnumDispatchError>().ConvertUsing(new EnumConverter<EnumDispatchError>());
                CreateMap<IType, EnumTokenError>().ConvertUsing(new EnumConverter<EnumTokenError>());
                CreateMap<IType, EnumTransactionalError>().ConvertUsing(new EnumConverter<EnumTransactionalError>());
                CreateMap<IType, EnumMultiAddress>().ConvertUsing(new EnumConverter<EnumMultiAddress>());
                CreateMap<IType, EnumMultiSignature>().ConvertUsing(new EnumConverter<EnumMultiSignature>());
                CreateMap<IType, EnumMultiSigner>().ConvertUsing(new EnumConverter<EnumMultiSigner>());
                CreateMap<IType, Contracts.Pallet.Authorship.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Authorship.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.Authorship.Enums.EnumUncleEntryItem>().ConvertUsing(new EnumConverter<Contracts.Pallet.Authorship.Enums.EnumUncleEntryItem>());
                CreateMap<IType, Contracts.Pallet.Babe.Enums.EnumAllowedSlots>().ConvertUsing(new EnumConverter<Contracts.Pallet.Babe.Enums.EnumAllowedSlots>());
                CreateMap<IType, Contracts.Pallet.Babe.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Babe.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.Babe.Enums.EnumNextConfigDescriptor>().ConvertUsing(new EnumConverter<Contracts.Pallet.Babe.Enums.EnumNextConfigDescriptor>());
                CreateMap<IType, Contracts.Pallet.Babe.Enums.EnumPreDigest>().ConvertUsing(new EnumConverter<Contracts.Pallet.Babe.Enums.EnumPreDigest>());
                CreateMap<IType, Contracts.Pallet.BagsList.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.BagsList.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.BagsList.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.BagsList.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.BagsList.Enums.EnumListError>().ConvertUsing(new EnumConverter<Contracts.Pallet.BagsList.Enums.EnumListError>());
                CreateMap<IType, Contracts.Pallet.Balances.Enums.EnumBalanceStatus>().ConvertUsing(new EnumConverter<Contracts.Pallet.Balances.Enums.EnumBalanceStatus>());
                CreateMap<IType, Contracts.Pallet.Balances.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Balances.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.Balances.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.Balances.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.Balances.Enums.EnumReasons>().ConvertUsing(new EnumConverter<Contracts.Pallet.Balances.Enums.EnumReasons>());
                CreateMap<IType, Contracts.Pallet.Balances.Enums.EnumReleases>().ConvertUsing(new EnumConverter<Contracts.Pallet.Balances.Enums.EnumReleases>());
                CreateMap<IType, Contracts.Pallet.Bounties.Enums.EnumBountyStatus>().ConvertUsing(new EnumConverter<Contracts.Pallet.Bounties.Enums.EnumBountyStatus>());
                CreateMap<IType, Contracts.Pallet.Bounties.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Bounties.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.Bounties.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.Bounties.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.ChildBounties.Enums.EnumChildBountyStatus>().ConvertUsing(new EnumConverter<Contracts.Pallet.ChildBounties.Enums.EnumChildBountyStatus>());
                CreateMap<IType, Contracts.Pallet.ChildBounties.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.ChildBounties.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.ChildBounties.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.ChildBounties.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.Collective.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Collective.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.Collective.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.Collective.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.Collective.Enums.EnumRawOrigin>().ConvertUsing(new EnumConverter<Contracts.Pallet.Collective.Enums.EnumRawOrigin>());
                CreateMap<IType, Contracts.Pallet.ConvictionVoting.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.ConvictionVoting.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.ConvictionVoting.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.ConvictionVoting.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.Crowdloan.EnumLastContribution>().ConvertUsing(new EnumConverter<Contracts.Pallet.Crowdloan.EnumLastContribution>());
                CreateMap<IType, Contracts.Pallet.Democracy.Enums.EnumAccountVote>().ConvertUsing(new EnumConverter<Contracts.Pallet.Democracy.Enums.EnumAccountVote>());
                CreateMap<IType, Contracts.Pallet.Democracy.Enums.EnumConviction>().ConvertUsing(new EnumConverter<Contracts.Pallet.Democracy.Enums.EnumConviction>());
                CreateMap<IType, Contracts.Pallet.Democracy.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Democracy.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.Democracy.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.Democracy.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.Democracy.Enums.EnumPreimageStatus>().ConvertUsing(new EnumConverter<Contracts.Pallet.Democracy.Enums.EnumPreimageStatus>());
                CreateMap<IType, Contracts.Pallet.Democracy.Enums.EnumReferendumInfo>().ConvertUsing(new EnumConverter<Contracts.Pallet.Democracy.Enums.EnumReferendumInfo>());
                CreateMap<IType, Contracts.Pallet.Democracy.Enums.EnumReleases>().ConvertUsing(new EnumConverter<Contracts.Pallet.Democracy.Enums.EnumReleases>());
                CreateMap<IType, Contracts.Pallet.Democracy.Enums.EnumVoteThreshold>().ConvertUsing(new EnumConverter<Contracts.Pallet.Democracy.Enums.EnumVoteThreshold>());
                CreateMap<IType, Contracts.Pallet.Democracy.Enums.EnumVoting>().ConvertUsing(new EnumConverter<Contracts.Pallet.Democracy.Enums.EnumVoting>());
                CreateMap<IType, Contracts.Pallet.ElectionProviderMultiPhase.Enums.EnumElectionCompute>().ConvertUsing(new EnumConverter<Contracts.Pallet.ElectionProviderMultiPhase.Enums.EnumElectionCompute>());
                CreateMap<IType, Contracts.Pallet.ElectionProviderMultiPhase.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.ElectionProviderMultiPhase.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.ElectionProviderMultiPhase.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.ElectionProviderMultiPhase.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.ElectionProviderMultiPhase.Enums.EnumPhase>().ConvertUsing(new EnumConverter<Contracts.Pallet.ElectionProviderMultiPhase.Enums.EnumPhase>());
                CreateMap<IType, Contracts.Pallet.ElectionsPhragmen.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.ElectionsPhragmen.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.ElectionsPhragmen.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.ElectionsPhragmen.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.ElectionsPhragmen.Enums.EnumRenouncing>().ConvertUsing(new EnumConverter<Contracts.Pallet.ElectionsPhragmen.Enums.EnumRenouncing>());
                CreateMap<IType, Contracts.Pallet.FastUnstake.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.FastUnstake.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.FastUnstake.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.FastUnstake.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.GrandPa.Enums.EnumEquivocation>().ConvertUsing(new EnumConverter<Contracts.Pallet.GrandPa.Enums.EnumEquivocation>());
                CreateMap<IType, Contracts.Pallet.GrandPa.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.GrandPa.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.GrandPa.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.GrandPa.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.GrandPa.Enums.EnumStoredState>().ConvertUsing(new EnumConverter<Contracts.Pallet.GrandPa.Enums.EnumStoredState>());
                CreateMap<IType, Contracts.Pallet.Identity.Enums.EnumData>().ConvertUsing(new EnumConverter<Contracts.Pallet.Identity.Enums.EnumData>());
                CreateMap<IType, Contracts.Pallet.Identity.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Identity.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.Identity.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.Identity.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.Identity.Enums.EnumIdentityField>().ConvertUsing(new EnumConverter<Contracts.Pallet.Identity.Enums.EnumIdentityField>());
                CreateMap<IType, Contracts.Pallet.Identity.Enums.EnumJudgement>().ConvertUsing(new EnumConverter<Contracts.Pallet.Identity.Enums.EnumJudgement>());
                CreateMap<IType, Contracts.Pallet.ImOnline.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.ImOnline.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.ImOnline.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.ImOnline.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.Indices.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Indices.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.Indices.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.Indices.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.Membership.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Membership.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.Membership.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.Membership.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.MessageQueue.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.MessageQueue.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.MessageQueue.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.MessageQueue.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.Multisig.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Multisig.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.Multisig.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.Multisig.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.NominationPools.Enums.EnumBondExtra>().ConvertUsing(new EnumConverter<Contracts.Pallet.NominationPools.Enums.EnumBondExtra>());
                CreateMap<IType, Contracts.Pallet.NominationPools.Enums.EnumClaimPermission>().ConvertUsing(new EnumConverter<Contracts.Pallet.NominationPools.Enums.EnumClaimPermission>());
                CreateMap<IType, Contracts.Pallet.NominationPools.Enums.EnumConfigOp>().ConvertUsing(new EnumConverter<Contracts.Pallet.NominationPools.Enums.EnumConfigOp>());
                CreateMap<IType, Contracts.Pallet.NominationPools.Enums.EnumDefensiveError>().ConvertUsing(new EnumConverter<Contracts.Pallet.NominationPools.Enums.EnumDefensiveError>());
                CreateMap<IType, Contracts.Pallet.NominationPools.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.NominationPools.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.NominationPools.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.NominationPools.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.NominationPools.Enums.EnumPoolState>().ConvertUsing(new EnumConverter<Contracts.Pallet.NominationPools.Enums.EnumPoolState>());
                CreateMap<IType, Contracts.Pallet.Offences.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.Offences.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.Paras.Enums.EnumParaLifecycle>().ConvertUsing(new EnumConverter<Contracts.Pallet.Paras.Enums.EnumParaLifecycle>());
                CreateMap<IType, Contracts.Pallet.Paras.Enums.EnumPvfCheckCause>().ConvertUsing(new EnumConverter<Contracts.Pallet.Paras.Enums.EnumPvfCheckCause>());
                CreateMap<IType, Contracts.Pallet.Paras.Enums.EnumUpgradeGoAhead>().ConvertUsing(new EnumConverter<Contracts.Pallet.Paras.Enums.EnumUpgradeGoAhead>());
                CreateMap<IType, Contracts.Pallet.Paras.Enums.EnumUpgradeRestriction>().ConvertUsing(new EnumConverter<Contracts.Pallet.Paras.Enums.EnumUpgradeRestriction>());
                CreateMap<IType, Contracts.Pallet.ParaSessionInfo.Enums.EnumExecutorParam>().ConvertUsing(new EnumConverter<Contracts.Pallet.ParaSessionInfo.Enums.EnumExecutorParam>());
                CreateMap<IType, Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotPrimitive.v2.Enum.EnumCoreOccupied>().ConvertUsing(new EnumConverter<Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotPrimitive.v2.Enum.EnumCoreOccupied>());
                CreateMap<IType, Contracts.Pallet.PolkadotPrimitive.v2.Enum.EnumDisputeStatement>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotPrimitive.v2.Enum.EnumDisputeStatement>());
                CreateMap<IType, Contracts.Pallet.PolkadotPrimitive.v2.Enum.EnumInvalidDisputeStatementKind>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotPrimitive.v2.Enum.EnumInvalidDisputeStatementKind>());
                CreateMap<IType, Contracts.Pallet.PolkadotPrimitive.v2.Enum.EnumValidDisputeStatementKind>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotPrimitive.v2.Enum.EnumValidDisputeStatementKind>());
                CreateMap<IType, Contracts.Pallet.PolkadotPrimitive.v2.Enum.EnumValidityAttestation>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotPrimitive.v2.Enum.EnumValidityAttestation>());
                CreateMap<IType, Contracts.Pallet.PolkadotPrimitive.v4.EnumPvfExecTimeoutKind>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotPrimitive.v4.EnumPvfExecTimeoutKind>());
                CreateMap<IType, Contracts.Pallet.PolkadotPrimitive.v4.EnumPvfPrepTimeoutKind>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotPrimitive.v4.EnumPvfPrepTimeoutKind>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntime.EnumOriginCaller>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntime.EnumOriginCaller>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntime.EnumProxyType>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntime.EnumProxyType>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntime.EnumRuntimeEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntime.EnumRuntimeEvent>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeCommon.Auctions.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeCommon.Auctions.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeCommon.Auctions.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeCommon.Auctions.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeCommon.Claims.Enum.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeCommon.Claims.Enum.EnumError>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeCommon.Claims.Enum.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeCommon.Claims.Enum.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums.EnumLastContribution>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeCommon.Crowdloan.Enums.EnumLastContribution>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeCommon.ParasRegistar.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeCommon.ParasRegistar.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeCommon.ParasRegistar.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeCommon.ParasRegistar.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeCommon.Slots.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeCommon.Slots.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeCommon.Slots.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeCommon.Slots.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeParachain.Configuration.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeParachain.Configuration.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeParachain.Disputes.Enums.EnumDisputeLocation>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeParachain.Disputes.Enums.EnumDisputeLocation>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeParachain.Disputes.Enums.EnumDisputeResult>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeParachain.Disputes.Enums.EnumDisputeResult>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeParachain.Disputes.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeParachain.Disputes.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeParachain.Disputes.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeParachain.Disputes.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeParachain.Hrmp.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeParachain.Hrmp.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeParachain.Hrmp.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeParachain.Hrmp.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeParachain.Inclusion.Enums.EnumAggregateMessageOrigin>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeParachain.Inclusion.Enums.EnumAggregateMessageOrigin>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeParachain.Inclusion.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeParachain.Inclusion.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeParachain.Inclusion.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeParachain.Inclusion.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeParachain.Inclusion.Enums.EnumUmpQueueId>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeParachain.Inclusion.Enums.EnumUmpQueueId>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeParachain.Origin.Enums.EnumOrigin>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeParachain.Origin.Enums.EnumOrigin>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeParachain.ParaInherent.Enum.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeParachain.ParaInherent.Enum.EnumError>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeParachain.Paras.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeParachain.Paras.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeParachain.Paras.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeParachain.Paras.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeParachain.Scheduler.Enums.EnumAssignmentKind>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeParachain.Scheduler.Enums.EnumAssignmentKind>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeParachain.Ump.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeParachain.Ump.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.PolkadotRuntimeParachain.Ump.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.PolkadotRuntimeParachain.Ump.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.PreImage.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.PreImage.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.PreImage.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.PreImage.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.PreImage.Enums.EnumRequestStatus>().ConvertUsing(new EnumConverter<Contracts.Pallet.PreImage.Enums.EnumRequestStatus>());
                CreateMap<IType, Contracts.Pallet.Proxy.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Proxy.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.Proxy.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.Proxy.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.Proxy.Enums.EnumProxyType>().ConvertUsing(new EnumConverter<Contracts.Pallet.Proxy.Enums.EnumProxyType>());
                CreateMap<IType, Contracts.Pallet.Referenda.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Referenda.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.Referenda.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.Referenda.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.Scheduler.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Scheduler.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.Scheduler.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.Scheduler.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.Session.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Session.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.Session.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.Session.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.Staking.Enums.EnumConfigOp>().ConvertUsing(new EnumConverter<Contracts.Pallet.Staking.Enums.EnumConfigOp>());
                CreateMap<IType, Contracts.Pallet.Staking.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Staking.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.Staking.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.Staking.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.Staking.Enums.EnumForcing>().ConvertUsing(new EnumConverter<Contracts.Pallet.Staking.Enums.EnumForcing>());
                CreateMap<IType, Contracts.Pallet.Staking.Enums.EnumReleases>().ConvertUsing(new EnumConverter<Contracts.Pallet.Staking.Enums.EnumReleases>());
                CreateMap<IType, Contracts.Pallet.Staking.Enums.EnumRewardDestination>().ConvertUsing(new EnumConverter<Contracts.Pallet.Staking.Enums.EnumRewardDestination>());
                CreateMap<IType, Contracts.Pallet.Support.Enum.EnumBounded>().ConvertUsing(new EnumConverter<Contracts.Pallet.Support.Enum.EnumBounded>());
                CreateMap<IType, Contracts.Pallet.Support.Enum.EnumLookupError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Support.Enum.EnumLookupError>());
                CreateMap<IType, Contracts.Pallet.Support.Enum.EnumProcessMessageError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Support.Enum.EnumProcessMessageError>());
                CreateMap<IType, Contracts.Pallet.System.Enums.EnumDigestItem>().ConvertUsing(new EnumConverter<Contracts.Pallet.System.Enums.EnumDigestItem>());
                CreateMap<IType, Contracts.Pallet.System.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.System.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.System.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.System.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.System.Enums.EnumPhase>().ConvertUsing(new EnumConverter<Contracts.Pallet.System.Enums.EnumPhase>());
                CreateMap<IType, Contracts.Pallet.Timestamp.Enums.EnumCall>().ConvertUsing(new EnumConverter<Contracts.Pallet.Timestamp.Enums.EnumCall>());
                CreateMap<IType, Contracts.Pallet.Tips.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Tips.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.Tips.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.Tips.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.TransactionPayment.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.TransactionPayment.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.TransactionPayment.Enums.EnumReleases>().ConvertUsing(new EnumConverter<Contracts.Pallet.TransactionPayment.Enums.EnumReleases>());
                CreateMap<IType, Contracts.Pallet.Treasury.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Treasury.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.Treasury.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.Treasury.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.Utility.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Utility.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.Utility.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.Utility.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.Vesting.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Vesting.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.Vesting.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.Vesting.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.Vesting.Enums.EnumReleases>().ConvertUsing(new EnumConverter<Contracts.Pallet.Vesting.Enums.EnumReleases>());
                CreateMap<IType, Contracts.Pallet.WhiteList.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.WhiteList.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.WhiteList.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.WhiteList.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.Xcm.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.Xcm.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.Enums.EnumEvent>());
                CreateMap<IType, Contracts.Pallet.Xcm.Enums.EnumOrigin>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.Enums.EnumOrigin>());
                CreateMap<IType, Contracts.Pallet.Xcm.Enums.EnumQueryStatus>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.Enums.EnumQueryStatus>());
                CreateMap<IType, Contracts.Pallet.Xcm.Enums.EnumVersionedMultiAssets>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.Enums.EnumVersionedMultiAssets>());
                CreateMap<IType, Contracts.Pallet.Xcm.Enums.EnumVersionedMultiLocation>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.Enums.EnumVersionedMultiLocation>());
                CreateMap<IType, Contracts.Pallet.Xcm.Enums.EnumVersionedResponse>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.Enums.EnumVersionedResponse>());
                CreateMap<IType, Contracts.Pallet.Xcm.Enums.EnumVersionedXcm>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.Enums.EnumVersionedXcm>());
                CreateMap<IType, Contracts.Pallet.Xcm.Enums.EnumVersionMigrationStage>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.Enums.EnumVersionMigrationStage>());
                CreateMap<IType, Contracts.Pallet.Xcm.v0.Enums.EnumBodyId>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v0.Enums.EnumBodyId>());
                CreateMap<IType, Contracts.Pallet.Xcm.v0.Enums.EnumBodyPart>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v0.Enums.EnumBodyPart>());
                CreateMap<IType, Contracts.Pallet.Xcm.v0.Enums.EnumJunction>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v0.Enums.EnumJunction>());
                CreateMap<IType, Contracts.Pallet.Xcm.v0.Enums.EnumMultiAsset>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v0.Enums.EnumMultiAsset>());
                CreateMap<IType, Contracts.Pallet.Xcm.v0.Enums.EnumMultiLocation>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v0.Enums.EnumMultiLocation>());
                CreateMap<IType, Contracts.Pallet.Xcm.v0.Enums.EnumNetworkId>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v0.Enums.EnumNetworkId>());
                CreateMap<IType, Contracts.Pallet.Xcm.v0.Enums.EnumOrder>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v0.Enums.EnumOrder>());
                CreateMap<IType, Contracts.Pallet.Xcm.v0.Enums.EnumOriginKind>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v0.Enums.EnumOriginKind>());
                CreateMap<IType, Contracts.Pallet.Xcm.v0.Enums.EnumResponse>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v0.Enums.EnumResponse>());
                CreateMap<IType, Contracts.Pallet.Xcm.v0.Enums.EnumXcm>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v0.Enums.EnumXcm>());
                CreateMap<IType, Contracts.Pallet.Xcm.v1.Enums.EnumAssetId>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v1.Enums.EnumAssetId>());
                CreateMap<IType, Contracts.Pallet.Xcm.v1.Enums.EnumAssetInstance>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v1.Enums.EnumAssetInstance>());
                CreateMap<IType, Contracts.Pallet.Xcm.v1.Enums.EnumBodyPart>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v1.Enums.EnumBodyPart>());
                CreateMap<IType, Contracts.Pallet.Xcm.v1.Enums.EnumFungibility>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v1.Enums.EnumFungibility>());
                CreateMap<IType, Contracts.Pallet.Xcm.v1.Enums.EnumJunction>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v1.Enums.EnumJunction>());
                CreateMap<IType, Contracts.Pallet.Xcm.v1.Enums.EnumJunctions>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v1.Enums.EnumJunctions>());
                CreateMap<IType, Contracts.Pallet.Xcm.v1.Enums.EnumMultiAssetFilter>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v1.Enums.EnumMultiAssetFilter>());
                CreateMap<IType, Contracts.Pallet.Xcm.v1.Enums.EnumOrder>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v1.Enums.EnumOrder>());
                CreateMap<IType, Contracts.Pallet.Xcm.v1.Enums.EnumResponse>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v1.Enums.EnumResponse>());
                CreateMap<IType, Contracts.Pallet.Xcm.v1.Enums.EnumWildFungibility>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v1.Enums.EnumWildFungibility>());
                CreateMap<IType, Contracts.Pallet.Xcm.v1.Enums.EnumWildMultiAsset>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v1.Enums.EnumWildMultiAsset>());
                CreateMap<IType, Contracts.Pallet.Xcm.v1.Enums.EnumXcm>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v1.Enums.EnumXcm>());
                CreateMap<IType, Contracts.Pallet.Xcm.v2.Enums.EnumError>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v2.Enums.EnumError>());
                CreateMap<IType, Contracts.Pallet.Xcm.v2.Enums.EnumInstruction>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v2.Enums.EnumInstruction>());
                CreateMap<IType, Contracts.Pallet.Xcm.v2.Enums.EnumOutcome>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v2.Enums.EnumOutcome>());
                CreateMap<IType, Contracts.Pallet.Xcm.v2.Enums.EnumResponse>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v2.Enums.EnumResponse>());
                CreateMap<IType, Contracts.Pallet.Xcm.v2.Enums.EnumWeightLimit>().ConvertUsing(new EnumConverter<Contracts.Pallet.Xcm.v2.Enums.EnumWeightLimit>());

                CreateMap<IType, EnumFreezeReason>().ConvertUsing(new EnumConverter<EnumFreezeReason>());
                CreateMap<IType, EnumRuntimeFreezeReason>().ConvertUsing(new EnumConverter<EnumRuntimeFreezeReason>());
                CreateMap<IType, EnumRuntimeHoldReason>().ConvertUsing(new EnumConverter<EnumRuntimeHoldReason>());
                
                CreateMap<IType, Contracts.Pallet.CumulusPalletParachainSystem.Enums.EnumEvent>().ConvertUsing(new EnumConverter<Contracts.Pallet.CumulusPalletParachainSystem.Enums.EnumEvent>());
            }
        }
        #region Map
        /// <summary>
        /// Map TSource to TDestination by given a specific version. Depend on pallet version (System.SpecVersion)
        /// </summary>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <typeparam name="TDestination">Destination type</typeparam>
        /// <param name="version">Substrate blockchain SpecVersion</param>
        /// <param name="source">TSource instance data</param>
        /// <returns>Mapped object</returns>
        public TDestination MapWithVersion<TSource, TDestination>(uint version, TSource source)
            where TSource : IType
            where TDestination : IType
        {
            var mapped = _mapper.Map<TSource, TDestination>(source, opts => opts.Items["version"] = version);
            return mapped;
        }

        /// <summary>
        /// Map a dynamic runtime source type to a dynamic runtime destination type
        /// </summary>
        /// <param name="source"></param>
        /// <param name="sourceType"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public object Map(object source, Type sourceType, Type destinationType)
        {
            var mapped = _mapper.Map(source, sourceType, destinationType);
            return mapped;
        }

        private object Map(uint version, object source, Type sourceType, Type destinationType)
        {
            var mapped = _mapper.Map(source, sourceType, destinationType, opts => opts.Items["version"] = version);
            return mapped;
        }

        public IType Map<TSource>(uint version, TSource source, Type destinationType)
            where TSource : IType
        {
            return (IType)Map(version, source, typeof(TSource), destinationType);
        }

        public TDestination Map<TSource, TDestination>(TSource source) where TSource : IType
        {
            var mapped = _mapper.Map<TSource, TDestination>(source);
            return mapped;
        }

        public TDestination Map<TDestination>(object source)
            where TDestination : IType
        {
            var mapped = _mapper.Map<TDestination>(source);
            return mapped;
        }

        public IType MapEnum(IType source, Type destinationType)
        {
            return MapEnumInternal(source, destinationType);
        }

        public TDestination MapEnum<TDestination, TEnum>(IType source)
            where TDestination : BaseEnum<TEnum>, new()
            where TEnum : Enum
        {
            return (TDestination)MapEnumInternal(source, typeof(TDestination));
        }

        public TDestination MapEnum<TDestination>(IType source)
            where TDestination : BaseEnumType, new()
        {
            return (TDestination)MapEnumInternal(source, typeof(TDestination));
        }

        protected static object GetBaseEnumRustInstance(object obj)
        {
            // Récupère le type de l'objet
            var type = obj.GetType();

            // Vérifie si le type est une sous-classe d'un type générique BaseEnumRust<>
            while (type != null)
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(BaseEnumRust<>))
                {
                    return obj; // Retourne l'instance castée en object
                }
                type = type.BaseType;
            }

            return null;
        }

        protected static IType MapEnumInternal(IType source, Type destinationType, ResolutionContext? context = null)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));

            object? destinationInstance = Activator.CreateInstance(destinationType);
            if (destinationInstance is null)
                throw new InvalidOperationException($"Cannot create instance of {destinationType}");

            var destination = (IType)destinationInstance;

            var destinationEnumType = destination!.GetEnumValue()!.GetType();
            if (!destinationEnumType.IsEnum)
                throw new InvalidCastException($"{nameof(destinationEnumType)} is not an enum");

            var destinationEnumNames = destinationEnumType.GetEnumNames();
            if (destinationEnumNames.Length == 0)
                throw new InvalidOperationException($"{nameof(destinationEnumType)} is a enum with no data");

            object? mappedEnum;
            if (!Enum.TryParse(destinationEnumType, source.GetEnumValue()!.ToString(), true, out mappedEnum))
                throw new MissingMappingException($"Impossible to cast {source.GetType()} to {destinationType} because {source.GetEnumValue()!.ToString()} seems to miss");

            var baseEnumExtBytes = new List<byte>()
                {
                    Convert.ToByte(mappedEnum)
                };

            var baseEnumRust = GetBaseEnumRustInstance(source);
            if (baseEnumRust is not null && context is not null)
            {
                IType dynamicBaseEnumRust = baseEnumRust as IType;
                //var enumValues = Enum.GetValues(source.GetEnumValue().GetType());
                //int index = destinationEnumNames.ToList().IndexOf(mappedEnum!.ToString());
                //var associatedDataType = destinationType.BaseType.GenericTypeArguments[index + 1];

                var associatedDataType = destinationType.BaseType.GenericTypeArguments[(int)mappedEnum + 1];
                var associatedData = (IType)context.Mapper.Map(dynamicBaseEnumRust.GetValue2(), dynamicBaseEnumRust.GetValue2()!.GetType(), associatedDataType);
                baseEnumExtBytes.AddRange(associatedData.Encode());
            }
            else
            {
                // We have a BaseEnum here, so just add BaseVoid avec Value2 property
                baseEnumExtBytes.AddRange(source.GetValue2().Encode());
                //baseEnumExtBytes.AddRange(new BaseVoid().Encode());
            }

            destination.Create(baseEnumExtBytes.ToArray());

            // Check if Value2 type is valid
            int sourceTypeSize = source.GetValue2().TypeSize;
            int destinationTypeSize = destination.GetValue2().TypeSize;
            if (sourceTypeSize != destinationTypeSize)
            {
                throw new InvalidTypeSizeException($"Error while trying to map {source.GetType()} to {destinationType}," +
                    $"associated data (Value2) does not have same TypeSize (source = {sourceTypeSize} / " +
                    $"destination = {destinationTypeSize})");
            }

            return destination;

        }
        #endregion

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

        public class BaseTupleConverter<I1, I2, I3, I4, O1, O2, O3, O4> : ITypeConverter<BaseTuple<I1, I2, I3, I4>, BaseTuple<O1, O2, O3, O4>>
        where I1 : IType, new()
        where I2 : IType, new()
        where I3 : IType, new()
        where I4 : IType, new()
        where O1 : IType, new()
        where O2 : IType, new()
        where O3 : IType, new()
        where O4 : IType, new()
        {
            public BaseTuple<O1, O2, O3, O4> Convert(BaseTuple<I1, I2, I3, I4> source, BaseTuple<O1, O2, O3, O4> destination, ResolutionContext context)
            {
                destination = new BaseTuple<O1, O2, O3, O4>();

                if (source == null) return destination;

                var first = context.Mapper.Map<I1, O1>((I1)source.Value[0]);
                var second = context.Mapper.Map<I2, O2>((I2)source.Value[1]);
                var third = context.Mapper.Map<I3, O3>((I3)source.Value[2]);
                var fourth = context.Mapper.Map<I4, O4>((I4)source.Value[3]);
                destination.Create(first, second, third, fourth);

                return destination;
            }
        }

        public class BaseTupleConverter<I1, I2, I3, I4, I5, O1, O2, O3, O4, O5> : ITypeConverter<BaseTuple<I1, I2, I3, I4, I5>, BaseTuple<O1, O2, O3, O4, O5>>
        where I1 : IType, new()
        where I2 : IType, new()
        where I3 : IType, new()
        where I4 : IType, new()
        where I5 : IType, new()
        where O1 : IType, new()
        where O2 : IType, new()
        where O3 : IType, new()
        where O4 : IType, new()
        where O5 : IType, new()
        {
            public BaseTuple<O1, O2, O3, O4, O5> Convert(BaseTuple<I1, I2, I3, I4, I5> source, BaseTuple<O1, O2, O3, O4, O5> destination, ResolutionContext context)
            {
                destination = new BaseTuple<O1, O2, O3, O4, O5>();

                if (source == null) return destination;

                var first = context.Mapper.Map<I1, O1>((I1)source.Value[0]);
                var second = context.Mapper.Map<I2, O2>((I2)source.Value[1]);
                var third = context.Mapper.Map<I3, O3>((I3)source.Value[2]);
                var fourth = context.Mapper.Map<I4, O4>((I4)source.Value[3]);
                var fifth = context.Mapper.Map<I5, O5>((I5)source.Value[4]);
                destination.Create(first, second, third, fourth, fifth);

                return destination;
            }
        }

        public class EventRecordsConverter<T1> : ITypeConverter<BaseVec<T1>, BaseVec<EventRecord>>
        where T1 : IType, new()
        {
            public BaseVec<EventRecord> Convert(BaseVec<T1> source, BaseVec<EventRecord> destination, ResolutionContext context)
            {
                destination = new BaseVec<EventRecord>();

                if (source.Value == null) return destination;
                IList<EventRecord> list = new List<EventRecord>();

                foreach (var val in source.Value)
                {
                    try
                    {
                        list.Add(context.Mapper.Map<T1, EventRecord>(val));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }

                destination.Create(list.ToArray());

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

#if DEBUG
                var index = 0;
#endif
                foreach (var val in source.Value)
                {
                    list.Add(context.Mapper.Map<T1, T2>(val));

#if DEBUG
                                       index++;
#endif
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
                if (source == null || !source.OptionFlag) return destination;

                destination.Create(context.Mapper.Map<T1, T2>(source.Value));
                return destination;
            }
        }

        public class EnumConverter<T> : ITypeConverter<IType, T>
            where T : IType, new()
        {
            public T Convert(IType source, T destination, ResolutionContext context)
            {
                return (T)MapEnumInternal(source, typeof(T), context);
            }
        }
    }
}
