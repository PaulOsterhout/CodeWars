using System;
using NUnit.Framework;

namespace CodeWars.Kata_52423db9add6f6fc39000354
{
	[TestFixture]
	public class UnitTests
	{
		[Test]
		public void TestGlider()
		{
			int[][,] gliders =
			{
				new int[,] {{1,0,0},{0,1,1},{1,1,0}},
				// new int[,] {{0,1,0},{0,0,1},{1,1,1}}
				new int[,] {{0,1,0,0},{0,0,1,0},{1,1,1,0}}
				// new int[,] {{0,0,1,0,0},{0,0,0,1,0},{0,1,1,1,0}}
				// new int[,] {{0,0,1,0,0},{0,0,0,1,0},{0,1,1,1,0},{0,0,0,0,0}}
				// new int[,] {{0,0,0,0,0},{0,0,1,0,0},{0,0,0,1,0},{0,1,1,1,0},{0,0,0,0,0}}
			};
			Console.WriteLine("Glider");
			int[,] res = ConwayLife.GetGeneration(gliders[0], 1);
			WriteResult(res);
			CollectionAssert.AreEqual(gliders[1], res, "Output doesn't match expected");
		}

		// [Test]
		// public void TestCopy()
		// {
		// 	int[][,] gliders =
		// 	{
		// 		new int[,] {{1,0,0},{0,1,1},{1,1,0}}
		// 		//new int[,] {{0,0,0,0,0},{0,1,0,0,0},{0,0,1,1,0},{0,1,1,0,0},{0,0,0,0,0}}
		// 	};
		// 	int[,] res0 = ConwayLife.GetGeneration(gliders[0], 0);
		// 	WriteResult(res0);
		// 	CollectionAssert.AreEqual(gliders[0], res0, "Output doesn't match expected - 0");
		// 	// int[,] res1 = ConwayLife.GetGeneration(gliders[0], 1);
		// 	// WriteResult(res1);
		// 	// CollectionAssert.AreEqual(gliders[1], res1, "Output doesn't match expected - 1");
		// }

		// [Test]
		// public void TestGliders()
		// {
		// 	int[][,] gliders =
		// 	{
		// 		new int[,]
		// 		{
		// 			{1,0,0},
		// 			{0,1,1},
		// 			{1,1,0}
		// 		},
		// 		// new int[,]
		// 		// {
		// 		// 	{0,1,0},
		// 		// 	{0,0,1},
		// 		// 	{1,1,1}
		// 		// },
		// 		new int[,]
		// 		{
		// 			{0,0,0},
		// 			{1,0,1},
		// 			{0,1,1}
		// 		}
		// 	};
		// 	Console.WriteLine("Glider");
		// 	int[,] res = ConwayLife.GetGeneration(gliders[0], 2);
		// 	CollectionAssert.AreEqual(gliders[1], res, "Output doesn't match expected");
		// }

		private void WriteResult(int[,] res)
		{
			foreach (int item in res)
			{
				Console.Write($"{item} ");
			}
			Console.WriteLine("");
		}
	}
}
