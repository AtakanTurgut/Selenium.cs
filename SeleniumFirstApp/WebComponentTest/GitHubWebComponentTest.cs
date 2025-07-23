using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

            /* NUnit Assertions */
            IList<string> actualItems = searchResultsPage.SearchResultsItemsText();

            IList<string> expectedItems = actualItems
                .Where(item => item.Contains(SearchPhrase))   
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
