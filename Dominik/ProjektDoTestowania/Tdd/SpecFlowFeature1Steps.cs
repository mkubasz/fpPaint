using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjektDoTestowania;
using TechTalk.SpecFlow;

namespace Tdd
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
		Calculator calc = new Calculator();
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
	        calc.firstNumber = p0;
        }
		[Given(@"I have entered (.*) into the calculator")]
		public void GivenIHaveEnteredIntoTheCalculatorSecond(int p0)
		{
			calc.secondNumber = p0;
		}
		[When(@"I called add")]
        public void WhenICalledAdd()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I called substraction")]
        public void WhenICalledSubstraction()
        {calc.Add();
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int p0)
        {
            Assert.AreEqual(p0, calc.result);
        }
    }
}
