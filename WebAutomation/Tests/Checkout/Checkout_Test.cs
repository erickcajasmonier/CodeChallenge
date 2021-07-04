using NUnit.Framework;
using WebAutomation.Model;
using WebAutomation.PageObjects;

namespace WebAutomation

{
    //FIXME: set the browsers that you would like to run the test
    //[TestFixture("firefox")]
    [TestFixture("chrome")]
    public class Checkout_Test : BaseTest.Base_Test
    {
        //pass browser to construct the base_test class
        public Checkout_Test(string browser) : base(browser) { }

        //initialize all page object classes that will be used for the test
        Home_PO homePage;
        ProductDescription_PO productDescription;
        ShoppingCart_PO shoppingCart;
        BillingInfo_PO billingInfo;
        Checkout_PO checkout;

        //select a random category and product, add it to cart
        [SetUp]
        public void SelectProduct()
        {
            homePage = new Home_PO(webDriver);
            homePage.ClickRandomCategory();
            homePage.ClickRandomProduct();

            productDescription = new ProductDescription_PO(webDriver);
            productDescription.ClickAddToCart();
            productDescription.GetAlertMessage();
        }

        [Test]
        public void ValidateSuccessfulPurchase()
        {
            User user = new User();
            BillingInfo billing = new BillingInfo();

            homePage.ClickOnCart();

            shoppingCart = new ShoppingCart_PO(webDriver);
            string totalPrice = shoppingCart.GetTotalPriceText();
            shoppingCart.ClickPlaceOrder();

            billingInfo = new BillingInfo_PO(webDriver);
            billingInfo.CompletePurchaseWithRequiredInfo(user, billing);

            checkout = new Checkout_PO(webDriver);

            Assert.Multiple(() =>
            {
                Assert.True(checkout.SuccessIconIsDisplayed());
                Assert.True(checkout.CheckoutMessageIsDisplayed("Amount: " + totalPrice + " USD"));
                Assert.True(checkout.CheckoutMessageIsDisplayed("Card Number: " + billing.CardNumber));
                Assert.True(checkout.CheckoutMessageIsDisplayed("Name: " + user.Name));
            });

            checkout.ClickOk();
        }

        [Test]
        public void ValidateRequiredDataNotFilled()
        {
            homePage.ClickOnCart();

            shoppingCart = new ShoppingCart_PO(webDriver);
            string totalPrice = shoppingCart.GetTotalPriceText();
            shoppingCart.ClickPlaceOrder();

            billingInfo = new BillingInfo_PO(webDriver);
            billingInfo.ClickPurchase();
            string alertMessage = billingInfo.GetAlertMessage();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("Please fill out Name and Creditcard.", alertMessage);
            });
        }
    }
}