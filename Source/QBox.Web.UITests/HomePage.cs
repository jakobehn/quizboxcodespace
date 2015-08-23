using OpenQA.Selenium;

namespace QBox.Web.UITests
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        private string baseURL;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToHome()
        {
            baseURL = Properties.Settings.Default.StartURL;
            driver.Navigate().GoToUrl(baseURL);
        }

        public QuestionPage StartNewGame()
        {
            IWebElement query = driver.FindElement(By.Id("startGame"));
            query.Click();

            return new QuestionPage(driver);
        }
    }
}