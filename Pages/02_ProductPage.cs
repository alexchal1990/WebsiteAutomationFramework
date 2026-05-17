
using OpenQA.Selenium;
using SeleniumProject.utils;


namespace SeleniumProject.Pages
{
public class  ProductPage
{
    private readonly IWebDriver driver;
    public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
             //Ensure page is loaded
            WaitHelpers.WairForVisible(driver ,inventoryContainer);
        }
        //Locators
    private readonly By inventoryContainer = By.Id("inventory_container");
    private readonly By RemoveFromCartBtn = By.Id("remove-sauce-labs-backpack");
    private readonly By CartIcon = By.Id("shopping_cart_container");
    private readonly By CartBadge = By.Id("shopping_cart_container");

    //Add product to cart

    public void AddTocart(string productID)
        {
            var addBtn = By.Id($"add-to-cart-{productID}");
            driver.FindElement(addBtn).Click();
        }
        //Remove product from cart
    public void RemoveFromCart(string productID)
        {
            var RmvBtn = By.Id($"remove-{productID}");
            driver.FindElement(RemoveFromCartBtn).Click();
        }

    public string GetAddRemoveButtonText(string productID)
        {
            var btn = By.Id($"add-to-cart-{productID}");
            if(elementExists(btn))
                return driver.FindElement(btn).Text;

            var removeBtn = By.Id($"remo-{productID}");
            return driver.FindElement(removeBtn).Text;
        }

    public void AddMultipleProducts( String [] productIDs)
        {
            foreach (var id  in productIDs)
            {
                var addBtn = By.Id($"add-to-cart-{id}");
            if (elementExists(addBtn))
                {
                    driver.FindElement(addBtn).Click();
                }
            else
                {
                    continue;
                }
            }

        }
        public void RemoveMultipleProducts(String [] productIDs)
        {
            foreach (var  id in productIDs)
            {
                var rmvBtn = By.Id($"remove-{id}");
            if (elementExists(rmvBtn))
                {
                    driver.FindElement(rmvBtn).Click();
                }
            else
                {
                    continue;
                }
            }
        }

        private bool elementExists(By locator)
        {
            try
            {
            driver.FindElement(locator);
                return true;
            }
            catch
            {
                return false;
            }
        }
         public string GetCardBadge()
        {
            try
            {
                return driver.FindElement(CartBadge).Text;
            }
            catch
            {
                return "0";
            }
        }

        public CartPage GoToCart()
        {
            driver.FindElement(CartIcon).Click();
            return new CartPage(driver);
        }
}
}