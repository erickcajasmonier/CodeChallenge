using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using WebAutomation.BaseTest;

namespace WebAutomation.PageObjects
{
    public class Login_PO : Base_Page
    {
        //pass driver to construct the base_page class
        public Login_PO(RemoteWebDriver webDriver) : base(webDriver) { }

        private By userName = By.Id("loginusername");
        private By password = By.Id("loginpassword");
        private By logInButton = By.CssSelector("button[onclick='logIn()']");

        public void LogInWithUser(string userNameText, string passwordText)
        {
            WriteUserName(userNameText);
            WritePassword(passwordText);
            ClickLogIn();
        }

        public void WriteUserName(string userNameText)
        {
            SendKeys(userName, userNameText);
        }

        public void WritePassword(string passwordText)
        {
            SendKeys(password, passwordText);
        }

        public void ClickLogIn()
        {
            Click(logInButton);
        }
    }
}
