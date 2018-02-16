using AutoMapper;
using AutoMapper.Configuration;
using CrossCutting.Core.Mapper;
namespace CrossCutting.AutoMapper
{
    public class AutoMapperConfiguration : IObjectMapperConfiguration
    {
        MapperConfigurationExpression _configuration;

        public AutoMapperConfiguration()
        {
            _configuration = new MapperConfigurationExpression();
        }

        public void AssertConfigurationIsValid()
        {
            Mapper.AssertConfigurationIsValid();
        }

        public IObjectMapperConfigurationExpression<TSourceTFrom, TDestination> CreateMap<TSourceTFrom, TDestination>()
        {
            var mapConfig = _configuration.CreateMap<TSourceTFrom, TDestination>();
            return new AutoMapperConfigurationExpression<TSourceTFrom, TDestination>(mapConfig);
        }

        public Core.Mapper.IObjectMapper GetObjectMapper()
        {
            return new AutoMapperObject(_configuration);
        }

        public MapperConfigurationExpression GetConfiguration
        {
            get { return _configuration; }
        }

    }

}
