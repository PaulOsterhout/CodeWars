using NUnit.Framework;

namespace CodeWars.Kata_5933a1f8552bc2750a0000ed
{
	[TestFixture]
	public class UnitTest
	{
		[Test]
		[TestCase(1, ExpectedResult = 0)]
		[TestCase(3, ExpectedResult = 4)]
		[TestCase(100, ExpectedResult = 198)]
		[TestCase(1298734, ExpectedResult = 2597466)]
		public int FixedTest(int n)
		{
			return Kata.NthEven(n);
		}
	}
}
