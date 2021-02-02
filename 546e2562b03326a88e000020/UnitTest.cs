using NUnit.Framework;

namespace CodeWars.Kata_546e2562b03326a88e000020
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void SquareDigitsTests()
        {
            Assert.AreEqual(811181, Kata.SquareDigits(9119));
        }
    }
}