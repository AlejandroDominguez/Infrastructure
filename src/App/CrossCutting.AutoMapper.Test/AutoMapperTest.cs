using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoryQ;

namespace CrossCutting.AutoMapper.Test
{
    [TestClass]
    public class AutoMapperTest
    {
        A _object;
        AutoMapperConfiguration _configuration;
        Core.Mapper.IObjectMapper _mapper;
        ADto _resultObject;

        [TestMethod]
        public void Mapping()
        {
            new Story("mapping")
                .InOrderTo("map")
                .AsA("user")
                .IWant("correct mapping two objects")
                .WithScenario("default mapping")

                    .Given(Object)
                    .And(NewConfiguration)
                    .And(DefaultMap)
                    .When(Map)
                    .Then(CorrectMap)

                .WithScenario("ignore a property")

                    .Given(Object)
                    .And(NewConfiguration)
                    .And(IgnoreMap)
                    .When(Map)
                    .Then(CorrectIgnoreMap)

                .WithScenario("custom property")

                    .Given(Object)
                    .And(NewConfiguration)
                    .And(CustomMap)
                    .When(Map)
                    .Then(CorrectCustomMap)

                .ExecuteWithReport();
        }

        public void Object()
        {
             _object = new A
             {
                 Email = "paco@mail.com",
                 LastName = "Perez",
                 Name = "Paco",
                 Age = 100
             };
        }

        public void NewConfiguration()
        {
            _configuration = new AutoMapperConfiguration();
        }

        public void DefaultMap()
        {
            _configuration.CreateMap<A, ADto>();
        }

        public void IgnoreMap()
        {
            _configuration.CreateMap<A, ADto>()
                .Ignore(x => x.Email);
        }

        public void CustomMap()
        {
            _configuration.CreateMap<A, ADto>()
                .Map(x => x.FullName, y => y.Name + y.LastName);
        }

        public void Map()
        {
            _mapper = _configuration.GetObjectMapper();
            _resultObject = _mapper.Map<A, ADto>(_object);
        }

        public void CorrectMap()
        {
            Assert.IsNotNull(_resultObject);
            Assert.AreEqual(_resultObject.Email, _object.Email);
            Assert.AreEqual(_resultObject.Age, _object.Age);
        }

        public void CorrectIgnoreMap()
        {
            Assert.IsNull(_resultObject.Email);
        }

        public void CorrectCustomMap()
        {
            Assert.AreEqual(_object.Name + _object.LastName, _resultObject.FullName);

        }

        #region Models

        public class A
        {
            public string Email { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }

        public class A2 : A
        {
            public string Password { get; set; }
        }
        public class ADto
        {
            public string Email { get; set; }
            public string FullName { get; set; }

            public int Age { get; set; }
        }
        public class A2Dto : ADto
        {
            public string Password { get; set; }

        }

        #endregion
    }
}
