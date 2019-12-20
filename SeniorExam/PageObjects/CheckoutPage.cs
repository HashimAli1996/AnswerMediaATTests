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
    public class CheckoutPage: BasePage
    {
        IWebDriver driver;
        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "cart_title")]
        private IWebElement pageHeader;

        [FindsBy(How = How.ClassName, Using = "icon-trash")]
        private IWebElement deleteBtn;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(), 'Your shopping cart is empty.')]")]
        private IWebElement emptyCartAlert;

        string emptyCartAlertXPath = "//p[contains(text(), 'Your shopping cart is empty.')]";

        [FindsBy(How = How.ClassName, Using = "ajax_cart_no_product")]
        private IWebElement cartQuickViewNum;



        public Boolean IsPageCorrect()
        {
            Boolean flag = false;
            if(pageHeader.Text.Contains("SHOPPING-CART SUMMARY"))
            {
                flag = true;
            }
            return flag;
        }

        public Boolean DeleteItem()
        {
            Boolean flag = false;
            if (deleteBtn.Displayed)
            {
                flag = true;
            }

            deleteBtn.Click();

            return flag;
        }

        public Boolean IsItemDeleted()
        {
            Boolean flag = false;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(emptyCartAlertXPath)));

            if (emptyCartAlert.Displayed && cartQuickViewNum.Text == "(empty)")
            {
                flag = true;
            }
            return flag;
        }
    }
}
