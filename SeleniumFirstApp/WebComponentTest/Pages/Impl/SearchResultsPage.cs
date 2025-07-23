using OpenQA.Selenium;
using WebComponentTest.Components.Impl;

namespace WebComponentTest.Pages.Impl
{
    public class SearchResultsPage(IWebDriver driver) : WebPage(driver)  // Use Primary Constructor    
    {
        private static readonly By SearchResultsItemsCss =
            By.CssSelector("[data-testid='results-list'] > div");

        /* NUnit Assertions */
        private IList<SearchResultItemComponent> SearchResultsItems => FindElements(SearchResultsItemsCss)  // IList<IWebElement>
            .Select(element => new SearchResultItemComponent(element))
            .ToList();   

        public IList<string> SearchResultsItemsText()
        {
            /* Explicit Waits - Açık Beklemeler */
            WaitForElementVisibility(SearchResultsItemsCss);

            /* NUnit Assertions */
            return SearchResultsItems
                .Select(item => item.Text.ToLower())
                .ToList();
        }
    
    }
}


