
using NUnit.Framework;
using SeleniumProject.Pages;

namespace SeleniumProject.Tests
{   
    [TestFixture]
    [Category("Cart")]
    public class CartTests : BaseTest
    {   

       [Test]
        public void CartPageLoadsCorrectly()
        {
             new LoginPage(driver).LoginSuccess("standard_user","secret_sauce");

            var product = new ProductPage(driver);
            product.AddTocart("sauce-labs-backpack");
            var cart = product.GoToCart();
            Assert.That(cart.IsPageLoaded(), Is.True);   
        }

        [Test]
        public void ProductAppearsInCart()
        {
            new LoginPage(driver).LoginSuccess("standard_user","secret_sauce");

            var product = new ProductPage(driver);
            product.AddTocart("sauce-labs-backpack");

            var cart = product.GoToCart();
            Assert.That(cart.GetProductName(), Is.EqualTo(true));
        }
        [Test]
        public void CheckoutWithEmptyCart()
        {
         new LoginPage(driver).LoginSuccess("standard_user","secret_sauce");

         var product = new ProductPage(driver);
          var cart = product.GoToCart();
          cart.GoToCheckout(); 
          Assert.That(driver.Url,Does.Contain("checkout-step-one.html"));
        }

        [Test]
        public void ContinueShopping_ReturnsToProductPage()
        {
          new LoginPage(driver).LoginSuccess("standard_user","secret_sauce");

            var product = new ProductPage(driver);
            product.AddTocart("sauce-labs-backpack");

            var cart = product.GoToCart();
            cart.ContinueShopping();
            Assert.That(driver.Url, Does.Contain("inventory"));   
        }

      
        [Test]
        public void RemoveMultipleProducts()
        {
            new LoginPage(driver).LoginSuccess("standard_user","secret_sauce");

            var product = new ProductPage(driver);

            product.AddTocart("sauce-labs-backpack");
            product.AddTocart("sauce-labs-bolt-t-shirt");

            var cart = product.GoToCart();

                cart.RemoveItem("sauce-labs-backpack");
                cart.RemoveItem("sauce-labs-bolt-t-shirt");
                Assert.That(cart.IsCartEmpty(),Is.True);
        }

          [Test]
        public void NavigateToCheckOutPage()
        {
         new LoginPage(driver).LoginSuccess("standard_user","secret_sauce");

         var product = new ProductPage(driver);
          var cart = product.GoToCart();              
          cart.GoToCheckout(); 
          Assert.That(driver.Url,Does.Contain("checkout-step-one.html"));
        }
       
    }





}