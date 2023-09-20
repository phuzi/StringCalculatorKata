using System;
using TechTalk.SpecFlow;

namespace StringCalculator.Tests.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
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
            _result = StringCalculator.Add(_expression);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            Assert.AreEqual(result, _result);
        }
    }
}
