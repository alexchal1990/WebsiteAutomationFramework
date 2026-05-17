
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using SeleniumProject.Drivers;

namespace SeleniumProject.Tests
{
    [TestFixture]
    public  class BaseTest
    {
         protected IWebDriver driver;
       
        [SetUp]
         public void Setup()
        {
            driver = WebDriverFactory.CreateChromeDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");            
        }
          [TearDown]
        public void TearDown()
        {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                //create folder if doesnt exist
                var folder = Path.Combine(AppContext.BaseDirectory,"..","..","..","Screenshots");
                Directory.CreateDirectory(folder);

               //create filename 
               var filename =Path.Combine (folder,$"{TestContext.CurrentContext.Test.Name}.png");

               //Take screenshot
               var screenshot = driver.TakeScreenshot();
                screenshot.SaveAsFile(filename);

            }
                driver.Quit();
            }
            
        }
    }
