using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Mapper
{
    /// <summary>
    /// Allow to map multiple source
    /// https://gist.github.com/ilyapalkin/8822638
    /// </summary>
    public interface IMapper
    {
        /// <summary>
		/// Maps the specified source type instance to destination type instance.
		/// </summary>
		/// <typeparam name="TSource">Source type.</typeparam>
		/// <typeparam name="TDestination">Destination type.</typeparam>
		/// <param name="source">The source.</param>
		/// <returns>
		/// Instance of destination type.
		/// </returns>
		TDestination Map<TSource, TDestination>(TSource source);

        /// <summary>
        /// Maps the specified source type instance to destination type instance.
        /// </summary>
        /// <typeparam name="TDestination">The type of the destination instance.</typeparam>
        /// <param name="source">The source instance.</param>
        /// <returns>
        /// Instance of destination type.
        /// </returns>
        TDestination MapTo<TDestination>(object source);

        /// <summary>
        /// Maps the specified source type instance to destination type instance.
        /// </summary>
        /// <param name="source">The source instance.</param>
        /// <returns>Fluent interface for mapping.</returns>
        IMapBuilder Map(object source);
    }

    /// <summary>
    /// Fluent interface for mapping.
    /// </summary>
    public interface IMapBuilder
    {
        /// <summary>
        /// Maps the specified source type instance to destination type instance.
        /// </summary>
        /// <param name="source">The source instance.</param>
        /// <returns>Fluent interface for mapping.</returns>
        IMapBuilder Map(object source);

        /// <summary>
        /// Maps the specified earlier source type instances to destination type instance.
        /// </summary>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="destination">The destination object.</param>
        /// <returns>
        /// Instance of destination type.
        /// </returns>
        TDestination To<TDestination>(TDestination destination);

        /// <summary>
        /// Maps the specified earlier source type instances to destination type instance.
        /// </summary>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <returns>
        /// Instance of destination type.
        /// </returns>
        TDestination To<TDestination>();
    }
}
