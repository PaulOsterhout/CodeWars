using NUnit.Framework;

namespace CodeWars.Kata_57cebe1dc6fdc20c57000ac9
{
	[TestFixture]
	public class UnitTest
	{
		[Test]
		public void BasicTests()
		{
			Assert.AreEqual(3, Kata.FindShort("bitcoin take over the world maybe who knows perhaps"));
			Assert.AreEqual(3, Kata.FindShort("turns out random test cases are easier than writing out basic ones"));
		}
	}
}