using System.Linq;
using OpenQA.Selenium;

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
            var elements = driver.FindElements(By.CssSelector(".btn-category"));
            var query = elements.First();
            query.Click();
        }

        public void AnswerFirstQuestion()
        {
            var elements = driver.FindElements(By.CssSelector(".quiz-radio"));
            foreach( var el in elements)
            {
                System.Console.WriteLine(el.TagName + el.Text);
            }
            var query = driver.FindElements(By.CssSelector(".quiz-radio"))[1];
            query.Click();

            query = driver.FindElements(By.CssSelector(".btn-answer")).First();
            query.Click();
        }

        public HighScorePage PostHighScore(string userName)
        {
            var query = driver.FindElements(By.Id("name")).First();
            query.SendKeys(userName);

            query = driver.FindElements(By.Id("postScore")).First();
            query.Click();

            return new HighScorePage(driver);
        }
    }


}