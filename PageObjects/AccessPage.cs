using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow_Practice_Solution.PageObjects
{
    public class AccessPage
    {
        public IWebDriver driver;
        public AccessPage(IWebDriver driver1)
        {
            this.driver = driver1;
        }

        public void EnterLoginDetails(string user, string pwd)
        {
            driver.FindElement(By.Name("username")).SendKeys(user);
            driver.FindElement(By.Name("password")).SendKeys(pwd);
        }
    }
}
