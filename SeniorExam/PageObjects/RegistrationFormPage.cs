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
    public class RegistrationFormPage: BasePage
    {
        IWebDriver driver;
        public RegistrationFormPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //[FindsBy(How = How.Id, Using = "uniform-id_gender1")]
        //private IWebElement titleMrRadioBtn;

        [FindsBy(How = How.Id, Using = "customer_firstname")]
        private IWebElement fName;

        [FindsBy(How = How.Id, Using = "customer_lastname")]
        private IWebElement lName;

        [FindsBy(How = How.Id, Using = "passwd")]
        private IWebElement password;

        [FindsBy(How = How.Id, Using = "days")]
        private IWebElement dobDay;

        [FindsBy(How = How.Id, Using = "months")]
        private IWebElement dobMonth;

        [FindsBy(How = How.Id, Using = "years")]
        private IWebElement dobYears;

        [FindsBy(How = How.Id, Using = "firstname")]
        private IWebElement addressFirstName;

        [FindsBy(How = How.Id, Using = "lastname")]
        private IWebElement addressLastName;

        [FindsBy(How = How.Id, Using = "address1")]
        private IWebElement address;

        [FindsBy(How = How.Id, Using = "city")]
        private IWebElement city;

        [FindsBy(How = How.Id, Using = "id_country")]
        private IWebElement country;

        [FindsBy(How = How.Id, Using = "id_state")]
        private IWebElement state;

        [FindsBy(How = How.Id, Using = "postcode")]
        private IWebElement zipPostalCode;        

        [FindsBy(How = How.Id, Using = "phone_mobile")]
        private IWebElement mobilePhoneNum;

        [FindsBy(How = How.XPath, Using = "//div[@id='center_column']/div[1]/p")]
        private IWebElement errorAlert;

        [FindsBy(How = How.XPath, Using = "//button[@id='submitAccount']")]
        private IWebElement submitBtn;

        public void EnterIncorrect()
        {
            Thread.Sleep(3000);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView(true);", submitBtn);
            submitBtn.Click();
        }

        

        public void EnterCorrectInfo()
        {
            Thread.Sleep(3000);
            //titleMrRadioBtn.Click();
            fName.SendKeys("hashim");
            lName.SendKeys("ali");
            password.SendKeys("HashimRulez");
            dobDay.SendKeys("9");
            dobMonth.SendKeys("mar");
            dobYears.SendKeys("1996");
            address.SendKeys("1 addres lane");
            city.SendKeys("Super City");
            country.SendKeys("u");
            country.SendKeys(Keys.Enter);
            state.SendKeys("a");
            state.SendKeys(Keys.Enter);
            zipPostalCode.SendKeys("00000");
            mobilePhoneNum.SendKeys("02020202020");

            submitBtn.Click();
        }

        public Boolean WasErrorAlertDisplayed()
        {
            Boolean flag = false;

            if (!errorAlert.Displayed)
            {
                flag = true;
            }

            return flag;

        }
    }
}
