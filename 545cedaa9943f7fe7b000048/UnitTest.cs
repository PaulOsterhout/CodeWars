using NUnit.Framework;

namespace CodeWars.Kata_545cedaa9943f7fe7b000048
{
	[TestFixture]
	public class UnitTest
	{
		[Test]
		public void SampleTests()
		{
			Assert.AreEqual(true, Kata.IsPangram("The quick brown fox jumps over the lazy dog."));
		}
	}
}