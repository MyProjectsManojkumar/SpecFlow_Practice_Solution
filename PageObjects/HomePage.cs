using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectDemo.PageObjects
{
    public class HomePage
    {
        public IWebDriver driver;
        public HomePage(IWebDriver driver1)
        { 
           this.driver = driver1;
        }

        public string Link = "//a[text()='{0}']";
        public void ClickOnLinks(string value)
        {
            driver.FindElement(By.XPath(string.Format(Link,value))).Click();
            Thread.Sleep(3000);
        }

        public void getTitle()
        {
            Console.WriteLine(driver.Title);
        }

        public string CheckBox1 = "//form[@id='checkboxes']//input[1]";
        public string CheckBox2 = "//form[@id='checkboxes']//input[2]";
        public void ClickonCheckBoxes()
        {
            bool status = driver.FindElement(By.XPath(CheckBox1)).Selected;
            Console.WriteLine(status);
        }
    }
}
