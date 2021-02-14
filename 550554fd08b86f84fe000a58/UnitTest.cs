using NUnit.Framework;

namespace CodeWars.Kata_550554fd08b86f84fe000a58
{
	[TestFixture]
	public class WhichAreInTests
	{

		[Test]
		public void Test1()
		{
			string[] a1 = new string[] { "arp", "live", "strong" };
			string[] a2 = new string[] { "lively", "alive", "harp", "sharp", "armstrong" };
			string[] r = new string[] { "arp", "live", "strong" };
			Assert.AreEqual(r, WhichAreIn.inArray(a1, a2));
		}
	}
}