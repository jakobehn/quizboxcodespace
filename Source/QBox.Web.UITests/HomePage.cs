using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

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

        public void GoToHome(string url)
        {
            baseURL = url;
            driver.Navigate().GoToUrl(baseURL);
        }

        public QuestionPage StartNewGame()
        {
            IWebElement query = driver.FindElement(By.Id("startGame"));
            query.Click();

            return new QuestionPage(driver);
        }
    }

    public class HighScorePage
    {
        private readonly IWebDriver driver;

        public HighScorePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IEnumerable<string> GetHighScoreList()
        {
            var highScores = driver.FindElements(By.ClassName("user"));
            return highScores.Select(hs => hs.Text);
        }
    }
}