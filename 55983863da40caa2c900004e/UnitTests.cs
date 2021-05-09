using System;
using NUnit.Framework;

namespace CodeWars.Kata_55983863da40caa2c900004e
{
	[TestFixture]
	public class UnitTests
	{
		[Test]
		public void Test1()
		{
			Console.WriteLine("****** Small Number1");
			Assert.AreEqual(21, Kata.NextBiggerNumber(12));
			Assert.AreEqual(531, Kata.NextBiggerNumber(513));
			Assert.AreEqual(2071, Kata.NextBiggerNumber(2017));
			Assert.AreEqual(441, Kata.NextBiggerNumber(414));
		}

		[Test]
		public void Test2()
		{
			Console.WriteLine("****** Small Number2");
			Assert.AreEqual(2107, Kata.NextBiggerNumber(2071));
			Assert.AreEqual(2170, Kata.NextBiggerNumber(2107));
			Assert.AreEqual(414, Kata.NextBiggerNumber(144));
		}

		[Test]
		public void GetLargeNumber()
		{
			Assert.AreEqual(111111111111121, Kata.NextBiggerNumber(111111111111112));
		}
	}
}
