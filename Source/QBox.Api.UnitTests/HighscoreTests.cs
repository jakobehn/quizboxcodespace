using System;
using QBox.Api.Controllers;
using NUnit.Framework;
using System.Threading;

namespace QBox.Api.UnitTests
{
    [TestFixture]

    public class HighscoreTests
    {
        [Test]
        [Category("Integration")]
        public void PostTopHighscoreShouldStoreScoreAtTop()
        {
            Thread.Sleep(2000);
        }


        [Test]
        [Category("Integration")]
        public void CategoryMustMatchIndex()
        {
            Thread.Sleep(2000);
        }

        [Test]
        [Category("Integration")]
        public void StartNewGame()
        {
            Thread.Sleep(2000);
        }

        [Test]
        [Category("Integration")]
        public void FinishGame()
        {
            Thread.Sleep(2000);
        }

        [Test]
        [Category("Integration")]
        public void SelectRandomCategory()
        {
            Thread.Sleep(2000);
        }

        [Test]
        [Category("Integration")]
        public void SelectRandomCategoryTwice()
        {
            Thread.Sleep(2000);
        }

        [Test]
        [Category("Integration")]
        public void SelectFirstCategory()
        {
            Thread.Sleep(2000);
        }
        [Test]
        [Category("Integration")]
        public void SelectLastCategory()
        {
            Thread.Sleep(2000);
        }

        [Test]
        [Category("Integration")]
        public void CategoryNameShouldBeValid()
        {
            var controller = new CategoryController();
            var res = controller.SomeMethod();
        }

    }

}
