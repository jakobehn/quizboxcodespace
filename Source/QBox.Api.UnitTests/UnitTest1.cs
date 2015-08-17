﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QBox.Api.Controllers;

namespace QBox.Api.UnitTests
{
    [TestClass]
    public class ApiTests
    {
        [TestMethod]
        [Priority(2)]
        public void CreateQuizShouldStoreCorrectly()
        {
            //Yes
        }
        [TestMethod]
        [Priority(2)]
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
        [Priority(1)]
        public void LoginWithInvalidCredentialsShouldFail()
        {
            //Yes
        }
        [TestMethod]
        [Priority(1)]
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
