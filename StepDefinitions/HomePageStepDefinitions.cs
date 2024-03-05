using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlow_Practice_Solution.PageObjects;
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
        public AccessPage accessPage;
        string value1;
        string value2;
        public HomePageStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            homePage =new HomePage(driver);
            accessPage =new AccessPage(driver);
        }

        [Given("I open the browser")]
        public void GivenTheFirstNumberIs()
        {
            
            driver.Url = TestContext.Parameters["URL"].ToString();
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
       
        [Then(@"get the text of the page")]
        public void ThenGetTheTextOfThePage()
        {
           string value= driver.FindElement(By.XPath("//h4[@class]")).Text;
            Console.WriteLine(value);

            string[] sep = { "This is where you can log into the secure area. Enter ", " for the username and ", " for the password. If the information is wrong you should see error messages." };
            string[] DataSplitted= value.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(DataSplitted[0]);
            Console.WriteLine(DataSplitted[1]);
            value1 = DataSplitted[0];
            value2 = DataSplitted[1];
            
        }
        [When(@"Enter the details of login page")]
        public void WhenEnterTheDetailsOfLoginPage()
        {
            accessPage.EnterLoginDetails(value1,value2);
        }

    }
}
