using NUnit.Framework;
using SeleniumProject.Pages;

namespace SeleniumProject.Tests
{
    [TestFixture]
    [Category("Product")]
   public class ProductPageTests : BaseTest
    {   
        
        //private readonly By AddbtnBecomesRemove = By.Id("remove-sauce-labs-backpack");

        [Test]
        public void AddToCat()
        {
            var login = new LoginPage(driver)
                        .LoginSuccess("standard_user","secret_sauce");

            var product = new ProductPage(driver);
            product.AddTocart("sauce-labs-backpack");
             Assert.That(product.GetCardBadge(),Is.EqualTo("1"));

        }

        public void RemoveFRomCart()
        {
             var login = new LoginPage(driver)
                        .LoginSuccess("standard_user","secret_sauce");
            var product = new ProductPage(driver);
            product.AddTocart("sauce-labs-backpack");
            product.RemoveFromCart("sauce-labs-backpack");
             Assert.That(product.GetCardBadge(),Is.EqualTo("0"));
        }

        [Test]
        public void RemoveItemTwice()
        {   var login = new LoginPage(driver); 
            login.LoginSuccess("standard_user","secret_sauce");
            var product = new ProductPage(driver);
            product.AddTocart("sauce-labs-backpack");
            product.RemoveFromCart("sauce-labs-backpack");
        }
        [Test]
        public void AddRemoveAdd()
        {   
            var product = new LoginPage(driver) 
                       .LoginSuccess("standard_user","secret_sauce");
            product.AddTocart("sauce-labs-backpack");
            product.RemoveFromCart("sauce-labs-backpack");
            product.AddTocart("sauce-labs-backpack");
        }
        [Test]
        public void AddMultipleProducts()
        { 
               var product = new LoginPage(driver) 
                .LoginSuccess("standard_user","secret_sauce");
                product.AddMultipleProducts(new string[]
            {
                "sauce-labs-backpack",
                "sauce-labs-bike-light",
                "sauce-labs-bolt-t-shirt"
            });
            Assert.That(product.GetCardBadge(),Is.EqualTo("3"));
        }

        [Test]
        public void RemoveMultipleProducts()
        {
            var product = new LoginPage(driver)
                          .LoginSuccess("standard_user","secret_sauce");  
                 product.AddMultipleProducts(new string[]
            {
                "sauce-labs-backpack",
                "sauce-labs-bike-light",
                "sauce-labs-bolt-t-shirt"
            });
            product.RemoveMultipleProducts(new string[]
            {
                "sauce-labs-backpack",
                "sauce-labs-bike-light",
                "sauce-labs-bolt-t-shirt"
            });
            Assert.That(product.GetCardBadge(),Is.EqualTo(string.Empty));
        }
    }
}
