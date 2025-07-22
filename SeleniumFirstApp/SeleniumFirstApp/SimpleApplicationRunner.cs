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
            var actualItems = driver.FindElements(By.CssSelector("[data-testid='results-list'] > div"))     // IList<string> actualItems
                .Select(item => item.Text.ToLower())
                .ToList();

            var expectedItems = actualItems     // IList<string> expectedItems
                .Where(item => item.Contains(searchPhrase))     // "invalid" test AssertionException
                .ToList();

            Assert.That(expectedItems, Is.EqualTo(actualItems));

            //driver.Quit();
        }
    }
}
