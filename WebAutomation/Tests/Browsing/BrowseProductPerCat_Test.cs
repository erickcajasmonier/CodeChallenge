using NUnit.Framework;
using WebAutomation.PageObjects;
using WebAutomation.Utils;

namespace WebAutomation

{
    //FIXME: set the browsers that you would like to run the test
    //[TestFixture("firefox")]
    [TestFixture("chrome")]
    public class BrowseProductPerCat_Test : BaseTest.Base_Test
    {
        //pass browser to construct the base_test class
        public BrowseProductPerCat_Test(string browser) : base(browser) { }

        //initialize all page object classes that will be used for the test
        Home_PO homePage;

        [Test]
        public void ValidateProductsInPhonesCategory()
        {
            homePage = new Home_PO(webDriver);
            homePage.ClickPhonesCategory();

            //Assert that the category UI is showing the same data as the API
            Assert.Multiple(async () =>
            {
                foreach (string productTitle in await Helpers.GetCategoryProductTitlesWithAPI("phone"))
                {
                    Assert.True(homePage.ProductIsDisplayedByCategory(productTitle));
                }
            });
        }

        [Test]
        public void ValidateProductsInLaptopsCategory()
        {
            homePage = new Home_PO(webDriver);
            homePage.ClickLaptopsCategory();

            //Assert that the category UI is showing the same data as the API
            Assert.Multiple(async () =>
            {
                foreach (string productTitle in await Helpers.GetCategoryProductTitlesWithAPI("notebook"))
                {
                    Assert.True(homePage.ProductIsDisplayedByCategory(productTitle));
                }
            });
        }

        [Test]
        public void ValidateProductsInMonitorsCategory()
        {
            homePage = new Home_PO(webDriver);
            homePage.ClickMonitorsCategory();

            //Assert that the category UI is showing the same data as the API
            Assert.Multiple(async () =>
            {
                foreach (string productTitle in await Helpers.GetCategoryProductTitlesWithAPI("monitor"))
                {
                    Assert.True(homePage.ProductIsDisplayedByCategory(productTitle));
                }
            });
        }
    }
}