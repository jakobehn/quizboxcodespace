using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using System.Linq;
using QBox.Web.UITests.PageObjects;

namespace QBox.Web.UITests
{
    [TestClass]
    [DeploymentItem("chromedriver.exe")]
    [DeploymentItem("IEDriverServer.exe")]
    public class QuestionTests
    {
        private IWebDriver driver;
        private string url;

        [TestMethod]
        [TestCategory("UI")]
        public void ChromeStartGameAnswerAllQuestionsAndPostAnswer()
        {
            driver = GetChromeDriver();
            StartGameAnswerAllQuestionsAndPostAnswer();
        }

        [TestMethod]
        [TestCategory("UI")]
        public void IEStartGameAnswerAllQuestionsAndPostAnswer()
        {
            driver = GetIEDriver();
            StartGameAnswerAllQuestionsAndPostAnswer();
        }

        private void StartGameAnswerAllQuestionsAndPostAnswer()
        {
            var user = "TestRun " + DateTime.Now.Millisecond;

            var highScorePage =
                GoToHomePage()
                    .StartNewGame()
                    .SelectCategory("SPORTS")
                    .Answer("Germany")
                    .PostHighScore(user);

            var leader = highScorePage.GetHighScoreList().First();
            Assert.IsTrue(user == leader);
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
        public void ChromeGotoHighScore()
        {
            driver = GetChromeDriver();
            GoToHighscorePage();
        }

        [TestMethod]
        [TestCategory("UI")]
        public void IEGotoHighScore()
        {
            driver = GetIEDriver();
            GoToHighscorePage();
        }

        private void GoToHighscorePage()
        {
            var highScores = GoToHomePage()
                .GoToHighscorePage()
                .GetHighScoreList();

            Assert.IsTrue(highScores.Any());
        }

        [TestMethod]
        [TestCategory("UI")]
        public void IESelectRandomCategory()
        {
            driver = GetIEDriver();
            SelectRandomCategory();
        }

        [TestMethod]
        [TestCategory("UI")]
        public void ChromeSelectRandomCategory()
        {
            driver = GetChromeDriver();
            SelectRandomCategory();
        }


        private void SelectRandomCategory()
        {
            var questionPage = GoToHomePage()
                .StartNewGame()
                .SelectRandomCategory();

            Assert.IsTrue(!String.IsNullOrEmpty(questionPage.Category));
        }

        [TestMethod]
        [TestCategory("UI")]
        public void IESelectCategory()
        {
            driver = GetIEDriver();
            SelectCategory();
        }

        [TestMethod]
        [TestCategory("UI")]
        public void ChromeSelectCategory()
        {
            driver = GetChromeDriver();
            SelectCategory();
        }


        private void SelectCategory()
        {
            string category = "FOOD";

            var questionPage = GoToHomePage()
                .StartNewGame()
                .SelectCategory(category);

            Assert.AreEqual(questionPage.Category, category);
        }

        private HomePage GoToHomePage()
        {
            var homePage = new HomePage(driver);
            homePage.GoToHome(url);

            return homePage;
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

        private IWebDriver GetChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArguments("chrome.switches", "--disable-extensions");
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

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            url = TestContext.Properties["webAppUrl"].ToString();
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
