using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace NUnitSeleniumTest
{
    public class GitHubTest
    {
        private const string SearchPhrase = "selenium";

        private static IWebDriver driver;

        /* Explicit Waits - Açık Beklemeler */
        private static WebDriverWait wait;

        [OneTimeSetUp]
        public static void SetUpWebDriver() 
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            /* Implicit Waits - Örtük Beklemeler */
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);      // Test Explorer - Test Detail Summary - Standard Output

            /* Explicit Waits - Açık Beklemeler */
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

            // Açık Beklemelere başvurmadan önce Örtük Beklemeleri kapatmayı unutmayın!
            // Don't forget to turn off Implicit Waits before resorting to Explicit Waits!
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

            /* Implicit Waits - Örtük Beklemeler */
            Console.WriteLine(DateTime.Now);
            try
            {
                //driver.FindElement(By.CssSelector("#invalid")); // test NoSuchElementException    // not found id - wait 5 sec
                driver.FindElement(By.CssSelector("[data-testid='results-list'] > div"));
            }
            finally
            {
                Console.WriteLine(DateTime.Now);
            }

            /* Explicit Waits - Açık Beklemeler */
            WaitForElementVisibility(By.CssSelector("[data-testid='results-list'] > div"));     // "#invalid" test NoSuchElementException

            /* NUnit Assertions */
            var actualItems = driver.FindElements(By.CssSelector("[data-testid='results-list'] > div"))     // IList<string> actualItems
                .Select(item => item.Text.ToLower())
                .ToList();

            var expectedItems = actualItems                                                                 // IList<string> expectedItems
                .Where(item => item.Contains(SearchPhrase))     // "invalid" test AssertionException
                .ToList();

            Assert.That(expectedItems, Is.EqualTo(actualItems));
        }

        /* Explicit Waits - Açık Beklemeler */
        private void WaitForElementVisibility(By selector)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            wait.Until(d => driver.FindElement(selector));   // .Displayed);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [OneTimeTearDown]
        public static void TearDownWebDriver()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
