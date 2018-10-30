using System;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace paralleluitestwithseleniuminvisualstudio
{
    [TestClass]
    public class UITest
    {
        protected IWebDriver WebDriver;
        protected DriverOptions Options;

        public UITest(DriverOptions options)
        {
            this.Options = options;
        }

        [TestInitialize]
        public virtual void Setup()
        {
            var configuration =
                new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile("appsettings.json")
                    .AddEnvironmentVariables()
                    .Build();

            var seleniumOptions = new SeleniumOptions();
            configuration.Bind("SeleniumDockerHost", seleniumOptions);
            this.WebDriver = new RemoteWebDriver(seleniumOptions.WebDriverUri, this.Options);
            this.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TestCleanup]
        public virtual void Cleanup()
        {
            this.WebDriver?.Close();
            this.WebDriver?.Quit();
        }

        public void Shoud_Search_In_Google()
        {
            string imageFile = "c:\\temp\\Shoud_Search_In_Google" + this.Options.BrowserName + ".png";
            WebDriver.Navigate().GoToUrl("https://www.google.com/");
            WebDriver.FindElement(By.Id("lst-ib")).Clear();
            WebDriver.FindElement(By.Id("lst-ib")).SendKeys("Hello World! Parallel Sample");
            WebDriver.FindElement(By.Id("lst-ib")).SendKeys(OpenQA.Selenium.Keys.Enter);
            ((ITakesScreenshot)WebDriver).GetScreenshot().SaveAsFile(imageFile, ScreenshotImageFormat.Png);
        }

        public void Shoud_I_Test_My_WebApp()
        {
            string imageFile = "c:\\temp\\Shoud_I_Test_My_WebApp" + this.Options.BrowserName + "_#.png";
            int stopValue = 10;            
            WebDriver.Navigate().GoToUrl("http://localhost:8000");
            ((ITakesScreenshot)WebDriver).GetScreenshot().SaveAsFile(imageFile.Replace("#", "1"), ScreenshotImageFormat.Png);
            WebDriver.TakeScreenshot();
            for (int i = 1; i <= stopValue; i++)
            {
                ((ITakesScreenshot)WebDriver).GetScreenshot().SaveAsFile(imageFile.Replace("#", "2"), ScreenshotImageFormat.Png);
                IWebElement elem = WebDriver.FindElement(By.Id("buttonCounter"));
                elem.Click();
            }
            string currentCounter = WebDriver.FindElement(By.Id("textCounter")).GetAttribute("value");
            Assert.AreEqual(currentCounter, stopValue.ToString());
        }
    }
}


