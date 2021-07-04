using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;

namespace WebAutomation.BaseTest
{
    public class Base_Test
    {
        public RemoteWebDriver webDriver;
        protected string browser;
        public string homeUrl = "https://www.demoblaze.com/index.html";

        public Base_Test(string browser)
        {
            this.browser = browser;
        }

        [SetUp]
        public void Setup()
        {
            //set different browser drivers to allow crossbrowser testing
            switch (browser) {
                case "chrome":
                    webDriver = new ChromeDriver();
                    break;
                case "ie":
                    webDriver = new InternetExplorerDriver();
                    break;
                case "edge":
                    webDriver = new EdgeDriver();
                    break;
                case "firefox":
                    webDriver = new FirefoxDriver();
                    break;
                default:
                    webDriver = new ChromeDriver();
                    break;
            }
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(homeUrl);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void TearDown()
        {
            webDriver.Quit();
        }
    }
}
