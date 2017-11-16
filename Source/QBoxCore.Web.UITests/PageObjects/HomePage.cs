using System;
using OpenQA.Selenium;

namespace QBox.Web.UITests.PageObjects
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

        public CategoryPage StartNewGame()
        {
            IWebElement query = GetElementWhenVisible(By.Id("startGame"));
            query.Click();

            return new CategoryPage(driver);
        }

        internal HighScorePage GoToHighscorePage()
        {
            IWebElement query = GetElementWhenVisible(By.Id("highscore"));
            query.Click();

            return new HighScorePage(driver);
        }
    }


}