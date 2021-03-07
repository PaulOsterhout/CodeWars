using System.Linq;

namespace CodeWars.Kata_52597aa56021e91c93000cb0
{
	public class Kata
	{
		public static int[] MoveZeroes(int[] arr)
		{
			return arr.Where(x => x != 0).Concat(arr.Where(x => x == 0)).ToArray();
		}
	}
}
