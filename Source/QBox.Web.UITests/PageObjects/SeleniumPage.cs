using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace QBox.Web.UITests
{
    public abstract class SeleniumPage
    {
        protected IWebDriver driver { get; }

        public SeleniumPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected ReadOnlyCollection<IWebElement> GetElementsWhenVisible(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));

            return driver.FindElements(by);
        }

        protected IWebElement GetElementWhenVisible(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(ExpectedConditions.ElementIsVisible(by));

            return driver.FindElement(by);
        }
    }
}
