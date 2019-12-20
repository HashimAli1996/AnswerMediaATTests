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
using System.Drawing.Imaging;
using SeniorExam.BaseClass;
using System.IO;

namespace SeniorExam.PageObjects
{
    public class OurStoresPage: BasePage
    {
        IWebDriver driver;
        public OurStoresPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[@class='dismissButton']")]
        private IWebElement dismissBtn;
        private string disMissBtnXPath = "//button[@class='dismissButton']";

        [FindsBy(How = How.XPath, Using = "//div[@id='center_column']")]
        private IWebElement content;

        [FindsBy(How = How.XPath, Using = "//button[@title='Zoom out']")]
        private IWebElement zoomOutBtn;

        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div[3]/div/div[1]/div/div/div[1]/div[3]/div/div[3]/div[2]/img")]
        private IWebElement markerGMaps;

        [FindsBy(How = How.XPath, Using = "//button[@class='gm-ui-hover-effect']")]
        private IWebElement closeMarkerInfoBtn;
        private string closeMarkerInfoBtnXPath = "//button[@class='gm-ui-hover-effect']";

        private string currDirectory = Directory.GetCurrentDirectory();



        public void dismissAlert()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].scrollIntoView(true)", content);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(disMissBtnXPath)));

            dismissBtn.Click();
        }

        public void DragMap()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Actions actions = new Actions(driver);
            //first zoom out once
            zoomOutBtn.Click();
            markerGMaps.Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(closeMarkerInfoBtnXPath)));
            closeMarkerInfoBtn.Click();
        }

        public void TakeScreenShot()
        {
            Screenshot westPalmBeach = ((ITakesScreenshot)driver).GetScreenshot();
            westPalmBeach.SaveAsFile(currDirectory+"\\image.png", ScreenshotImageFormat.Png);
        }

        public Boolean IsScreenShotCorrectAndSaved()
        {
            Boolean flag = false;
            if (File.Exists(currDirectory + "\\image.png"))
            {
                flag = true;
            }
            return flag;
        }
    }
}
