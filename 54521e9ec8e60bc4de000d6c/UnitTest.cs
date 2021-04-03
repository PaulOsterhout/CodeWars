using NUnit.Framework;

namespace CodeWars.Kata_54521e9ec8e60bc4de000d6c
{
	[TestFixture]
	public class UnitTest
	{

		[Test]
		public void Test0()
		{
			Assert.AreEqual(0, Kata.MaxSequence(new int[0]));
		}
		[Test]
		public void Test1()
		{
			Assert.AreEqual(6, Kata.MaxSequence(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));
		}
	}
}
