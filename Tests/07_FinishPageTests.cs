using NUnit.Framework;
using SeleniumProject.Pages;

namespace SeleniumProject.Tests
{
     [TestFixture]
    [Category("Finish")]
    public class FinishPageTests : BaseTest
    {
        [Test]
        public void ValidateSuccessMessage()
        {
            new LoginPage(driver).LoginSuccess("standard_user","secret_sauce");

            var product = new ProductPage(driver);
                        product.AddTocart("sauce-labs-backpack");
            var finish = product
                        .GoToCart()
                        .GoToCheckout()
                        .FillCheckOutInfo("alex","chal","cv23dw")
                        .Continue()
                        .FinishOrder();
            Assert.That(finish.GetSuccessHeader(),Is.EqualTo("Thank you for your order!"));                
        }

        

        [Test]
        public void BackHomeButtonNavigation()
        {
            new LoginPage(driver).LoginSuccess("standard_user","secret_sauce");

            var product = new ProductPage(driver);
                        product.AddTocart("sauce-labs-backpack");
            var finish = product
                        .GoToCart()
                        .GoToCheckout()
                        .FillCheckOutInfo("alex","chal","cv23dw")
                        .Continue()
                        .FinishOrder()
                        .BackHome();
            Assert.That(driver.Url,Does.Contain("inventory.html"));
        }
        
    }
}