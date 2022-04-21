using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QBox.Api.UnitTests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        [TestCategory("Integration")]
        public void PlayerNameShouldBeValid()
        {
            Thread.Sleep(2000);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void PlayerAgeCanBeChanged()
        {
            Thread.Sleep(2000);
        }
        [TestMethod]
        [TestCategory("Integration")]
        public void PlayerNameMustBeUnique()
        {
            Thread.Sleep(2000);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void PlayerAgeCantBeLowerThanZero()
        {
            Thread.Sleep(2000);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void PlayerNameMustContainLettersOnly()
        {
            Thread.Sleep(2000);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void PlayerNameMustBeLocal()
        {
            Thread.Sleep(2000);
        }
    }
}
