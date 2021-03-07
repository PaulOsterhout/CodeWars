using NUnit.Framework;

namespace CodeWars.Kata_52597aa56021e91c93000cb0
{
	[TestFixture]
	public class UnitTest
	{
		[Test]
		public void Test()
		{
			Assert.AreEqual(new int[] { 1, 2, 1, 1, 3, 1, 0, 0, 0, 0 }, Kata.MoveZeroes(new int[] { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1 }));
		}
	}
}
