
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumProject.Pages;

namespace SeleniumProject.Tests
{
    [TestFixture]
    [Category("Checkout")]

    public class CheckOutTests : BaseTest
    {   
        private readonly By errmsg = By.XPath("//h3['data-test=(error)']");
        [Test]
        public void EmptyFirstName()
        {
           new LoginPage(driver).LoginSuccess("standard_user","secret_sauce");
              
              var  product =  new ProductPage(driver);
                    product.AddTocart("sauce-labs-backpack");
              
                var checkout = product.GoToCart().GoToCheckout();
             checkout.FillCheckOutInfo("","chal","cv23dw");
              checkout.Clickcontinue();
            String msg = driver.FindElement(errmsg).Text;
            Assert.That(msg,Is.EqualTo("Error: First Name is required"));
        }
        [Test]
        public void EmptyLastName()
        {
             new LoginPage(driver).LoginSuccess("standard_user","secret_sauce");
              
              var  product =  new ProductPage(driver);
                    product.AddTocart("sauce-labs-backpack");
              
                var checkout = product.GoToCart().GoToCheckout();
             checkout.FillCheckOutInfo("alex","","cv23dw");
             checkout.Clickcontinue();
            String msg = driver.FindElement(errmsg).Text;
            Assert.That(msg,Is.EqualTo("Error: Last Name is required"));
        }
        [Test]
        public void EmptyZipcodeField()
        {   
            new LoginPage(driver).LoginSuccess("standard_user","secret_sauce");
              
              var  product =  new ProductPage(driver);
                    product.AddTocart("sauce-labs-backpack");
              
                var checkout = product.GoToCart().GoToCheckout();
            checkout.FillCheckOutInfo("alex","chal","");
             checkout.Clickcontinue();
            String msg = driver.FindElement(errmsg).Text;
            Assert.That(msg,Is.EqualTo("Error: Postal Code is required"));
        }
        [Test]
        public void ValidCheckOut_GoesToOverview()
        {
           
           new LoginPage(driver).LoginSuccess("standard_user","secret_sauce");
              
              var  product =  new ProductPage(driver);
                    product.AddTocart("sauce-labs-backpack");
              
                var checkout = product.GoToCart().GoToCheckout();
             checkout.FillCheckOutInfo("alex","chal","cv23dw");
             checkout.Continue();

             Assert.That(driver.Url,Does.Contain("checkout-step-two.html"));

        }
    }
}
        
        
        
        