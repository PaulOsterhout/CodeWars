using NUnit.Framework;

namespace CodeWars.Kata_51b62bf6a9c58071c600001b
{
	[TestFixture]
	public class UnitTest
	{
		[TestCase(1, "I")]
		[TestCase(2, "II")]
		[TestCase(4, "IV")]
		[TestCase(500, "D")]
		[TestCase(1000, "M")]
		[TestCase(1954, "MCMLIV")]
		[TestCase(1990, "MCMXC")]
		[TestCase(2008, "MMVIII")]
		[TestCase(2014, "MMXIV")]
		public void Test(int value, string expected)
		{
			Assert.AreEqual(expected, RomanConvert.Solution(value));
		}
	}
}