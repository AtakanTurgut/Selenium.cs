using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebComponentTest.Entities;
using WebComponentTest.Pages.Impl;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace WebComponentTest
{
    public class GitHubWebComponentTest
    {
        private const string SearchPhrase = "selenium";

        private static IWebDriver driver;

        [OneTimeSetUp]
        public static void SetUpWebDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            /* Implicit Waits - Örtük Beklemeler */
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);      // Test Explorer - Test Detail Summary - Standard Output
        }

        [Test]
        public void CheckGitHubSearch()
        {
            driver.Navigate().GoToUrl("https://github.com/");

            /* Page Object - Sayfa Nesnesi */
            var homePage = new HomePage(driver);
            homePage.SearchComponent.PerformSearch(SearchPhrase);

            var searchResultsPage = new SearchResultsPage(driver);

            /* NUnit Assertions */  /* DTO */
            IList<SearchResultItem> actualItems = searchResultsPage.SearchResultsItemsText();                       // IList<string>

            IList<SearchResultItem> expectedItems = actualItems                                                     // IList<string>
                                                 // searchResultsPage.SearchResultsItemsText() -> Error:: Assert.That(expectedItems, Is.EqualTo(actualItems)) Values differ at index [0]
                                                 // SearchResultItem --> Generate Equals and GetHashCode... solved the error.
                .Where(item => item.Title.Contains(SearchPhrase) || item.Description.Contains(SearchPhrase))        // item.Contains(SearchPhrase)
                .ToList();

            Assert.That(expectedItems, Is.EqualTo(actualItems));    // 10
        }


        [OneTimeTearDown]
        public static void TearDownWebDriver()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
