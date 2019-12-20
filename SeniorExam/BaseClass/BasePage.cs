using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace SeniorExam.BaseClass

{
    [TestFixture]
    public class BasePage
    {
        public IWebDriver driver;
        
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public BasePage() { }

        public void RunDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");            

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        public void CleanUp()
        {
            driver.Quit();
            driver.Dispose();
        }

    }
}
