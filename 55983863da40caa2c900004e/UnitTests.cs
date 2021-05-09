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
			Assert.AreEqual(441, Kata.NextBiggerNumber(414));
		}

		[Test]
		public void Test2()
		{
			Console.WriteLine("****** Small Number2");
			Assert.AreEqual(1072, Kata.NextBiggerNumber(1027));
			Assert.AreEqual(1207, Kata.NextBiggerNumber(1072));
			Assert.AreEqual(1270, Kata.NextBiggerNumber(1207));
			Assert.AreEqual(1702, Kata.NextBiggerNumber(1270));
			Assert.AreEqual(1720, Kata.NextBiggerNumber(1702));
			Assert.AreEqual(2017, Kata.NextBiggerNumber(1720));
			Assert.AreEqual(2071, Kata.NextBiggerNumber(2017));
			Assert.AreEqual(2107, Kata.NextBiggerNumber(2071));
			Assert.AreEqual(2170, Kata.NextBiggerNumber(2107));
			Assert.AreEqual(2701, Kata.NextBiggerNumber(2170));
			Assert.AreEqual(2710, Kata.NextBiggerNumber(2701));
			Assert.AreEqual(7012, Kata.NextBiggerNumber(2710));
			Assert.AreEqual(7021, Kata.NextBiggerNumber(7012));
			Assert.AreEqual(7102, Kata.NextBiggerNumber(7021));
			Assert.AreEqual(7120, Kata.NextBiggerNumber(7102));
			Assert.AreEqual(7201, Kata.NextBiggerNumber(7120));
			Assert.AreEqual(7210, Kata.NextBiggerNumber(7201));
			Assert.AreEqual(-1, Kata.NextBiggerNumber(7210));
		}

		[Test]
		public void Test3()
		{
			Console.WriteLine("****** Small Number3");
			Assert.AreEqual(414, Kata.NextBiggerNumber(144));
		}

		[Test]
		public void GetLargeNumber()
		{
			Assert.AreEqual(111111111111121, Kata.NextBiggerNumber(111111111111112));
		}
	}
}
