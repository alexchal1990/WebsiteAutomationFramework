
using NUnit.Framework;
using SeleniumProject.Pages;

namespace SeleniumProject.Tests
{
    [TestFixture]
    [Category("Login")]
    public class LogInTests : BaseTest
    {
        

        [Test]
        //user is locked out//
        public void LockedOutUser()
        {
            var login = new LoginPage(driver); 
            login.LoginFail("locked_out_user","secret_sauce");
            String msg = login.GetErrorMessage();
            Assert.That(msg, Is.EqualTo("Epic sadface: Sorry, this user has been locked out.")); 

        }

          [Test]
        //Error user is expected to login succesfully.
        //This test exist to show that the screenshot and teardown logic function works correctly
        public void ErrorUser()
        {
             var login = new LoginPage(driver) 
            .LoginFail("locked_out_user","secret_sauce");  
            String msg = login.GetErrorMessage();
            Assert.That(msg, Is.EqualTo("Epic sadface:"));
        }

        [Test]
        public void EmptyPasswordField()
        {
            var login = new LoginPage(driver); 
            login.LoginFail("error_user","");  
            String msg = login.GetErrorMessage();
            Assert.That(msg, Is.EqualTo("Epic sadface: Password is required")); 
        }
        [Test]
        public void EmptyUsername()
        {
            var login = new LoginPage(driver); 
            login.LoginFail("","secret_sauce");  
            String msg = login.GetErrorMessage();
            Assert.That(msg, Is.EqualTo("Epic sadface: Username is required")); 
        }
        [Test]
        public void SQLInjection()
        {
            var login = new LoginPage(driver); 
            login.LoginFail("' OR '1'='1","secret_sauce");  
             String msg = login.GetErrorMessage();
            Assert.That(msg, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
        } 
            
        [Test]
        public void XSSAttempit()
        {
             var login = new LoginPage(driver);
             login.LoginFail("<script>alert('XSS')</script>","secret_sauce");  
             String msg = login.GetErrorMessage();
            Assert.That(msg, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
        }

        [Test]
        //User is correct//
        public void LoginSuccess_ShouldNavigateToProductPage()
        {
            var login = new LoginPage(driver); 
            login.LoginSuccess("standard_user","secret_sauce");
        }
    }
}


