

using OpenQA.Selenium;
using SeleniumProject.utils;

namespace SeleniumProject.Pages
{
    public class CartPage
    {
        private readonly IWebDriver driver;
        //Locators
        private readonly By cartItem = By.ClassName("title");
        private readonly By prodname = By.ClassName("inventory_item_name");
        private readonly By Checkoutbtn = By.Id("checkout");
        
        private readonly By continueShopping = By.Id("continue-shopping");

        public CartPage (IWebDriver driver)
        {
            this.driver = driver;
             //Ensure page is loaded
            WaitHelpers.WairForVisible(driver , cartItem);
        }

        public bool GetProductName()
        {
            driver.FindElement(prodname).Click();

            return true;

          }
        
        public void RemoveItem(string productID)
        {
            var removebtn = By.Id($"remove-{productID}");
            driver.FindElement(removebtn).Click();
        }


        public ProductPage ContinueShopping()
        {
            driver.FindElement(continueShopping).Click();
            return new ProductPage(driver);
        }


        public CheckOutPage GoToCheckout()
        {
            driver.FindElement(Checkoutbtn).Click();
            return new CheckOutPage(driver);
        }

        public bool IsPageLoaded()
        {
            return driver.Url.Contains("cart");
        }

        public bool IsCartEmpty()
        {
            var items = driver.FindElements(By.ClassName("cart_item"));
            return  items.Count == 0;
        }
    }

}