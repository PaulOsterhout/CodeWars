using System;
using System.Collections.Generic;
using System.Linq;
//https://www.codewars.com/kata/521c2db8ddc89b9b7a0000c1/train/csharp
namespace CodeWars.Kata_521c2db8ddc89b9b7a0000c1
{
	public class SnailSolution
	{
		public static int[] Snail(int[][] array)
		{
			List<Tuple<int, int>> coordinates = new List<Tuple<int, int>>();
			int x = 0, y = 0, xDir = 1, yDir = 0, length = array.Length, middle = length / 2;
			coordinates.Add(new Tuple<int, int>(x, y));
			while ((x != middle) || (y != middle))
			{
				if ((x + xDir < 0) || (x + xDir == length) || (y + yDir < 0) || (y + yDir == length))
				{
					RotateClockwise(xDir, yDir);
				}
				int x1 = x + xDir; int y1 = y + yDir;
				Tuple<int, int> newCoordinates = new Tuple<int, int>(x1, y1);
				if (coordinates.Contains(newCoordinates))
				{
					RotateClockwise(xDir, yDir);
				}
				x += xDir; y += yDir;
				coordinates.Add(new Tuple<int, int>(x, y));
			}
			return coordinates.Select(x => array[x.Item2][x.Item1]).ToArray();
		}

		private static void RotateClockwise(int xDir, int yDir)
		{
			int temp = xDir;
			xDir = yDir * -1;
			yDir = temp * 1;
		}
	}
}