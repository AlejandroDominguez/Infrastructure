using CrossCutting.Core.Specification;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoryQ;
using System.Collections.Generic;
using System.Linq;

namespace CrossCutting.Core.UnitTest.SpecificationSpecs
{
    [TestClass]
    public class SpecificationTest
    {
        IEnumerable<string> _todoList;
        ISpecification<string> _specification;

        [TestMethod]
        public void Negation()
        {
            new Story("negation specification")
                .InOrderTo("test negation specification")
                .AsA("user")
                .IWant("negate and expression")
                .WithScenario("NOT")

                    .Given(List)
                    .And(FalseSpecification)
                    .When(NegateTheSpecification)
                    .Then(ShouldSatisfiedTheExpression)

                .ExecuteWithReport();

        }

        [TestMethod]
        public void And()
        {
            new Story("and specification")
                .InOrderTo("test and specification")
                .AsA("user")
                .IWant("validate")
                .WithScenario("AND (true,true)=>true")
                    .Given(List)
                    .And(TrueSpecification)
                    .When(AndAnotherTrueSpecification)
                    .Then(ShouldSatisfiedTheExpression)
                .WithScenario("AND (true,false)=>false")
                    .Given(List)
                    .And(TrueSpecification)
                    .When(AndAnotherFalseSpecification)
                    .Then(ShouldNotSatisfiedTheExpression)

                .ExecuteWithReport();

        }

        [TestMethod]
        public void Or()
        {
            new Story("and specification")
                .InOrderTo("test and specification")
                .AsA("user")
                .IWant("validate")
                .WithScenario("OR  (false, true)=>true")
                    .Given(List)
                    .And(FalseSpecification)
                    .When(OrAnotherTrueSpecification)
                    .Then(ShouldSatisfiedTheExpression)

                .WithScenario("OR  (true, true)=>true")
                    .Given(List)
                    .And(TrueSpecification)
                    .When(OrAnotherTrueSpecification)
                    .Then(ShouldSatisfiedTheExpression)

                .WithScenario("OR  (false, false)=>false")
                    .Given(List)
                    .And(FalseSpecification)
                    .When(OrAnotherFalseSpecification)
                    .Then(ShouldNotSatisfiedTheExpression)
                .ExecuteWithReport();

        }

        private void ShouldSatisfiedTheExpression()
        {
            Assert.AreEqual(true, _todoList.AsQueryable().Any(_specification.IsSatisfied()));
        }

        private void ShouldNotSatisfiedTheExpression()
        {
            Assert.AreEqual(false, _todoList.AsQueryable().Any(_specification.IsSatisfied()));
        }



        private void NegateTheSpecification()
        {
            _specification = new Negation<string>(_specification);
        }

        private void AndAnotherTrueSpecification()
        {
            _specification = new And<string>(_specification, new DirectSpecification<string>(x => x.StartsWith("c", System.StringComparison.Ordinal)));
        }

        private void AndAnotherFalseSpecification()
        {
            _specification = new And<string>(_specification, new DirectSpecification<string>(x => x.StartsWith("z", System.StringComparison.Ordinal)));
        }

        private void OrAnotherTrueSpecification()
        {
            _specification = new Or<string>(_specification, new DirectSpecification<string>(x => x.StartsWith("c", System.StringComparison.Ordinal)));
        }

        private void OrAnotherFalseSpecification()
        {
            _specification = new Or<string>(_specification, new DirectSpecification<string>(x => x.StartsWith("z", System.StringComparison.Ordinal)));
        }

        void List()
        {
            _todoList = new List<string>()
            {
              "clean",
              "buy",
            };
        }

        void FalseSpecification()
        {
            _specification = new DirectSpecification<string>(x => x == "paint");
        }

        void TrueSpecification()
        {
            _specification = new DirectSpecification<string>(x => x == "clean");
        }
    }
}
