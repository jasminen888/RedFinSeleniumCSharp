using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace RHSAutomationTest.tests
{
    
    public class BaseTests
    {
       
        public static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.redfin.com/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}