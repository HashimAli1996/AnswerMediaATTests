using System.Collections;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeniorExam.BaseClass;
using SeniorExam.PageObjects;
using System.Threading;

namespace SeniorExam
{
    [TestFixture]
    public class Story5 : BasePage
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            RunDriver();
        }

        [Test]
        public void US5()
        {
            var index = new IndexPage(driver);
            var ourStores = new OurStoresPage(driver);
            //click on our stores page
            index.NavigateToOurStores();

            //click on map and drag to west palm beach
            ourStores.dismissAlert();
            
            ourStores.DragMap();
            
            // take screenshot
            ourStores.TakeScreenShot();
            
            //assert west palm beach on map and screenshot exists
            Assert.IsTrue(ourStores.IsScreenShotCorrectAndSaved());
        }

        //[OneTimeTearDown]
        public void TearDown()
        {
            Thread.Sleep(3000);
            CleanUp();
        }
    }
}
