using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;

using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace QBox.Web.UITests
{
    [TestClass]
    [DeploymentItem("chromedriver.exe")]
    [DeploymentItem("IEDriverServer.exe")]
    public class QuestionTests
    {
        public QuestionTests()
        {
        }

        [TestMethod]
        //[Ignore]
        public void StartGameAnswerAllQuestionsAndPostAnswer()
        {
            var url = TestContext.Properties["webAppUrl"].ToString();
            foreach (var driver in Drivers())
            {
                driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 10));

                var homePage = new HomePage(driver);
                homePage.GoToHome(url);
                var questionPage = homePage.StartNewGame();
                questionPage.SelectFirstCategory();
                questionPage.AnswerFirstQuestion();
                homePage = questionPage.PostHighScore("Test Name");
                driver.Quit();
            }
        }

        [TestMethod]
        //[Ignore]
        public void LoginUserAndSelectNewQuiz()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }

        #region Additional test attributes


        // You can use the following additional attributes as you write your tests:
        private IEnumerable<IWebDriver> drivers;
        //private string baseURL;

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {


        }

        private IEnumerable<IWebDriver> Drivers()
        {
            return new List<IWebDriver>
            {
                new ChromeDriver(),
                new FirefoxDriver(),
                new InternetExplorerDriver()
            };
        }

        ////Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            try
            {
                //foreach (var driver in drivers)
                //{
                //    driver.Quit();
                //}
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
