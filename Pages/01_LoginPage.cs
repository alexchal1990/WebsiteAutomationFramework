using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using SeleniumProject.utils;

namespace SeleniumProject.Pages
{
     public class LoginPage
    {
     
        //Locators
        private readonly By username = By.Id("user-name");
        private readonly By password = By.Id("password");  
        private  readonly By lgnbtn = By.Id("login-button");

        private readonly By errorMessageLocator = By.XPath("//h3[@data-test=('error')]");
        

        private readonly IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        //Succesfull login
        public ProductPage LoginSuccess(String user,String pass)
        {
            driver.FindElement(username).SendKeys(user);
            driver.FindElement(password).SendKeys(pass);
            driver.FindElement(lgnbtn).Click();
            return new ProductPage(driver);
        }
        public LoginPage LoginFail(String user , String pass)
        {
            driver.FindElement(username).SendKeys(user);
            driver.FindElement(password).SendKeys(pass);
            driver.FindElement(lgnbtn).Click();

            return this;
        }
        // Return error message
        public String GetErrorMessage()
        {
            IWebElement error = WaitHelpers.WairForVisible(driver , errorMessageLocator);
            return error.Text;
        }

    }
}