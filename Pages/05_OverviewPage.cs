
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumProject.utils;

namespace SeleniumProject.Pages
{
    public class OverviewPage
    {
        private readonly IWebDriver driver;

        private readonly By ItemCont = By.Id("checkout_summary_container");
        public OverviewPage(IWebDriver driver)
        {
            this.driver = driver;
             //Ensure page is loaded
            WaitHelpers.WairForVisible(driver,ItemCont);
        }
        //Locators
        private readonly By finishbtn = By.Id("finish");
         private readonly By productName = By.ClassName("inventory_item_name");

         private readonly By itemprice = By.ClassName("inventory_item_price");
        
        private readonly By paymentinfo = By.ClassName("summary_value_label");
        
        private readonly By shippinginfo = By.ClassName("summary_value_label");

        private readonly By taxinfo = By.ClassName("summary_tax_label");

        private readonly By total = By.ClassName("summary_total_label");


        public string GetProductname()
        {
            return driver.FindElement(productName).Text;
            
        }

        public string GetItemPrice()
        {
            return driver.FindElement(itemprice).Text;
        }

        public string GetPaymentinfo()
        {
            return driver.FindElement(paymentinfo).Text;
        }
        
        public string GetShippingInfo()
        {
            return driver.FindElement(shippinginfo).Text;
        }

        public string GetTax()
        {
            return driver.FindElement(taxinfo).Text;
        }

        public string GetTotal()
        {
            return driver.FindElement(total).Text;
        }


        public FinishPage FinishOrder()
        {
            driver.FindElement(finishbtn).Click();
            return new FinishPage(driver);
        }
    }
}