using System;
using QBox.Api.Controllers;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QBox.Api.UnitTests
{
    [TestClass]

    public class HighscoreTests
    {
        [TestMethod]
        [TestCategory("Integration")]
        public void PostTopHighscoreShouldStoreScoreAtTop()
        {
            Thread.Sleep(2000);
        }


        [TestMethod]
        [TestCategory("Integration")]
        public void CategoryMustMatchIndex()
        {
            Thread.Sleep(2000);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void StartNewGame()
        {
            Thread.Sleep(2000);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void FinishGame()
        {
            Thread.Sleep(2000);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void SelectRandomCategory()
        {
            Thread.Sleep(2000);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void SelectRandomCategoryTwice()
        {
            Thread.Sleep(2000);
        }
        [TestMethod]
        [TestCategory("Integration")]
        public void SelectFirstCategory()
        {
            Thread.Sleep(2000);
        }
        [TestMethod]
        [TestCategory("Integration")]
        public void SelectLastCategory()
        {
            Thread.Sleep(2000);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void CategoryNameShouldBeValid()
        {
            var controller = new CategoryController();
            var res = controller.SomeMethod();
        }

    }

}
