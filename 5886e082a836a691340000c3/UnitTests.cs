using NUnit.Framework;

namespace CodeWars.Kata_5886e082a836a691340000c3
{
	[TestFixture]
	public class myjinxin
	{
		[Test]
		public void BasicTests(){
			var kata=new Kata();
			Assert.AreEqual(23, kata.RectangleRotation(6,4));
			Assert.AreEqual(65, kata.RectangleRotation(30,2));
			Assert.AreEqual(49, kata.RectangleRotation(8,6));
			Assert.AreEqual(333, kata.RectangleRotation(16,20));
		}        
	}
}
