using NUnit.Framework;
using System.Threading;
using QBox.Api.Controllers;

namespace QBox.Api.UnitTests
{
    [TestFixture]
    //[Parallelizable]
    public class CreateQuizTests
    {

        [Test]
        public void GetScoreMessageTest()
        {
            var game = new GameController();
            var scoreMessage = game.GetScoreMessage(0.6f);

            Assert.AreEqual("Not too shabby", scoreMessage);
        }

        [Test]
        public void RemoveQuizShouldDeleteFromCollection()
        {
            Thread.Sleep(2000);
        }
        [Test]
        public void AddDuplicateQuizShouldFail()
        {
            Thread.Sleep(2000);
        }
    }
}
