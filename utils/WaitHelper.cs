using Microsoft.VisualBasic;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using OpenQA.Selenium.Support.UI;

namespace SeleniumProject.utils
{
    public static class WaitHelpers
    {
         public static IWebElement WairForVisible(IWebDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
            IWebElement element = wait.Until(delegate (IWebDriver d)
            {
                IWebElement el = d.FindElement(locator);

                if(el.Displayed)

                {
                    return el;
                }
                else
                {
                    return null;
                }
            });

            return element;
        }
    }
}