using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;

namespace QBox.Web.UITests
{
    [TestClass]
    [DeploymentItem("chromedriver.exe")]
    [DeploymentItem("IEDriverServer.exe")]
    public class QuestionTests
    {
        private IWebDriver driver;

        public QuestionTests()
        {
        }

        [TestMethod]
        public void StartGameAnswerAllQuestionsAndPostAnswer()
        {
            var url = TestContext.Properties["webAppUrl"].ToString();

            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 10));

            var homePage = new HomePage(driver);
            homePage.GoToHome(url);
            var questionPage = homePage.StartNewGame();
            questionPage.SelectFirstCategory();
            questionPage.AnswerFirstQuestion();
            homePage = questionPage.PostHighScore("Test Name");
            driver.Quit();

        }

        [TestMethod]
        public void LoginUserAndSelectNewQuiz()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void LoginUserWithInvalidCredentials()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void LoginUser()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ViewHighScore()
        {
            Assert.IsTrue(true);
        }


        #region Additional test attributes


        // You can use the following additional attributes as you write your tests:
        private IEnumerable<IWebDriver> drivers;
        //private string baseURL;

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            var browserType= TestContext.Properties["browserType"].ToString();
            switch (browserType)
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "ie":
                    driver = new InternetExplorerDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    throw new ArgumentException("Invalid browserType: " + browserType);

            }

        }

        ////Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            try
            {
                if (driver != null)
                    driver.Close();
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
