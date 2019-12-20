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
    public class TestCase1
    {
        public static IWebDriver driver;
        string wrongPW = "wrong";
        string wrongUN = "wrong";
        string username = "tomsmith";
        string password = "SuperSecretPassword!";
        

        [OneTimeSetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("disable-infobars");

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com");            
        }

        

        [Test]
        public void TestCase1Scenario1()
        {
            IWebElement formAuthLink = driver.FindElement(By.XPath("//*[text()='Form Authentication']"));
            formAuthLink.Click();

            IWebElement usernameField = driver.FindElement(By.Id("username"));
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            IWebElement loginBtn = driver.FindElement(By.XPath("//form[@id='login']/button"));


            //try to login with correct username but wrong password
            usernameField.SendKeys(username);
            passwordField.SendKeys(wrongPW);

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", loginBtn);
            Thread.Sleep(1000);

            IWebElement flashMessage = driver.FindElement(By.Id("flash"));


            //assert validation
            Assert.IsFalse(returnResult(flashMessage));
            //expected result: login fails and alerts user username incorrect
        }

        [Test]
        //[Ignore("")]
        public void TestCase1Scenario2()
        {
            string currUrl = driver.Url;
            if(currUrl != "http://the-internet.herokuapp.com/login")
            {
            IWebElement formAuthLink = driver.FindElement(By.XPath("//*[text()='Form Authentication']"));
            formAuthLink.Click();
            }

            IWebElement usernameField = driver.FindElement(By.Id("username"));
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            IWebElement loginBtn = driver.FindElement(By.XPath("//form[@id='login']/button"));
            
            //then incorrect username and correct password
            usernameField.SendKeys(wrongUN);
            passwordField.SendKeys(password);
            loginBtn.Click();
            


            IWebElement flashMessage = driver.FindElement(By.Id("flash"));
            //assert validation
            Assert.IsFalse(returnResult(flashMessage));
            //expected result: login fails and alerts user password incorrect
        }

        [Test]
        //[Ignore("")]
        public void TestCase1Scenario3()
        {
            string currUrl = driver.Url;
            if (currUrl != "http://the-internet.herokuapp.com/login")
            {
                IWebElement formAuthLink = driver.FindElement(By.XPath("//*[text()='Form Authentication']"));
                formAuthLink.Click();
            }

            IWebElement usernameField = driver.FindElement(By.Id("username"));
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            IWebElement loginBtn = driver.FindElement(By.XPath("//form[@id='login']/button"));
            //then correct username and password
            usernameField.SendKeys(username);
            passwordField.SendKeys(password);
            loginBtn.Click();



            Thread.Sleep(2000);
            IWebElement flashMessage = driver.FindElement(By.Id("flash"));
            Assert.IsTrue(returnResult(flashMessage));
            //logout
            IWebElement logoutBtn = driver.FindElement(By.XPath(".//div[@id='content']/div/a"));
            logoutBtn.Click();
            Thread.Sleep(2000);
            IWebElement flashMessage2 = driver.FindElement(By.Id("flash"));
            Assert.IsTrue(returnResult(flashMessage2));


        }

        public Boolean returnResult(IWebElement alert)
        {
            int log = 0;
            Boolean flag = false;
            Console.WriteLine(alert.Text);
            //if login successful return true
            if (alert.Text.Contains("You logged into a secure area!")
                || alert.Text.Contains("You logged out of the secure area!"))
            {
                flag = true;
            }
            log += 1;
            Console.WriteLine(log.ToString() + flag.ToString());

            return flag;
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        
    }
}
