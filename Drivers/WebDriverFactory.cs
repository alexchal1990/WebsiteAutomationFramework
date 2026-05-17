using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace SeleniumProject.Drivers
{
    public static  class WebDriverFactory
    {

        public static IWebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddUserProfilePreference("credentials_enable_service",false);
            options.AddUserProfilePreference("autofill.password_manager_enabled",false);
            options.AddUserProfilePreference("profile.password_manager_enabled",false);
            options.AddUserProfilePreference("profile.password_manager_leak_detection",false);
            options.AddArgument("--disable-save-password-bubble");
            options.BinaryLocation="/usr/bin/google-chrome";
            
            return new ChromeDriver(options);
        }

    }

    
}