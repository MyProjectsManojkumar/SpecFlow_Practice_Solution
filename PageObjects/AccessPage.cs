using NUnit.Framework;
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
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            Thread.Sleep(1000);
            string value = "You logged into a secure area!";
            Assert.True(driver.FindElement(By.XPath("//div[@class='flash success']")).Text.Contains(value));
        }
    }
}
