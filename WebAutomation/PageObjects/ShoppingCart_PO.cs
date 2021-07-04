using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using WebAutomation.BaseTest;

namespace WebAutomation.PageObjects
{
    class ShoppingCart_PO : Base_Page
    {
        public ShoppingCart_PO(RemoteWebDriver webDriver) : base(webDriver) { }

        private By placeOrderButton = By.ClassName("btn-success");
        private By deleteButton = By.XPath("//*[contains(@onclick,'deleteItem')]");
        private By totalPrice = By.Id("totalp");

        public void ClickDelete()
        {
            Click(deleteButton);
        }

        public void ClickPlaceOrder()
        {
            Click(placeOrderButton);
        }

        public string GetTotalPriceText()
        {
            return GetText(totalPrice);
        }

        public Boolean DeleteButtonIsDisplayed()
        {
            return IsDisplayed(deleteButton);
        }
        public Boolean ProductIsDisplayedInCart(string productTableItem)
        {
            var element = FindElementByText(productTableItem);
            return element != null && IsDisplayed(element);
        }
    }
}
