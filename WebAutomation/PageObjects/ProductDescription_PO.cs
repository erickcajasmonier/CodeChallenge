using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using WebAutomation.BaseTest;

namespace WebAutomation.PageObjects
{
    public class ProductDescription_PO : Base_Page
    {
        public ProductDescription_PO(RemoteWebDriver webDriver) : base(webDriver) { }

        private By productName = By.ClassName("name");
        private By productPrice = By.ClassName("price-container");
        private By addToBardButton = By.XPath("//*[contains(@onclick,'addToCart')]");
        
        public string GetProductNameText()
        {
            return GetText(productName);
        }

        public string GetProductPrice()
        {
            return GetText(productPrice).Substring(1).Replace(" *includes tax", "");
        }

        public void ClickAddToCart()
        {
            Click(addToBardButton);
        }
    }
}
