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
    public class Story2 : BasePage
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            RunDriver();
        }

        [Test]
        public void US2()
        {
            var index = new IndexPage(driver);
            var summerDresses = new SummerDressesPage(driver);
            //hover nav bar
            index.HoverwomenNavBar();
            
            //assert sub mac bar shows
            Assert.IsTrue(index.HoverwomenNavBar());

            index.ClickSummerDresses();
            
            //verify summer dress page/ only summer dresses being shown
            Assert.IsTrue(summerDresses.AreSummerDressShown());
            
        }

        //[OneTimeTearDown]
        public void TearDown()
        {
            Thread.Sleep(3000);
            CleanUp();
        }
    }
}
