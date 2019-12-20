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
    public class SummerDressesPage: BasePage
    {
        IWebDriver driver;
        public SummerDressesPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@id='center_column']/descendant::span[contains(text(), 'Summer Dresses')]")]
        private IWebElement summerDressesPageHeader;

        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div[3]/div[2]/ul/li[1]/div/div[2]/h5/a")]
        private IWebElement productItemName;

        [FindsBy(How = How.XPath, Using = "//div[@id='layered_price_slider']/a[2]")]
        private IWebElement sliderRightHandle;

        [FindsBy(How = How.XPath, Using = "//div[@id='pagination']")]
        private IWebElement productCount;



        public Boolean AreSummerDressShown()
        {
            Boolean flag = false;

            if(summerDressesPageHeader.Text.Contains("Summer Dresses") && productItemName.Text.Contains("Summer Dress"))
            {
                flag = true;
            }
            return flag;
        }

        public void ChangeSliderValues()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            Actions actions = new Actions(driver);

            //get width of slider bar



            executor.ExecuteScript("arguments[0].scrollIntoView(true)", productCount);
            //actions.DragAndDropToOffset(sliderRightHandle, ((int)sliderRightHandle.Size.Width / 4), 0).Perform();
            actions.DragAndDropToOffset(sliderRightHandle, sliderRightHandle.Size.Width / 4, 0).Perform();
        }

       

        public Boolean AreProdsBetween16and20()
        {
            Boolean flag = false;
            
            //couldnt code the fi statement due to infinite load
            //Logic: If **product which exists*, convert string to int, compare $16 >= product <= 20
            
            return flag;
        }
    }
}
