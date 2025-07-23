using OpenQA.Selenium;

namespace NUnitSeleniumTest.Pages.Impl
{
    public class HomePage(IWebDriver driver) : WebPage(driver)  // Use Primary Constructor      /* HomePage() */
    {
        /* private readonly IWebDriver driver; */

        // Lazy Initialization - Tembel İlklendirme     /* : WebPage(driver) */
        private IWebElement SearchBox => FindElement(By.CssSelector(".search-input")); /* driver.FindElement(By.CssSelector(".search-input")); */                   // class
        private IWebElement SearchInput => FindElement(By.CssSelector("#query-builder-test")); /* driver.FindElement(By.CssSelector("#query-builder-test")); */     // id

        /*
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        */

        public void PerformSearch(string searchPhrase)
        {
            SearchBox.Click();

            SearchInput.SendKeys(searchPhrase);
            SearchInput.SendKeys(Keys.Enter);
        }
    }
}
