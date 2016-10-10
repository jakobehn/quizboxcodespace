using OpenQA.Selenium;

namespace QBox.Web.UITests
{
    public abstract class SeleniumPage
    {
        protected IWebDriver driver { get; }

        public SeleniumPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
