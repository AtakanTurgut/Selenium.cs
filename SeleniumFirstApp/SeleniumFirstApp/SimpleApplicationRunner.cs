using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumFirstApp
{
    public class SimpleApplicationRunner
    {
        public static void Main(string[] args)
        {
            string searchPhrase = "selenium";

            new DriverManager().SetUpDriver(new ChromeConfig());

            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();  // Windows Full Screen

            driver.Navigate().GoToUrl("https://github.com/");

            IWebElement searchBox = driver.FindElement(By.CssSelector(".search-input"));    // class
            searchBox.Click();

            IWebElement searchInput = driver.FindElement(By.CssSelector("#query-builder-test"));    // id
            searchInput.SendKeys(searchPhrase);
            searchInput.SendKeys(Keys.Enter);

            /* NUnit Assertions */
            IList<string> actualItems = driver.FindElements(By.CssSelector("[data-testid='results-list'] > div"))
                .Select(item => item.Text.ToLower())
                .ToList();

            IList<string> expectedItems = actualItems
                .Where(item => item.Contains(searchPhrase))     // "invalid" test AssertionException
                .ToList();

            Assert.That(expectedItems, Is.EqualTo(actualItems));

            //driver.Quit();
        }
    }
}
