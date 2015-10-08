using System;
using Coypu;
using Coypu.Drivers;
using Coypu.Drivers.Selenium;
using TechTalk.SpecFlow;

namespace ut1
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
		SessionConfiguration sessionConfiguration = new SessionConfiguration
		{
			AppHost = "allegro.pl",
			Port = 80,
			SSL = false,

		};
		BrowserSession browser = new BrowserSession();

		[Given(@"I have entered ""(.*)"" into the serch label")]
        public void GivenIHaveEnteredIntoTheSerchLabel(string p0)
        {
			sessionConfiguration.Driver = typeof(SeleniumWebDriver);
			sessionConfiguration.Browser = Browser.Firefox;
			browser.FillIn("main-search-text").With(p0);
			ScenarioContext.Current.Pending();
        }
        
        [When(@"I click serch button")]
        public void WhenIClickSerchButton()
        {
			browser.ClickButton("Szukaj");
			ScenarioContext.Current.Pending();
        }
        
        [Then(@"display result's list into screen")]
        public void ThenDisplayResultSListIntoScreen()
        {
            ScenarioContext.Current.Pending();
			browser.Dispose();
		}
    }
}
