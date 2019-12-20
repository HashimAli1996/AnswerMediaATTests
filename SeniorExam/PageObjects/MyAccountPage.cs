using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeniorExam.BaseClass;

namespace SeniorExam.PageObjects
{
    public class MyAccountPage: BasePage
    {
        IWebDriver driver;
        public MyAccountPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='header_user_info']/a/span")]
        private IWebElement accShortcutNameDisplay;

        [FindsBy(How = How.XPath, Using = "//div[@id='center_column']/p[@class='info-account']")]
        private IWebElement myAccountWelcomeInfo;

        public Boolean IsNamePresent()
        {
            Boolean flag = false;

            if(accShortcutNameDisplay.Text.Contains("hashim ali"))
            {
                flag = true;
            }

            return flag;
        }

        public Boolean arrivedOnPage()
        {
            Boolean flag = false;

            if (myAccountWelcomeInfo.Displayed)
            {
                flag = true;
            }

            return flag;
        }
    }
}
