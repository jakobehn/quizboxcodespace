using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace QBox.Web.UITests.PageObjects
{
    public class QuestionPage : SeleniumPage
    {

        public QuestionPage(IWebDriver driver)
            :base(driver)
        {
        }

        public string Category
        {
            get
            {
                return GetElementWhenVisible(By.Id("questioncategory")).Text;
            }
        }
        public QuestionPage AnswerFirstQuestion()
        {
            var query = GetElementsWhenVisible(By.CssSelector(".quiz-radio"))[1];
            query.Click();

            return ClickNext();
        }

        public QuestionPage Answer(string answer)
        {
            var labels = GetElementsWhenVisible(By.CssSelector(".quiz-radio-container"));
            foreach(var label in labels)
            {
                var answerRadioButton = label.FindElement(By.CssSelector(".quiz-radio"));
                var answerLabel = label.FindElement(By.CssSelector(".quiz-radio-label"));
                if( answerLabel.Text == answer)
                {
                    answerRadioButton.Click();
                    return ClickNext();
                }
            }
            return null;
        }

        private QuestionPage ClickNext()
        {
            var query = GetElementWhenVisible(By.CssSelector(".btn-answer"));
            query.Click();

            return new QuestionPage(driver);
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