using NUnit.Framework;

namespace CodeWars.Kata_54e6533c92449cc251001667
{
	[TestFixture]
	public class UnitTest
	{
		[Test]
		public void EmptyTest()
		{
			Assert.AreEqual("", Kata.UniqueInOrder(""));
		}
		[Test]
		public void Test1()
		{
			Assert.AreEqual("ABCDAB", Kata.UniqueInOrder("AAAABBBCCDAABBB"));
		}
		[Test]
		public void Test2()
		{
			Assert.AreEqual("ABCcAD", Kata.UniqueInOrder("ABBCcAD"));
		}
		[Test]
		public void Test3()
		{
			Assert.AreEqual(new int[] {1,2,3}, Kata.UniqueInOrder(new int[] {1,2,2,3,3}));
		}
	}
}