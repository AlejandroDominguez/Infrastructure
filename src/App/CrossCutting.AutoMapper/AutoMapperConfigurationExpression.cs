using CrossCutting.Core.Mapper;
using System;
using AutoMapper;
using System.Linq.Expressions;

namespace CrossCutting.AutoMapper
{
    public class AutoMapperConfigurationExpression<TSource, TDestination> : IObjectMapperConfigurationExpression<TSource, TDestination>
    {

        IMappingExpression<TSource, TDestination> _expression;

        public AutoMapperConfigurationExpression(IMappingExpression<TSource, TDestination> config)
        {
            _expression = config;
        }

        public IObjectMapperConfigurationExpression<TSource, TDestination> Ignore(Expression<Func<TDestination, object>> destination)
        {
            return new AutoMapperConfigurationExpression<TSource, TDestination>(_expression.ForMember(destination, config => config.Ignore()));
        }

        public IObjectMapperConfigurationExpression<TSource, TDestination> Map(Expression<Func<TDestination, object>> destination, Expression<Func<TSource, object>> source)
        {
            return new AutoMapperConfigurationExpression<TSource, TDestination>(_expression.ForMember(destination, config => config.MapFrom(source)));
        }
        public IObjectMapperConfigurationExpression<TSource, TDestination> Include<TDerivedSourceType, TDerivedDestinationType>()
        {
            return this.Include(typeof(TDerivedSourceType), typeof(TDerivedDestinationType));
        }


        private IObjectMapperConfigurationExpression<TSource, TDestination> Include(Type derivedSourceType, Type derivedDestinationType)
        {
            return new AutoMapperConfigurationExpression<TSource, TDestination>(_expression.Include(derivedDestinationType, derivedDestinationType));
        }

    }
}
