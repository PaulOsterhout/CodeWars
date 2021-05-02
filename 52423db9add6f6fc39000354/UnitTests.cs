using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
				new int[,] {{0,1,0},{0,0,1},{1,1,1}}
			};
			Console.WriteLine("Glider");
			int[,] res = ConwayLife.GetGeneration(gliders[0], 1);
			WriteResult(res);
			CollectionAssert.AreEqual(gliders[1], res, "Output doesn't match expected");
		}

		private void WriteResult(int[,] res)
		{
			foreach (int item in res)
			{
				Console.Write($"{item} ");
			}
			Console.WriteLine("");
		}

		[Test]
		public void TestEnumerableRange()
		{
			int[,] cells = new int[,] {{1,0,0},{0,1,1},{1,1,0}};
			IEnumerable<int> actual1 = Enumerable.Range(0, cells.GetLength(0));
			IEnumerable<int> expected1 = new int[] { 0, 1, 2 };
			CollectionAssert.AreEqual(expected1, actual1);
			IEnumerable<int> actual2 = Enumerable.Range(0, cells.GetLength(1));
			IEnumerable<int> expected2 = new int[] { 0, 1, 2 };
			CollectionAssert.AreEqual(expected2, actual2);
			IEnumerable<int> actual3 = actual1.SelectMany(y => actual2);
			IEnumerable<int> expected3 = new int[] { 0,1,2,0,1,2,0,1,2 };
			CollectionAssert.AreEqual(expected3, actual3);
			IEnumerable<Point> actual4 = actual1.SelectMany(y => actual2.Select(x => new Point(x,y)));
			IEnumerable<Point> expected4 = new Point[]
			{
				new Point(0,0),
				new Point(1,0),
				new Point(2,0),
				new Point(0,1),
				new Point(1,1),
				new Point(2,1),
				new Point(0,2),
				new Point(1,2),
				new Point(2,2)
			};
			CollectionAssert.AreEqual(expected4, actual4);
			IEnumerable<Point> actual5 = actual4.Where(c => cells[c.Y,c.X] > 0);
			IEnumerable<Point> expected5 = new Point[]
			{
				new Point(0,0),
				new Point(1,1),
				new Point(2,1),
				new Point(0,2),
				new Point(1,2)
			};
			CollectionAssert.AreEqual(expected5, actual5);
			HashSet<Point> actual6 = actual5.ToHashSet();
			HashSet<Point> expected6 = new HashSet<Point>
			{
				new Point(0,0),
				new Point(1,1),
				new Point(2,1),
				new Point(0,2),
				new Point(1,2)
			};
			CollectionAssert.AreEqual(expected6, actual6);
		}

		[Test]
		public void TestGetSurrounding()
		{
			IEnumerable<Point> GetSurroundingPoints(Point point) => Enumerable.Range(-1, 3)
				.SelectMany(y => Enumerable.Range(-1, 3)
				.Select(x => new Point(point.X + x, point.Y + y)));

			int[,] cells = new int[,] {{1,0,0},{0,1,1},{1,1,0}};
			HashSet<Point> points = Enumerable.Range(0, cells.GetLength(0))
				.SelectMany(y => Enumerable.Range(0, cells.GetLength(1))
				.Select(x => new Point(x,y)))
				.Where(point => cells[point.Y,point.X] > 0)
				.ToHashSet();
			HashSet<Point> expected1 = new HashSet<Point>
			{
				new Point(0,0),
				new Point(1,1),
				new Point(2,1),
				new Point(0,2),
				new Point(1,2)
			};
			CollectionAssert.AreEqual(expected1, points);
			IEnumerable<Point> surrounding = GetSurroundingPoints(new Point(1,1));
			IEnumerable<Point> expected2 = new Point[]
			{
				new Point(0,0),
				new Point(1,0),
				new Point(2,0),
				new Point(0,1),
				new Point(1,1),
				new Point(2,1),
				new Point(0,2),
				new Point(1,2),
				new Point(2,2)
			};
			CollectionAssert.AreEqual(expected2, surrounding);
			HashSet<Point> pointsToScan = points.SelectMany(GetSurroundingPoints).ToHashSet();
			HashSet<Point> expected3 = new HashSet<Point>
			{
				new Point(-1,-1),
				new Point(0,-1),
				new Point(1,-1),
				new Point(-1,0),
				new Point(0,0),
				new Point(1,0),
				new Point(2,0),
				new Point(3,0),
				new Point(-1,1),
				new Point(0,1),
				new Point(1,1),
				new Point(2,1),
				new Point(3,1),
				new Point(-1,2),
				new Point(0,2),
				new Point(1,2),
				new Point(2,2),
				new Point(3,2),
				new Point(-1,3),
				new Point(0,3),
				new Point(1,3),
				new Point(2,3)
			};
			CollectionAssert.AreEqual(expected3.OrderBy(point => point.Y).OrderBy(point => point.X), pointsToScan.OrderBy(point => point.Y).OrderBy(point => point.X));
		}
	}
}
