using OpenQA.Selenium;
using SeleniumProject.utils;

namespace SeleniumProject.Pages
{
    public class FinishPage
    {
        private readonly  IWebDriver driver;
    
        //Locators

         private readonly By Sucessheader  = By.ClassName("complete-header");
         private readonly By backHomeBtn  = By.Id("back-to-products");
        private readonly By header = By.ClassName("complete-header");

        public FinishPage(IWebDriver driver)
        {
            this.driver = driver;
             //Ensure page is loaded
            WaitHelpers.WairForVisible(driver,Sucessheader);
        }

        public String GetSuccessHeader()
        {
            return driver.FindElement(Sucessheader).Text;
        }
      
        public ProductPage BackHome()
        {
            driver.FindElement(backHomeBtn).Click();
            return new ProductPage(driver);
        }
       
    }
}
