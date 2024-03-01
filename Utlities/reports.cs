using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowProjectDemo.Utlities
{
    public class reports
    {
        public static ExtentReports extentReports;
        public static ExtentTest feature;
        public static ExtentTest scenario;
        
        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestReports");

        public static void ExtentReportInit()
        {
            var htmlReporter = new ExtentHtmlReporter(testResultPath);
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Test Report";
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Start();

            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);
            extentReports.AddSystemInfo("Browser", "Chrome");
            extentReports.AddSystemInfo("OS", "Windows");
        }
        public static void ExtentReportTearDown()
        {
            extentReports.Flush();
        }
    }
}
