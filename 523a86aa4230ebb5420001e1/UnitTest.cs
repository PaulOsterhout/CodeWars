using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodeWars.Kata_523a86aa4230ebb5420001e1
{
	[TestFixture]
	public class UnitTest
	{
		[Test]
		public void SampleTest()
		{
			Assert.AreEqual(new List<string> { "a" }, Kata.Anagrams("a", new List<string> { "a", "b", "c", "d" }));
			Assert.AreEqual(new List<string> { "carer", "arcre", "carre" }, Kata.Anagrams("racer", new List<string> { "carer", "arcre", "carre", "racrs", "racers", "arceer", "raccer", "carrer", "cerarr" }));
		}
	}
}