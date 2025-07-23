using OpenQA.Selenium;

namespace WebComponentTest.Components.Impl
{
    public class SearchComponent(IWebElement rootElement) : WebComponent(rootElement)   // Use Primary Constructor     /* SearchComponent() */
    {
        /*
        private readonly IWebElement rootElement;

        public SearchComponent(IWebElement rootElement)
        {
            this.rootElement = rootElement;
        }

        private IWebElement FindElement(By selector) => rootElement.FindElement(selector);
        */

        // Lazy Initialization - Tembel İlklendirme
        private IWebElement SearchInput => FindElement(By.CssSelector("#query-builder-test"));

        /* private void Click() => rootElement.Click(); */

        public void PerformSearch(string searchPhrase)
        {
            Click();

            SearchInput.SendKeys(searchPhrase);
            SearchInput.SendKeys(Keys.Enter);
        }
    }
}
