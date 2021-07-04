using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using WebAutomation.BaseTest;
using WebAutomation.Utils;

namespace WebAutomation.PageObjects
{
    public class Home_PO : Base_Page
    {        
        //pass driver to construct the base_page class
        public Home_PO(RemoteWebDriver webDriver) : base(webDriver) { }

        private By signInButton = By.Id("signin2");
        private By logInButton = By.Id("login2");
        private By cartButton = By.Id("cartur");
        private By welcomeUser = By.Id("nameofuser");
        private By phoneCategory = By.CssSelector("a[onclick=\"byCat('phone')\"]");
        private By notebookCategory = By.CssSelector("a[onclick=\"byCat('notebook')\"]");
        private By monitorCategory = By.CssSelector("a[onclick=\"byCat('monitor')\"]");
        private By listOfCategories = By.Id("itemc");
        private By listOfProducts = By.ClassName("card-title");

        public void ClickOnSignIn()
        {
            Click(signInButton);
        }

        public void ClickOnLogIn()
        {
            Click(logInButton);
        }

        public void ClickOnCart()
        {
            Click(cartButton);
        }

        public string GetWelcomeUserText()
        {
            return GetText(welcomeUser);
        }

        public void ClickPhonesCategory()
        {
            Click(phoneCategory);
        }

        public void ClickLaptopsCategory()
        {
            Click(notebookCategory);
        }

        public void ClickMonitorsCategory()
        {
            Click(monitorCategory);
        }

        public Boolean ProductIsDisplayedByCategory(string productTitle)
        {
            var element = FindElementByText(productTitle);
            return element != null && IsDisplayed(element);
        }

        public void ClickRandomCategory()
        {
            var categories = FindElementsBy(listOfCategories);
            int randomNumber = Helpers.GetRandomNumber(categories.Count-1);
            Click(categories[randomNumber]);
        }

        public void ClickRandomProduct()
        {
            var products = FindElementsBy(listOfProducts);
            int randomNumber = Helpers.GetRandomNumber(products.Count-1);
            Click(products[randomNumber]);
        }
    }
}
