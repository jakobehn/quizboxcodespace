using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace QBox.Web.UITests
{
    public class HighScorePage : SeleniumPage
    {
        public HighScorePage(IWebDriver driver)
            : base(driver)
        {
        }

        public IEnumerable<string> GetHighScoreList()
        {
            var highScores = GetElementsWhenVisible(By.ClassName("user"));
            return highScores.Select(hs => hs.Text);
        }
    }
}
