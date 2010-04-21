using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace NDueTime.Test
{
	[TestFixture]
	public class TimeSpanExtensionsTest
	{
		private DateTime _fiveMinutesAgo;

		[SetUp]
		public void SetUp()
		{
			_fiveMinutesAgo = DateTime.Now.AddMinutes(-5);
		}

		[Test]
		public void FiveMinutesAgo_IsInThePast()
		{
			Assert.That(5.Minutes().Ago() < DateTime.Now);
		}

		[Test]
		public void FiveMinutesFromNow_IsInTheFuture()
		{
			Assert.That(5.Minutes().FromNow() > DateTime.Now);
		}

		[Test]
		public void FiveMinutesAndOneSecondAgo_IsBefore_FiveMinutesAgo()
		{
			Assert.That(5.Minutes().And(1.Seconds()).Ago() < _fiveMinutesAgo);
		}
	}
}
