using NUnit.Framework;
using System;
using System.Threading;
using WebAutomation.PageObjects;
using WebAutomation.Utils;

namespace WebAutomation

{
    //FIXME: set the browsers that you would like to run the test
    //[TestFixture("firefox")]
    [TestFixture("chrome")]
    public class ShoppingCart_Test : BaseTest.Base_Test
    {
        //pass browser to construct the base_test class
        public ShoppingCart_Test(string browser) : base(browser) { }

        //initialize all page object classes that will be used for the test
        Home_PO homePage;
        ProductDescription_PO productDescription;
        ShoppingCart_PO shoppingCart;

        //select a random category and product on each test
        [SetUp]
        public void SelectProduct()
        {
            homePage = new Home_PO(webDriver);
            homePage.ClickRandomCategory();
            homePage.ClickRandomProduct();
        }

        [Test]
        public void ValidateOneItemAddedToCart()
        {
            productDescription = new ProductDescription_PO(webDriver);
            string productName = productDescription.GetProductNameText();
            string productPrice = productDescription.GetProductPrice();
            productDescription.ClickAddToCart();
            string alertMessage = productDescription.GetAlertMessage();

            homePage.ClickOnCart();

            shoppingCart = new ShoppingCart_PO(webDriver);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("Product added", alertMessage);
                Assert.True(shoppingCart.DeleteButtonIsDisplayed());
                Assert.True(shoppingCart.ProductIsDisplayedInCart(productName));
                Assert.True(shoppingCart.ProductIsDisplayedInCart(productPrice));
                Assert.AreEqual(shoppingCart.GetTotalPriceText(), productPrice);
            });
        }

        [Test]
        public void ValidateTwoItemAddedToCart()
        {
            productDescription = new ProductDescription_PO(webDriver);
            string productPrice = productDescription.GetProductPrice();
            productDescription.ClickAddToCart();
            string alertMessage1 = productDescription.GetAlertMessage();
            productDescription.ClickAddToCart();
            string alertMessage2 = productDescription.GetAlertMessage();

            int totalPrice = Helpers.ConvertToInt(productPrice);
            totalPrice += totalPrice;

            homePage.ClickOnCart();

            shoppingCart = new ShoppingCart_PO(webDriver);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("Product added", alertMessage1);
                Assert.AreEqual("Product added", alertMessage2);
                Assert.AreEqual(shoppingCart.GetTotalPriceText(), totalPrice.ToString());
            });
        }

        [Test]
        public void ValidateDeleteItemFromCart()
        {
            productDescription = new ProductDescription_PO(webDriver);
            string productName = productDescription.GetProductNameText();
            string productPrice = productDescription.GetProductPrice();
            productDescription.ClickAddToCart();
            productDescription.GetAlertMessage();

            homePage.ClickOnCart();

            shoppingCart = new ShoppingCart_PO(webDriver);
            shoppingCart.ClickDelete();
            Thread.Sleep(TimeSpan.FromSeconds(3));

            Assert.Multiple(() =>
            {
                Assert.False(shoppingCart.DeleteButtonIsDisplayed());
                Assert.False(shoppingCart.ProductIsDisplayedInCart(productName));
                Assert.False(shoppingCart.ProductIsDisplayedInCart(productPrice));
            });
        }
    }
}