using System;
using TechTalk.SpecFlow;

namespace StringCalculator.Tests.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private Exception? _exception;
        private string _expression = string.Empty;
        private int? _result = default;

        [TestInitialize]
        public void Initialize()
        {
            _expression = string.Empty;
            _result = default;
        }

        [Given(@"the entered string is ""([^""]*)""")]
        public void GivenTheEnteredStringIs(string expression)
        {
            _expression = expression.Replace("\\n", "\n");
        }

        [When(@"the string is added")]
        public void WhenTheStringIsAdded()
        {
            try
            {
                _result = StringCalculator.Add(_expression);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            Assert.AreEqual(result, _result);
        }

        [Then(@"an exception should be thrown")]
        public void ThenAnExceptionShouldBeThrown()
        {
            Assert.IsNotNull(_exception);
        }

        [Then(@"the exception message should be ""([^""]*)""")]
        public void ThenTheExceptionMessageShouldBe(string message)
        {
            Assert.AreEqual(message, _exception?.Message);
        }
    }
}
