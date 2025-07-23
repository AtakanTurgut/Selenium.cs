using OpenQA.Selenium;
using WebComponentTest.Entities;

namespace WebComponentTest.Components.Impl
{
    public class SearchResultItemComponent(IWebElement rootElement) : WebComponent(rootElement)     // Use Primary Constructor     /* SearchResultItemComponent() */
    {
        private static readonly By TitleSelector = By.CssSelector(".search-title");
        private static readonly By DescriptionSelector = By.XPath(".//h3/following-sibling::*/*[contains(@class, 'search-match')]");

        /* DTO */
        public SearchResultItem ConvertToSearchResultItem() =>
            new SearchResultItem(
                    RetrieveTitleText(), RetrieveDescriptionText()
                );

        private string RetrieveTitleText()
        {
            return FindElement(TitleSelector).Text.ToLower();
        }

        private string RetrieveDescriptionText()
        {
            return FindElement(DescriptionSelector).Text.ToLower();
        }
    }
}
