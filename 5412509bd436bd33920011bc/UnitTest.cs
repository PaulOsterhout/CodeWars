using NUnit.Framework;

namespace CodeWars.Kata_5412509bd436bd33920011bc
{
	public class Tests
	{
		[Test]
		public void Test1()
		{
			Assert.AreEqual("############5616", Kata.Maskify("4556364607935616"));
			Assert.AreEqual("#######5616", Kata.Maskify("64607935616"));
			Assert.AreEqual("1", Kata.Maskify("1"));
			Assert.AreEqual("", Kata.Maskify(""));

			Assert.AreEqual("##ippy", Kata.Maskify("Skippy"));
			Assert.AreEqual("####################################man!", Kata.Maskify("Nananananananananananananananana Batman!"));
		}
	}
}