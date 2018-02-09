using CrossCutting.Core.Guards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoryQ;
using System;

namespace CrossCutting.Core.UnitTest.GuardsSpecs
{
    [TestClass]
    public class GuardTest
    {
        string _value;
        GuardValidationException _exception;

        [TestMethod]
        public void GuardString()
        {
            new Story("string guards")
                  .InOrderTo("test")
                  .AsA("user")
                  .IWant("bla bla")

                  .WithScenario("empty string")
                      .Given(EmptyString)
                      .When(CheckIsNotNullOrEmpty)
                      .Then(ThereIsAnException)

                  .WithScenario("null string")
                      .Given(EmptyString)
                      .When(CheckIsNotNullOrEmpty)
                      .Then(ThereIsAnException)

                  .WithScenario("not null string")
                      .Given(NotEmptyString)
                      .When(CheckIsNotNullOrEmpty)
                      .Then(IsValid)

                  .ExecuteWithReport();
        }

        public void EmptyString()
        {
            _value = String.Empty;
            _exception = null;
        }

        public void NullString()
        {
            _value = null;
            _exception = null;
        }
        public void NotEmptyString()
        {
            _value = new string('a', 10);
            _exception = null;
        }

        void IsValid()
        {
            Assert.IsNull(_exception);
        }

        void ThereIsAnException()
        {
            Assert.IsNotNull(_exception);
        }

        public void CheckIsNotNullOrEmpty()
        {
            try
            {
                Guard.IsNotNullOrEmpty(_value);

            }
            catch (GuardValidationException e)
            {
                _exception = e;
            }
        }
    }
}
