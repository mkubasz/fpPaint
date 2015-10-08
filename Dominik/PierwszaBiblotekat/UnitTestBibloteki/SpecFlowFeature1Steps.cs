using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierwszaBiblotekat;
using TechTalk.SpecFlow;

namespace UnitTestBibloteki
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
	    private Dodawanie dodawanie = new Dodawanie();
	    private int result;
        [Given(@"I have entered (.*) into the class")]
        public void GivenIHaveEnteredIntoTheClass(int p0)
        {
	        dodawanie._jeden = p0;
        }
		[Given(@"I have entered (.*) into the class too")]
		public void GivenIHaveEnteredIntoTheClassToo(int p0)
		{
			dodawanie._dwa = p0;
		}
		[When(@"I call method")]
        public void WhenICallMethod()
		{
		//	result = 
		}
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int p0)
        {
			dodawanie.WynikDodawania();
			Assert.AreEqual(p0,result);
        }
    }
}
