using OpenQA.Selenium;

namespace NUnitSeleniumTest.Pages.Impl
{
    public class SearchResultsPage(IWebDriver driver) : WebPage(driver)  // Use Primary Constructor     /* SearchResultsPage() */
    {
        private static readonly By SearchResultsItemsCss =
            By.CssSelector("[data-testid='results-list'] > div");

        /*
        private readonly IWebDriver driver;

        * Explicit Waits - Açık Beklemeler *
        private readonly WebDriverWait wait; 
        */

        /* NUnit Assertions */  /* : WebPage(driver) */
        private IList<IWebElement> SearchResultsItems => FindElements(SearchResultsItemsCss); /* driver.FindElements(SearchResultsItemsCss); */

        /*
        public SearchResultsPage(IWebDriver driver)
        {
            this.driver = driver;

            * Explicit Waits - Açık Beklemeler *
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
        }
        */

        public IList<string> SearchResultsItemsText()
        {
            /* Explicit Waits - Açık Beklemeler */
            WaitForElementVisibility(SearchResultsItemsCss);

            /* NUnit Assertions */
            return SearchResultsItems
                .Select(item => item.Text.ToLower())
                .ToList();
        }

        /*
        * Explicit Waits - Açık Beklemeler *
        private void WaitForElementVisibility(By selector)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            wait.Until(d => driver.FindElement(selector));   // .Displayed);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        */
    }
}


