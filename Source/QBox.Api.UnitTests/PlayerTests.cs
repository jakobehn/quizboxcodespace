using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Xunit;

namespace QBox.Api.UnitTests
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        [Category("Integration")]
        public void PlayerNameShouldBeValid()
        {
            Thread.Sleep(2000);
        }

        [Test]
        [Category("Integration")]
        public void PlayerAgeCanBeChanged()
        {
            Thread.Sleep(2000);
        }

        [Test]
        [Category("Integration")]
        public void PlayerNameMustBeUnique()
        {
            Thread.Sleep(2000);
        }

        [Test]
        [Category("Integration")]
        public void PlayerAgeCantBeLowerThanZero()
        {
            Thread.Sleep(2000);
        }

        [Test]
        [Category("Integration")]
        public void PlayerNameMustContainLettersOnly()
        {
            Thread.Sleep(2000);
        }

        [Test]
        [Category("Integration")]
        public void PlayerNameMustBeLocal()
        {
            Thread.Sleep(2000);
        }
    }
}
