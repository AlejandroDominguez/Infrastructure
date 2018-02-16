namespace CrossCutting.Core.Mapper
{
    public interface IObjectMapper
    {
        /// <summary>
        /// Map object
        /// </summary>
        TDestination Map<TSource, TDestination>(TSource @object);


        TDestination Map<TDestination>(object @object);

        /// <summary>
        /// Map object
        /// </summary>
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
