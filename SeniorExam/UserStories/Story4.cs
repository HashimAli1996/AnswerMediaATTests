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
    public class Story4 : BasePage
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            RunDriver();
        }

        [Test]
        public void US4ScenarioWrongInfo()
        {
            var index = new IndexPage(driver);
            var signIn = new SignInPage(driver);
            var register = new RegistrationFormPage(driver);

            //from home click signin
            index.NavigateToSignIn();

            //from signin register with email
            signIn.ClickRegister();

            //go to form page and send keys for info
            register.EnterIncorrect();

            //send wrong info to assert error message
            Assert.IsFalse(register.WasErrorAlertDisplayed());
        }

        [Test]
        //[Ignore("")]
        public void US4ScenarioCorrectInfo()
        {
            var index = new IndexPage(driver);
            var signIn = new SignInPage(driver);
            var register = new RegistrationFormPage(driver);
            var myAccount = new MyAccountPage(driver);
            //from home click signin
            index.NavigateToSignIn();

            //from signin register with email
            signIn.ClickRegister();

            //go to form page and send keys for info
            //correct info/no error takes us to account page
            register.EnterCorrectInfo();

            //arrived at my account page?
            Assert.IsTrue(myAccount.arrivedOnPage());

            //assert my account page and name on top right corner
            Assert.IsTrue(myAccount.IsNamePresent());
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Thread.Sleep(3000);
            CleanUp();
        }
    }
}
