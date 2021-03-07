using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata_521c2db8ddc89b9b7a0000c1
{
	public class SnailSolution
	{
		public static int[] Snail(int[][] array)
		{
			List<int> trail = new List<int>();
			List<List<bool>> travelled = array.Select(x => x.Select(y => false).ToList()).ToList();
			int i = 0, iDir = 1, iLength = array[0].Length, r = 0, rDir = 0, rLength = array.Length;
			while (travelled.Any(x => x.Any(y => !y)))
			{
				if (!travelled[r][i])
				{
					trail.Add(array[r][i]);
					travelled[r][i] = true;
				}
				int nextR = r + rDir;
				int nextI = i + iDir;
				if ((nextI < 0) || (nextI == iLength) || (nextR < 0) || (nextR == rLength))
				{
					RotateClockwise(ref iDir, ref rDir);
				}
				else if (travelled[r + rDir][i + iDir] && travelled.Any(x => x.Any(y => !y)))
				{
					RotateClockwise(ref iDir, ref rDir);
				}
				else
				{
					i = nextI;
					r = nextR;
				}
			}
			return trail.ToArray();
		}

		private static void RotateClockwise(ref int xDir, ref int yDir)
		{
			int temp = xDir;
			xDir = yDir * -1;
			yDir = temp * 1;
		}
	}
}