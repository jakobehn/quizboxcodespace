using System;
using QBox.Api.Controllers;
using NUnit.Framework;
using System.Threading;

namespace QBox.Api.UnitTests
{
    [TestFixture]
    //[Parallelizable]

    public class HighscoreTests
    {
        [Test]
        public void PostTopHighscoreShouldStoreScoreAtTop()
        {
            Thread.Sleep(2000);
        }


        [Test]
        public void CategoryMustMatchIndex()
        {
            Thread.Sleep(2000);
        }

    }
   
}
