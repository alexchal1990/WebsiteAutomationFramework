using NUnit.Framework;
using SeleniumProject.Pages;

namespace SeleniumProject.Tests
{    [TestFixture]
    [Category("E2E")]
public class E2ETest : BaseTest
{
    [Test]
    public void E2eTest()
    {
        // Login
        new LoginPage(driver).LoginSuccess("standard_user","secret_sauce");
        
        // Add product To cart
    
        var product = new ProductPage(driver);

        product.AddTocart("sauce-labs-backpack");

        // Navigate To CheckOut

          var checkout = product
                      .GoToCart()
                      .GoToCheckout();

          // Fill Checkout Form
        
          var overview = checkout
                        .FillCheckOutInfo("alex","chal","cv23dw")
                        .Continue();

          // Finish Order        
              
          var finish = overview.FinishOrder();

          // Retrieve Sucess message
          Assert.That(finish.GetSuccessHeader(),Is.EqualTo("Thank you for your order!"));
    
    }
}
}