using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace NUnitSeleniumTest
{
    public class GitHubTest
    {
        private const string SearchPhrase = "selenium";

        private static IWebDriver driver;

        [OneTimeSetUp]
        public static void SetUpWebDriver() 
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
        }

        [Test]
        public void CheckGitHubSearch()
        {
            driver.Navigate().GoToUrl("https://github.com/");

            IWebElement searchBox = driver.FindElement(By.CssSelector(".search-input"));    // class
            searchBox.Click();

            IWebElement searchInput = driver.FindElement(By.CssSelector("#query-builder-test"));    // id
            searchInput.SendKeys(SearchPhrase);
            searchInput.SendKeys(Keys.Enter);

            /* NUnit Assertions */
            var actualItems = driver.FindElements(By.CssSelector("[data-testid='results-list'] > div"))     // IList<string> actualItems
                .Select(item => item.Text.ToLower())
                .ToList();

            var expectedItems = actualItems     // IList<string> expectedItems
                .Where(item => item.Contains(SearchPhrase))     // "invalid" test AssertionException
                .ToList();

            Assert.That(expectedItems, Is.EqualTo(actualItems));
        }

        [OneTimeTearDown]
        public static void TearDownWebDriver()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
