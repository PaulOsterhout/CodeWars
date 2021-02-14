using System;
using System.Linq;
using NUnit.Framework;

namespace CodeWars.Kata_521c2db8ddc89b9b7a0000c1
{
	[TestFixture]
	public class UnitTest
	{
		[Test]
		public void SnailTest1()
		{
			int[][] array =
			{
				new []{1, 2, 3},
				new []{4, 5, 6},
				new []{7, 8, 9}
			};
			var r = new[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 };
			Test(array, r);
		}

		public string Int2dToString(int[][] a)
		{
			return $"[{string.Join("\n", a.Select(row => $"[{string.Join(",", row)}]"))}]";
		}

		public void Test(int[][] array, int[] result)
		{
			var text = $"{Int2dToString(array)}\nshould be sorted to\n[{string.Join(",", result)}]\n";
			Console.WriteLine(text);
			Assert.AreEqual(result, SnailSolution.Snail(array));
		}

		[Test]
		public void ChangeDirections1()
		{
			int xDir = 1, yDir = 0;

			void Change()
			{
				int temp = xDir;
				xDir = yDir * -1;
				yDir = temp * 1;
			}

			Assert.AreEqual(1, xDir);
			Assert.AreEqual(0, yDir);
			Change();
			Assert.AreEqual(0, xDir);
			Assert.AreEqual(1, yDir);
			Change();
			Assert.AreEqual(-1, xDir);
			Assert.AreEqual(0, yDir);
			Change();
			Assert.AreEqual(0, xDir);
			Assert.AreEqual(-1, yDir);
			Change();
			Assert.AreEqual(1, xDir);
			Assert.AreEqual(0, yDir);
		}

		[Test]
		public void ChangeDirections2()
		{
			int xDir = 1, yDir = 0;

			void Change()
			{
				if (xDir == 1)
				{
					xDir = 0;
					yDir = 1;
				}
				else if (yDir == 1)
				{
					xDir = -1;
					yDir = 0;
				}
				else if (xDir == -1)
				{
					xDir = 0;
					yDir = -1;
				}
				else
				{
					xDir = 1;
					yDir = 0;
				}
			}

			Assert.AreEqual(1, xDir);
			Assert.AreEqual(0, yDir);
			Change();
			Assert.AreEqual(0, xDir);
			Assert.AreEqual(1, yDir);
			Change();
			Assert.AreEqual(-1, xDir);
			Assert.AreEqual(0, yDir);
			Change();
			Assert.AreEqual(0, xDir);
			Assert.AreEqual(-1, yDir);
			Change();
			Assert.AreEqual(1, xDir);
			Assert.AreEqual(0, yDir);
		}
	}
}