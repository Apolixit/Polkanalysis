using AutoMapper;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts
{
    public interface IBlockchainMapping
    {
        /// <summary>
        /// Expose Automapper ConfigurationProvider
        /// </summary>
        public IConfigurationProvider ConfigurationProvider { get; }

        /// <summary>
        /// Classic mapping between a source and a destination class
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source">Source value</param>
        /// <returns>Mapped value</returns>
        public TDestination Map<TSource, TDestination>(TSource source) where TSource : IType;

        /// <summary>
        /// Map an object from an unknow source to a specific TDestination class
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public TDestination Map<TDestination>(object source)
            where TDestination : IType;

        /// <summary>
        /// Map a known source to a dynamic runtime destination type
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="version"></param>
        /// <param name="source"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public IType Map<TSource>(uint version, TSource source, Type destinationType)
            where TSource : IType;

        /// <summary>
        /// Map a dynamic runtime source type to a dynamic runtime destination type
        /// </summary>
        /// <param name="source"></param>
        /// <param name="sourceType"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public object Map(object source, Type sourceType, Type destinationType);

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
            where TDestination : IType;

        /// <summary>
        /// Map a versionned enum to a Domain enum.
        /// Works with <see cref="Substrate.NetApi.Model.Types.Base.BaseEnum{T}"/> and <see cref="Substrate.NetApi.Model.Types.Base.BaseEnumExt{T0, T1}>"/> and derifved
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <typeparam name="TDestinationEnum"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public TDestination MapEnum<TDestination, TEnum>(IType source)
            where TDestination : BaseEnum<TEnum>, new()
            where TEnum : Enum;

        public TDestination MapEnum<TDestination>(IType source)
            where TDestination : BaseEnumType, new();

        /// <summary>
        /// Map a versionned enum to a dynamic runtime Domain enum
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public IType MapEnum(IType source, Type destinationType);
    }
}
