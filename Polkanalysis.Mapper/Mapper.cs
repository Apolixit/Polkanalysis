namespace Substats.Mapper
{
    public class Mapper : IMapper
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
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return MapTo<TDestination>(source);
        }

        /// <summary>
        /// Maps the specified source type instance to destination type instance.
        /// </summary>
        /// <typeparam name="TDestination">The type of the destination instance.</typeparam>
        /// <param name="source">The source instance.</param>
        /// <returns>
        /// Instance of destination type.
        /// </returns>
        public TDestination MapTo<TDestination>(object source)
        {
            return Map(source)
                .To<TDestination>();
        }

        /// <summary>
        /// Maps the specified source type instance to destination type instance.
        /// </summary>
        /// <param name="source">The source instance.</param>
        /// <returns>Fluent interface for mapping.</returns>
        public IMapBuilder Map(object source)
        {
            return new MapBuilder(source);
        }

        #region Internal types

        /// <summary>
        /// Fluent interface for mapping.
        /// </summary>
        internal class MapBuilder : IMapBuilder
        {
            private readonly List<object> sources = new List<object>();

            /// <summary>
            /// Initialises a new instance of the <see cref="MapBuilder"/> class.
            /// </summary>
            /// <param name="source">The source instance.</param>
            public MapBuilder(object source)
            {
                sources.Add(source);
            }

            /// <summary>
            /// Maps the specified source type instance to destination type instance.
            /// </summary>
            /// <param name="source">The source instance.</param>
            /// <returns>Fluent interface for mapping.</returns>
            public IMapBuilder Map(object source)
            {
                sources.Add(source);
                return this;
            }

            /// <summary>
            /// Maps the specified earlier source type instances to destination type instance.
            /// </summary>
            /// <typeparam name="TDestination">The type of the destination.</typeparam>
            /// <param name="destination">The destination object.</param>
            /// <returns>
            /// Instance of destination type.
            /// </returns>
            public TDestination To<TDestination>(TDestination destination)
            {
                sources.ForEach(source => Map(source, destination));
                return destination;
            }

            /// <summary>
            /// Maps the specified earlier source type instances to destination type instance.
            /// </summary>
            /// <typeparam name="TDestination">The type of the destination.</typeparam>
            /// <returns>
            /// Instance of destination type.
            /// </returns>
            public TDestination To<TDestination>()
            {
                return sources.Aggregate(default(TDestination), (destination, source) => Map(source, destination));
            }

            /// <summary>
            /// Maps specified earlier source type instances to destination type instance.
            /// </summary>
            /// <param name="destinationType">The type of the destination.</param>
            /// <returns>
            /// Instance of destination type.
            /// </returns>
            public object ToType(Type destinationType)
            {
                return sources.Aggregate<object, object>(null, (destination, source) => Map(source, destination, destinationType));
            }

            private TDestination Map<TDestination>(object source, TDestination destination)
            {
                return destination != null
                    ? (TDestination)AutoMapper.Mapper.Map(source, destination, source.GetType(), typeof(TDestination))
                    : AutoMapper.Mapper.Map<TDestination>(source);
            }

            private object Map(object source, object destination, Type destinationType)
            {
                return destination != null
                    ? AutoMapper.Mapper.Map(source, destination, source.GetType(), destinationType)
                    : AutoMapper.Mapper.Map(source, source.GetType(), destinationType);
            }
        }

        #endregion
    }
}