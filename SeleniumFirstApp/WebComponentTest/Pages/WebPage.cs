using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace WebComponentTest.Pages
{
    public class WebPage
    {
        private readonly IWebDriver driver;

        /* Explicit Waits - Açık Beklemeler */
        private readonly WebDriverWait wait;

        public WebPage(IWebDriver driver)
        {
            this.driver = driver;

            /* Explicit Waits - Açık Beklemeler */
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
        }

        protected IWebElement FindElement(By selector) => driver.FindElement(selector);
        protected IList<IWebElement> FindElements(By selector) => driver.FindElements(selector);

        /* Explicit Waits - Açık Beklemeler */
        protected void WaitForElementVisibility(By selector)      
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            wait.Until(d => driver.FindElement(selector));   
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
    }
}
