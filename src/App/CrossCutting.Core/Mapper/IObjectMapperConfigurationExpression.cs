using System;
using System.Linq.Expressions;

namespace CrossCutting.Core.Mapper
{
    public interface IObjectMapperConfigurationExpression<TSource, TDestination>
    {
        /// <summary>
        /// Configure special maps
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        IObjectMapperConfigurationExpression<TSource, TDestination> Map(Expression<Func<TDestination, object>> destination, Expression<Func<TSource, object>> source);

        /// <summary>
        /// Ignore field in destination
        /// </summary>
        /// <param name="destination"></param>
        /// <returns></returns>
        IObjectMapperConfigurationExpression<TSource, TDestination> Ignore(Expression<Func<TDestination, object>> destination);

        /// <summary>
        /// Mapping Inheritance
        /// </summary>
        /// <param name="derivedSourceType"></param>
        /// <param name="derivedDestinationType"></param>
        /// <returns></returns>
        IObjectMapperConfigurationExpression<TSource, TDestination> Include<TDerivedSourceType, TDerivedDestinationType>();
    }
}
