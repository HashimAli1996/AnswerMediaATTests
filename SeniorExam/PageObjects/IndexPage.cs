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
    public class IndexPage: BasePage
    {
        IWebDriver driver;
        public IndexPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//img[@title='Faded Short Sleeve T-shirts']")]
        private IWebElement item;

        [FindsBy(How = How.XPath, Using = "//ul[@id='homefeatured']/li[1]/descendant::div[contains(@class,'button-container')]/a")]
        private IWebElement itemBtn;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Proceed to checkout')]")]
        private IWebElement itemProceedToCheckout;
        string itemProceedToCheckoutXPath = "//*[contains(text(),'Proceed to checkout')]";

        [FindsBy(How = How.XPath, Using = "//div[@id='block_top_menu']/descendant::a[@title='Women']")]
        private IWebElement womenNavbar;

        [FindsBy(How = How.XPath, Using = "/html/body/div/div[1]/header/div[3]/div/div/div[6]/ul/li[1]/ul/li[2]/ul/li[3]/a")]
        private IWebElement subNavBarSummerDressLink;
        string subNavBarSummerDressLinkXPath = "/html/body/div/div[1]/header/div[3]/div/div/div[6]/ul/li[1]/ul/li[2]/ul/li[3]/a";

        [FindsBy(How = How.XPath, Using = "//a[@class='login']")]
        private IWebElement signIn;

        [FindsBy(How = How.XPath, Using = "//section[@id='block_various_links_footer']/descendant::a[contains(text(), 'Our stores')]")]
        private IWebElement ourStoresLink;

        public void AddItemToBasket()
        {
            Actions actions = new Actions(driver);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            

            executor.ExecuteScript("arguments[0].scrollIntoView(true);", item);
            Thread.Sleep(1000);

            actions.MoveToElement(item);
            actions.Perform();

            itemBtn.Click();
            
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(itemProceedToCheckoutXPath)));

            itemProceedToCheckout.Click();
        }

        public Boolean HoverwomenNavBar()
        {
            Boolean flag = false;
            Actions actions = new Actions(driver);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            actions.MoveToElement(womenNavbar).Perform();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(subNavBarSummerDressLinkXPath)));
            
            if (subNavBarSummerDressLink.Displayed)
            {
                flag = true;
            }

            return flag;
        }

        public void ClickSummerDresses()
        {
            subNavBarSummerDressLink.Click();
        }

        public Boolean AreSummerDressShown()
        {
            Boolean flag = false;

            return flag;
        }
        public void NavigateToSignIn()
        {
            signIn.Click();
        }

        public void NavigateToOurStores()
        {
            ourStoresLink.Click();
        }
    }
}
