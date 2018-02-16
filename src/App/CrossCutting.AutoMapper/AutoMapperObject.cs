using System;
using AutoMapper;
using AutoMapper.Configuration;

namespace CrossCutting.AutoMapper
{
    public class AutoMapperObject : Core.Mapper.IObjectMapper
    {
        IMapper _mapper;

        public AutoMapperObject(MapperConfigurationExpression configurationExpression)
        {
            var configuration = new MapperConfiguration(configurationExpression);
            _mapper = configuration.CreateMapper();
        }

        public TDestination Map<TDestination>(object @object)
        {
            return _mapper.Map<TDestination>(@object);
        }

        public TDestination Map<TSource, TDestination>(TSource @object)
        {
            return _mapper.Map<TSource, TDestination>(@object);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map(source, destination);
        }

      
    }
}
