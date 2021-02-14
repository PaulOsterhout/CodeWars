using System.Collections.Generic;
//https://www.codewars.com/kata/521c2db8ddc89b9b7a0000c1/train/csharp
namespace CodeWars.Kata_521c2db8ddc89b9b7a0000c1
{
	public class SnailSolution
	{
		public static int[] Snail(int[][] array)
		{
			List<int> snail = new List<int>();
			int x = 0, y = 0, xDir = 1, yDir = 0, length = array.Length, middle = length / 2;
			while ((x != middle) || (y != middle))
			{
				snail.Add(array[x][y]);
				if ((x + xDir < 0) || (x + xDir == length) || (y + yDir < 0) || (y + yDir == length))
				{
					int temp = xDir;
					xDir = yDir * -1;
					yDir = temp * 1;
				}
				x += xDir; y += yDir;
			}
			snail.Add(array[y][x]);
			return snail.ToArray();
		}
	}
}