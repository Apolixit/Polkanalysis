using AutoMapper;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base.Abstraction;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts
{
    public interface IBlockchainMapping
    {
        public IConfigurationProvider ConfigurationProvider { get; }

        /// <summary>
        /// Classic mapping between a source and a destination class
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source">Source value</param>
        /// <returns>Mapped value</returns>
        public TDestination Map<TSource, TDestination>(TSource source) where TSource : IType;
        public TDestination Map<TDestination>(object source);
        public IType Map<TSource>(uint version, TSource source, Type destinationType)
            where TSource : IType;
        public object Map(object source, Type sourceType, Type destinationType);

        /// <summary>
        /// Mapping between source and destination which also depend on pallet version (System.SpecVersion)
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="version"></param>
        /// <param name="source"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public TDestination MapWithVersion<TSource, TDestination>(uint version, TSource source)
            where TSource : IType
            where TDestination : IType;

        /// <summary>
        /// Map a versionned enum to a Domain enum.
        /// Works with BaseEnum and BaseEnumExt
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <typeparam name="TDestinationEnum"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public TDestination MapEnum<TDestination, TDestinationEnum>(IBaseEnum source)
            where TDestination : IBaseEnum, new()
            where TDestinationEnum : struct, Enum;

        public IType? MapEnum(IBaseEnum source, Type destinationType);
    }
}
