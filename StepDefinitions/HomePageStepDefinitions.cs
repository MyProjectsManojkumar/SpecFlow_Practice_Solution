using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProjectDemo.PageObjects;
using System.Security.Cryptography.X509Certificates;
using TechTalk.SpecFlow;

namespace SpecFlowProjectDemo.StepDefinitions
{
    [Binding]
    public sealed class HomePageStepDefinitions
    {
        public IWebDriver driver;
        public HomePage homePage;
        public HomePageStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            homePage =new HomePage(driver);
        }

        [Given("I open the browser")]
        public void GivenTheFirstNumberIs()
        {
            driver.Url = "https://the-internet.herokuapp.com/";
        }

        [When(@"click on the link - '([^']*)'")]
        public void WhenClickOnTheLink_(string value)
        {
            homePage.ClickOnLinks(value);
            
        }
        [Then(@"get title of page")]
        public void ThenGetTitleOfPage()
        {
            homePage.getTitle();
        }
        [When(@"Select the Checkbox")]
        public void WhenSelectTheCheckbox()
        {
            homePage.ClickonCheckBoxes();
        }

    }
}
