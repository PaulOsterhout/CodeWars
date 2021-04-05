using NUnit.Framework;

namespace CodeWars.Kata_550f22f4d758534c1100025a
{
	[TestFixture]
	public class UnitTest
	{
		[Test]
		public void Test1()
		{
			string[] a = new string[] { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" };
			string[] b = new string[] { "WEST" };
			Assert.AreEqual(b, DirReduction.dirReduc(a));
		}
	
		[Test]
		public void Test2()
		{
			string[] a = new string[] { "NORTH", "WEST", "SOUTH", "EAST" };
			string[] b = new string[] { "NORTH", "WEST", "SOUTH", "EAST" };
			Assert.AreEqual(b, DirReduction.dirReduc(a));
		}
	
		[Test]
		public void Test3()
		{
			string[] a = new string[] { "SOUTH", "EAST", "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST", "WEST" };
			string[] b = new string[] { "SOUTH", "WEST" };
			Assert.AreEqual(b, DirReduction.dirReduc(a));
		}
	}
}
