using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace NDueTime.Test
{
    [TestFixture]
    public class DateTimeExtensionsTest
    {
        private DateTime _fourMinutesAgo;
        private DateTime _fiveMinutesAgo;
        private DateTime _sixMinutesAgo;

        [SetUp]
        public void SetUp()
        {
            _fourMinutesAgo = DateTime.Now.AddMinutes(-4);
            _fiveMinutesAgo = DateTime.Now.AddMinutes(-5);
            _sixMinutesAgo = DateTime.Now.AddMinutes(-6);
        }

        [Test]
        public void FiveMinutesAgo_IsBetween_FourAndSixMinutesAgo()
        {
            Assert.That(_fiveMinutesAgo.IsBetween(_fourMinutesAgo, _sixMinutesAgo));
        }

        [Test]
        public void FiveMinutesAgo_IsBetween_SixAndFourMinutesAgo()
        {
            Assert.That(_fiveMinutesAgo.IsBetween(_sixMinutesAgo, _fourMinutesAgo));
        }
    }
}
