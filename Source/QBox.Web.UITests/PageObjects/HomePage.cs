using OpenQA.Selenium;

namespace QBox.Web.UITests
{
    public class HomePage : SeleniumPage
    {
        private string baseURL;

        public HomePage(IWebDriver driver)
            : base(driver)
        {
        }

        public void GoToHome(string url)
        {
            baseURL = url;
            driver.Navigate().GoToUrl(baseURL);
        }

        public QuestionPage StartNewGame()
        {
            IWebElement query = GetElementWhenVisible(By.Id("startGame"));
            query.Click();

            return new QuestionPage(driver);
        }
    }


}