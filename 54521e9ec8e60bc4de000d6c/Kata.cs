using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata_54521e9ec8e60bc4de000d6c
{
	public static class Kata
	{
		public static int MaxSequence(int[] arr)
		{
			if (arr.Length == 0) return 0;
			int sum = arr.Min();
			for (int first = 0; first < arr.Length; first++)
			{
				for (int last = first; last < arr.Length; last++)
				{
					List<int> test = new List<int>(arr).GetRange(first, last - first + 1);
					if (test.Sum() > sum)
					{
						sum = test.Sum();
					}
				}
			}
			return sum;
		}
	}
}
