using NUnit.Framework;
using System.Threading;

namespace QBox.Api.UnitTests
{
    [TestFixture]
    //[Parallelizable]
    public class CreateQuizTests
    {

        [Test]
        public void CreateQuizShouldStoreCorrectly()
        {
            Thread.Sleep(2000);
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
