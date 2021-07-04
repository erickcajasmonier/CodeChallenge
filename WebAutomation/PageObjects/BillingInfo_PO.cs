using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using WebAutomation.BaseTest;
using WebAutomation.Model;
using WebAutomation.Utils;

namespace WebAutomation.PageObjects
{
    public class BillingInfo_PO : Base_Page
    {
        public BillingInfo_PO(RemoteWebDriver webDriver) : base(webDriver) { }

        private By name = By.Id("name");
        private By cardNumber = By.Id("card");
        private By purchaseButton = By.CssSelector("button[onclick='purchaseOrder()']");

        public void CompletePurchaseWithRequiredInfo(User user, BillingInfo billingInfo)
        {
            WriteName(user);
            WriteCardNumber(billingInfo);
            ClickPurchase();
        }

        public void WriteName(User user)
        {
            user.Name = Helpers.GenerateRandomString(10);
            SendKeys(name, user.Name);
        }

        public void WriteCardNumber(BillingInfo billingInfo)
        {
            billingInfo.CardNumber = Helpers.GenerateRandomNumbers(15);
            SendKeys(cardNumber, billingInfo.CardNumber);
        }

        public void ClickPurchase()
        {
            Click(purchaseButton);
        }
    }
}
