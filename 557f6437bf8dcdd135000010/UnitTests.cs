using NUnit.Framework;

namespace CodeWars.Kata_557f6437bf8dcdd135000010
{
	[TestFixture]
	public class UnitTests
	{
		[Test]
		public void BasicTests()
		{
			Assert.IsNull(Kata.Factorial(-1));
			Assert.AreEqual("1", Kata.Factorial(0));
			Assert.AreEqual("1", Kata.Factorial(1));
		}

		[Test]
		public void ExtemdedTests()
		{
			Assert.AreEqual("2", Kata.Factorial(2));
			Assert.AreEqual("6", Kata.Factorial(3));
			Assert.AreEqual("24", Kata.Factorial(4));
			Assert.AreEqual("120", Kata.Factorial(5));
			Assert.AreEqual("362880", Kata.Factorial(9));
			Assert.AreEqual("1307674368000", Kata.Factorial(15));
		}
	}
}
