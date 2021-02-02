using NUnit.Framework;

namespace CodeWars.Kata_54da539698b8a2ad76000228
{
	[TestFixture]
	public class UnitTest
	{
		[Test]
		public void Test()
		{
			Assert.AreEqual(true, Kata.IsValidWalk(new string[] {"n","s","n","s","n","s","n","s","n","s"}), "should return true");
			Assert.AreEqual(false, Kata.IsValidWalk(new string[] {"w","e","w","e","w","e","w","e","w","e","w","e"}), "should return false");
			Assert.AreEqual(false, Kata.IsValidWalk(new string[] {"w"}), "should return false");
			Assert.AreEqual(false, Kata.IsValidWalk(new string[] {"n","n","n","s","n","s","n","s","n","s"}), "should return false");
		}
	}
}