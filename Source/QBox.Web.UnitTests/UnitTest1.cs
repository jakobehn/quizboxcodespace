using NUnit.Framework;
using System;
using System.Threading;

namespace QBox.Web.UnitTests
{
    [TestFixture]
    public class WebTests
    {
        [Test]
        public void PostQuizResponseShouldStore()
        {
            Thread.Sleep(2000);
        }

        [Test]
        public void StartGameQuizShouldStart()
        {
            Thread.Sleep(2000);
        }

        [Test]
        public void AnswerQuestionShouldAnswer()
        {
            Thread.Sleep(2000);
        }

        [Test]
        public void AbortGameShouldStopGame()
        {
            Thread.Sleep(2000);
        }

        [Test]
        public void LoginWithInvalidCredentialsShouldFail()
        {
            Thread.Sleep(2000);
        }
        [Test]
        public void LogoutShouldClearCookie()
        {
            Thread.Sleep(2000);
        }

        [Test]
        public void PostHighscoreShouldStore()
        {
            Thread.Sleep(2000);
        }
    }
}
