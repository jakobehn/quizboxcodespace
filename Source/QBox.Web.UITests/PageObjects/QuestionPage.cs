using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace QBox.Web.UITests
{
    public class QuestionPage : SeleniumPage
    {

        public QuestionPage(IWebDriver driver)
            :base(driver)
        {
        }

        public void SelectFirstCategory()
        {
            var category = GetElementWhenVisible(By.CssSelector(".btn-category"));
            category.Click();
        }

        public void AnswerFirstQuestion()
        {
            var query = GetElementsWhenVisible(By.CssSelector(".quiz-radio"))[1];
            query.Click();

            query = GetElementWhenVisible(By.CssSelector(".btn-answer"));
            query.Click();
        }

        public HighScorePage PostHighScore(string userName)
        {
            var query = GetElementWhenVisible(By.Id("name"));
            query.SendKeys(userName);

            query = GetElementWhenVisible(By.Id("postScore"));
            query.Click();

            return new HighScorePage(driver);
        }
    }


}