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
    public class Story3 : BasePage
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            RunDriver();
        }

        [Test]
        public void US3()
        {
            var index = new IndexPage(driver);
            var summerDresses = new SummerDressesPage(driver);

            index.HoverwomenNavBar();
            index.ClickSummerDresses();

            summerDresses.ChangeSliderValues();

            //Assert.IsTrue(summerDresses.AreProdsBetween16and20());
        }

        //[OneTimeTearDown]
        public void TearDown()
        {
            Thread.Sleep(3000);
            CleanUp();
        }
    }
}
