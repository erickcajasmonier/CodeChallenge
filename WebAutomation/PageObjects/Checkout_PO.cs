using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using WebAutomation.BaseTest;

namespace WebAutomation.PageObjects
{
    public class Checkout_PO : Base_Page
    {
        public Checkout_PO(RemoteWebDriver webDriver) : base(webDriver) { }

        private By okButton = By.ClassName("confirm");
        private By successIcon = By.ClassName("sa-success");

        public Boolean CheckoutMessageIsDisplayed(string checkoutMessage)
        {
            var element = FindElementByText(checkoutMessage);
            return element != null && IsDisplayed(element);
        }

        public Boolean SuccessIconIsDisplayed()
        {
            return IsDisplayed(successIcon);
        }

        public void ClickOk()
        {
            Click(okButton);
        }
    }
}
