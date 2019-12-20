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
    public class Story1 : BasePage
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            RunDriver();
        }

        [Test]
        public void US1()
        {
            var index = new IndexPage(driver);
            var checkout = new CheckoutPage(driver);

            //Add item to basket
            index.AddItemToBasket();

            
            //Assert first that we are on checkout/basket page
            Assert.IsTrue(checkout.IsPageCorrect());

            //check there is a delete button and if so delete
            Assert.IsTrue(checkout.DeleteItem());

            //verify item is deleted
            Assert.IsTrue(checkout.IsItemDeleted());
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Thread.Sleep(3000);
            CleanUp();
        }
    }
}
