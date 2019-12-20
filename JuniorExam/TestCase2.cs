using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;
using System.Threading;

namespace JuniorExam
{
    [TestFixture]
    public class TestCase2
    {
        public static IWebDriver driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("disable-infobars");

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");            
        }

        [Test]
        public void TestCase2Scenario()
        {
            // click infinite scroll
            IWebElement infiniteScrollLink = driver.FindElement(By.XPath("//*[text()='Infinite Scroll']"));
            infiniteScrollLink.Click();

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            //scroll to bottom of page x2
            long InitialpageHeight = (long)(executor.ExecuteScript("return document.body.scrollHeight"));
            int i = 0;
            while (i <= 2) {
                executor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                Thread.Sleep(2000);
                long curPageHeight = (long)(executor.ExecuteScript("return document.body.scrollHeight"));

                if(curPageHeight == InitialpageHeight)
                {
                    break;
                }

                if(curPageHeight > InitialpageHeight)
                {
                    i += 1;
                }
            }
            
            // scroll up to top of page
            executor.ExecuteScript("window.scrollTo(0,0);");

            IWebElement infinScr = driver.FindElement(By.XPath("//div[@class='example']/h3"));
            //assert header
            Assert.AreEqual("Infinite Scroll", infinScr.Text);
            
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
