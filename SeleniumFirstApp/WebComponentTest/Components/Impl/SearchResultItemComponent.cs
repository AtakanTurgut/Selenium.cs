using OpenQA.Selenium;

namespace WebComponentTest.Components.Impl
{
    public class SearchResultItemComponent(IWebElement rootElement) : WebComponent(rootElement)     // Use Primary Constructor     /* SearchResultItemComponent() */
    {
        private static readonly By TitleSelector = By.CssSelector(".search-title");
        private static readonly By DescriptionSelector = By.XPath(".//h3/following-sibling::*/*[contains(@class, 'search-match')]");

        private string RetrieveTitleText()
        {
            return FindElement(TitleSelector).Text;
        }

        private string RetrieveDescriptionText()
        {
            return FindElement(DescriptionSelector).Text;
        }
    }
}
