using OpenQA.Selenium;

namespace WebComponentTest.Components
{
    public class WebComponent
    {
        private readonly IWebElement rootElement;

        public WebComponent(IWebElement rootElement)
        {
            this.rootElement = rootElement;
        }

        protected IWebElement FindElement(By selector) => rootElement.FindElement(selector);  // private

        protected void Click() => rootElement.Click();    // private

        public string Text => rootElement.Text;
    }
}
