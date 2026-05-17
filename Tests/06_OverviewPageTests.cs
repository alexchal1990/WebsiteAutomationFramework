using NUnit.Framework;
using SeleniumProject.Pages;

namespace SeleniumProject.Tests
{
    
    [TestFixture]
    [Category("Overview")]
    public class OverviewPageTests : BaseTest
    {
        [Test]
        public void ValidateItemNames()
        {
            new LoginPage(driver).LoginSuccess("standard_user","secret_sauce");

            var product = new ProductPage(driver);
            product.AddTocart("sauce-labs-backpack");

            var overview = product
                           .GoToCart()
                           .GoToCheckout()
                           .FillCheckOutInfo("alex","chal","cv23dw")
                           .Continue();
            Assert.That(overview.GetProductname(),Is.EqualTo("Sauce Labs Backpack"));
                                            
        }

        [Test]
        public void ValidateItemPrices()
        {
            new LoginPage(driver).LoginSuccess("standard_user","secret_sauce");

            var product = new ProductPage(driver);
            product.AddTocart("sauce-labs-backpack");

            var overview = product
                           .GoToCart()
                           .GoToCheckout()
                           .FillCheckOutInfo("alex","chal","cv23dw")
                           .Continue();
            Assert.That(overview.GetItemPrice(),Does.Contain("29.99"));
        }

        [Test]
        public void ValidateTaxAndTotal()
        {
             new LoginPage(driver).LoginSuccess("standard_user","secret_sauce");

            var product = new ProductPage(driver);
            product.AddTocart("sauce-labs-backpack");

            var overview = product
                           .GoToCart()
                           .GoToCheckout()
                           .FillCheckOutInfo("alex","chal","cv23dw")
                           .Continue();
            Assert.That(overview.GetTax(),Does.Contain("Tax"));
            Assert.That(overview.GetTotal(),Does.Contain("Total"));
        }

       
        [Test]
        public void FinishOrder_GoToFinishPage()
        {
             new LoginPage(driver).LoginSuccess("standard_user","secret_sauce");

              var product = new ProductPage(driver);
            product.AddTocart("sauce-labs-backpack");

            var overview = product
                           .GoToCart()
                           .GoToCheckout()
                           .FillCheckOutInfo("alex","chal","cv23dw")
                           .Continue()
                           .FinishOrder();
                           
            Assert.That(driver.Url,Does.Contain("checkout-complete.html"));
        }
       



    }
}