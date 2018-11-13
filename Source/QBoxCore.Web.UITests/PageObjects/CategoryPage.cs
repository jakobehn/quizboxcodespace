using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace QBox.Web.UITests.PageObjects
{
    public class CategoryPage : SeleniumPage
    {
        public CategoryPage(IWebDriver driver) : base(driver)
        {
        }

        public QuestionPage SelectRandomCategory()
        {
            IWebElement query = GetElementWhenVisible(By.Id("randomcategory"));
            query.Click();

            return new QuestionPage(driver);
        }


        public QuestionPage SelectFirstCategory()
        {
            var category = GetElementWhenVisible(By.CssSelector(".btn-category"));
            category.Click();

            return new QuestionPage(driver);
        }

        public QuestionPage SelectCategory(string name)
        {
            var categories = GetElementsWhenVisible(By.CssSelector(".btn-category"));
            var selectedCategory = categories.FirstOrDefault(c => c.Text == name);
            selectedCategory.Click();

            return new QuestionPage(driver);
        }

    }
}
