using NUnit.Framework;

namespace CodeWars.Kata_515de9ae9dcfc28eb6000001
{
	[TestFixture]
	public class UnitTest
	{
		[Test]
		public void BasicTests()
		{
			Assert.AreEqual(new string[] { "ab", "c_" }, SplitString.Solution("abc"));
			Assert.AreEqual(new string[] { "ab", "cd", "ef" }, SplitString.Solution("abcdef"));
		}
	}
}