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
    public class SignInPage: BasePage
    {
        IWebDriver driver;
        public SignInPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "email_create")]
        private IWebElement registrationEmailField;

        [FindsBy(How = How.Id, Using = "create_account_error")]
        private IWebElement emailAlreadyUsedError;

        [FindsBy(How = How.Id, Using = "SubmitCreate")]
        private IWebElement createAccountBtn;

        string xpathFromElementOnFormPage = "//div[@id='noSlide']";

        public String ClickRegister()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Random rnd = new Random();
            int i = rnd.Next(0, 1000);

            String newEmail = "example" + i + "@email.com";
            String newEmail2 = "example" + i + "@email.com";

            registrationEmailField.SendKeys(newEmail);

            if (emailAlreadyUsedError.Displayed)
            {
                registrationEmailField.SendKeys(newEmail2);

                createAccountBtn.Click();
                return newEmail2;
            }
            createAccountBtn.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpathFromElementOnFormPage)));
            return newEmail;
        }
    }
}
