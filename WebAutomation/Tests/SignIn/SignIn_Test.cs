using NUnit.Framework;
using WebAutomation.Model;
using WebAutomation.PageObjects;

namespace WebAutomation

{
    //FIXME: set the browsers that you would like to run the test
    //[TestFixture("firefox")]
    [TestFixture("chrome")]
    public class SignIn_Test : BaseTest.Base_Test
    {
        //pass browser to construct the base_test class
        public SignIn_Test(string browser) : base(browser) { }

        //initialize all page object classes that will be used for the test
        Home_PO homePage;
        SignIn_PO signInModal;

        [Test]
        public void ValidateSuccessfulSignIn()
        {
            User user = new User();

            homePage = new Home_PO(webDriver);
            homePage.ClickOnSignIn();

            signInModal = new SignIn_PO(webDriver);
            signInModal.SignInWithRandomUserAndPassword(user);

            string alertMessage = signInModal.GetAlertMessage();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("Sign up successful.", alertMessage);
            });
        }
    }
}