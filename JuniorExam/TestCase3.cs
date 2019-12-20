using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;

namespace JuniorExam
{
    [TestFixture]
    public class TestCase3
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
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(formAuthLinkXPath)));
            
        }

        [Test]
        public void TestCase3Scenario()
        {
            IWebElement keyPressesLink = driver.FindElement(By.XPath("//*[text()='Key Presses']"));
            keyPressesLink.Click();

            IWebElement textFieldInput = driver.FindElement(By.Id("target"));
            
            textFieldInput.Clear();
            textFieldInput.SendKeys("1");

            IWebElement textFieldResult = driver.FindElement(By.Id("result"));
            Assert.IsTrue(textFieldResult.Text.Contains("1"));

            textFieldInput.Clear();
            textFieldInput.SendKeys("2");
            Assert.IsTrue(textFieldResult.Text.Contains("2"));

            textFieldInput.Clear();
            textFieldInput.SendKeys("3");
            Assert.IsTrue(textFieldResult.Text.Contains("3"));

            textFieldInput.Clear();
            textFieldInput.SendKeys("4");
            Assert.IsTrue(textFieldResult.Text.Contains("4"));

        }
        

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        
    }
}
