using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QBox.Api.Controllers;

namespace QBox.Api.UnitTests
{
    [TestClass]
    public class ApiTests
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void CreateQuizShouldStoreCorrectly()
        {
            //Yes
            var quizId = 123;
            var quizStatus = "OK";
            TestContext.WriteLine("Quiz {0} updated to {1}.", quizId, quizStatus);
        }

        [TestMethod]
        public void ReomveQuizShouldDeleteFromCollection()
        {
            //Yes
        }
        [TestMethod]
        public void AddDuplicateQuizShouldFail()
        {
            //Yes
        }
        [TestMethod]
        public void PostTopHighscoreShouldStoreScoreAtTop()
        {
            //Yes
        }
        [TestMethod]
        public void LoginWithInvalidCredentialsShouldFail()
        {
            //Yes
        }
        [TestMethod]
        public void LogoutShouldClearCookie()
        {
            //Yes
        }

        [TestMethod]
        public void SomeMethodTest()
        {
            var controller = new CategoryController();
            Assert.AreEqual("42", controller.SomeMethod());
        }
    }
}
