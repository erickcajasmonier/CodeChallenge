using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using WebAutomation.BaseTest;
using WebAutomation.Model;
using WebAutomation.Utils;

namespace WebAutomation.PageObjects
{
    public class SignIn_PO : Base_Page
    {
        //pass driver to construct the base_page class
        public SignIn_PO(RemoteWebDriver webDriver) : base(webDriver) { }

        private By userName = By.Id("sign-username");
        private By password = By.Id("sign-password");
        private By signUpButton = By.CssSelector("button[onclick='register()']");

        public void SignInWithRandomUserAndPassword(User user)
        {
            WriteRandomUsername(user);
            WriteRandomPassword();
            ClickSignUp();
        }

        public void WriteRandomUsername(User user)
        {
            user.UserName = Helpers.GenerateRandomLettersAndNumbers(10);
            SendKeys(userName, user.UserName);
        }

        public void WriteRandomPassword()
        {
            SendKeys(password, Helpers.GenerateRandomLettersAndNumbers(5));
        }

        public void ClickSignUp()
        {
            Click(signUpButton);
        }
    }
}
