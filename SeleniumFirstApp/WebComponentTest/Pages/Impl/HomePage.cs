using OpenQA.Selenium;
using WebComponentTest.Components.Impl;

namespace WebComponentTest.Pages.Impl
{
    public class HomePage(IWebDriver driver) : WebPage(driver)  // Use Primary Constructor
    {
        private static readonly By SearchInputCss = By.CssSelector(".search-input");

        public SearchComponent SearchComponent => new SearchComponent(FindElement(SearchInputCss));   
    }
}
