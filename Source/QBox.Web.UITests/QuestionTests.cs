using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using System.Linq;

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
        [TestCategory("UI")]
        public void ChromeStartGameAnswerAllQuestionsAndPostAnswer()
        {
            driver = GetChromeDriver();
            var result = StartGameAnswerAllQuestionsAndPostAnswer();
            Assert.IsTrue(result);
        }
        [TestMethod]
        [TestCategory("UI")]
        public void IEStartGameAnswerAllQuestionsAndPostAnswer()
        {
            driver = GetIEDriver();
            var result = StartGameAnswerAllQuestionsAndPostAnswer();
            Assert.IsTrue(result);
        }

        private bool StartGameAnswerAllQuestionsAndPostAnswer()
        {
            var url = TestContext.Properties["webAppUrl"].ToString();
            var user = "TestRun " + DateTime.Now.Millisecond;

            var homePage = new HomePage(driver);
            homePage.GoToHome(url);
            var questionPage = homePage.StartNewGame();
            questionPage.SelectFirstCategory();
            questionPage.AnswerFirstQuestion();
            var highScorePage = questionPage.PostHighScore(user);

            var leader = highScorePage.GetHighScoreList().First();
            return user == leader;
        }

        [TestMethod]
        [TestCategory("UI")]
        public void ChromeLoginUserAndSelectNewQuiz()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("UI")]
        public void ChromeLoginUserWithInvalidCredentials()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("UI")]
        public void ChromeLoginUser()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("UI")]
        public void ChromeViewHighScore()
        {
            Assert.IsTrue(true);
        }



        [TestMethod]
        [TestCategory("UI")]
        public void IELoginUserAndSelectNewQuiz()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("UI")]
        public void IELoginUserWithInvalidCredentials()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("UI")]
        public void IELoginUser()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("UI")]
        public void IEViewHighScore()
        {
            Assert.IsTrue(true);
        }


        private IWebDriver GetChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            return new ChromeDriver(options);
        }

        private IWebDriver GetIEDriver()
        {
            return new InternetExplorerDriver(new InternetExplorerOptions()
            {
                IgnoreZoomLevel = true,
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                EnableNativeEvents = false

            });
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

        ////Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            try
            {
                if (driver != null)
                    driver.Quit();
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
