using NUnit.Framework;
using WebAutomation.Model;
using WebAutomation.PageObjects;
using WebAutomation.Utils;

namespace WebAutomation

{
    //FIXME: set the browsers that you would like to run the test
    //[TestFixture("firefox")]
    [TestFixture("chrome")]
    public class Login_Test : BaseTest.Base_Test
    {
        //pass browser to construct the base_test class
        public Login_Test(string browser) : base(browser) { }

        //initialize all page object classes that will be used for the test
        Home_PO homePage;
        Login_PO logInModal;
        User user;

        //create a new user using api
        [SetUp]
        public void CreateUser()
        {
            user = new User
            {
                UserName = Helpers.GenerateRandomLettersAndNumbers(10),
                Password = Helpers.GenerateRandomLettersAndNumbers(5)
            };
            Helpers.CreateNewUserWithApi(user.UserName, user.Password);
        }

        [Test]
        public void ValidateSuccessfulLogin()
        {
            homePage = new Home_PO(webDriver);
            homePage.ClickOnLogIn();

            logInModal = new Login_PO(webDriver);
            logInModal.LogInWithUser(user.UserName, user.Password);

            string welcomeUserText = homePage.GetWelcomeUserText();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("Welcome " + user.UserName, welcomeUserText);
            });
        }
    }
}