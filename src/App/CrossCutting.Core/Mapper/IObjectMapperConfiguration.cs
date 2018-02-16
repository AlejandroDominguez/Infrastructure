namespace CrossCutting.Core.Mapper
{
    public interface IObjectMapperConfiguration
    {
        /// <summary>
        /// Configure mapping
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <returns></returns>
        IObjectMapperConfigurationExpression<TSource, TDestination> CreateMap<TSource, TDestination>();

        /// <summary>
        /// Checks to make sure that every single Destination type member has a corresponding type member on the source type.
        /// </summary>
        void AssertConfigurationIsValid();

        /// <summary>
        /// Get mapper 
        /// </summary>
        /// <returns></returns>
        IObjectMapper GetObjectMapper();

    }
}
