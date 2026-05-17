
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V145.Browser;
using SeleniumProject.utils;

namespace SeleniumProject.Pages
{
    public class CheckOutPage
    {
        private readonly IWebDriver driver;
        public  CheckOutPage(IWebDriver driver)
        {
            this.driver = driver;
            //Ensure page is loaded
            WaitHelpers.WairForVisible(driver , FirstName);

        }

        //Locators
        private readonly By FirstName = By.Id("first-name");
        private readonly By LastName = By.Id("last-name");
        private readonly By PostalCode = By.Id("postal-code");
        private readonly By ContBtn = By.Id("continue");

        private readonly By errorMessage = By.CssSelector("h3[data-test=('error')]");

        public CheckOutPage FillCheckOutInfo(String first ,String last, String zip)
        {
            driver.FindElement(FirstName).SendKeys(first);
            driver.FindElement(LastName).SendKeys(last);
            driver.FindElement(PostalCode).SendKeys(zip);
            return this;
        }

        // Function for catching error message after clicking continue ,checking emty fields test cases 
        public void Clickcontinue()
        {
            driver.FindElement(ContBtn).Click();
        }
              
        public  OverviewPage Continue()
        {
             driver.FindElement(ContBtn).Click();
            return new OverviewPage(driver);
        }
        public string GetError()
        {
           var errors = driver.FindElements(errorMessage);

           if (errors.Count ==0)
                return "";

            return errors[0].Text;    
        }

        
      
    }
}