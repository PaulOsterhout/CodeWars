using NUnit.Framework;

namespace CodeWars.Kata_551dc350bf4e526099000ae5
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual("ABC", Dubstep.SongDecoder("WUBWUBABCWUB"));
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual("R L", Dubstep.SongDecoder("RWUBWUBWUBLWUB"));
        }

        [Test]
        public void Test3()
        {
            Assert.AreEqual("WE ARE THE CHAMPIONS MY FRIEND", Dubstep.SongDecoder("WUBWEWUBAREWUBWUBTHEWUBCHAMPIONSWUBMYWUBFRIENDWUB"));
        }
    }
}