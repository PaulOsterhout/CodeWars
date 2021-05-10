using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata_55983863da40caa2c900004e
{
	public class KataV1
	{
		public static long NextBiggerNumber(long n)
		{
			HashSet<long> numbers = GetPossibles(n.ToString()).Select(x => long.Parse(x.ToString())).ToHashSet();
			return numbers.Where(x => x > n).Min();
		}

		private static HashSet<string> GetPossibles(string digits)
		{
			if (digits.Length == 1) return new HashSet<string> { digits };
			HashSet<string> possibles = new HashSet<string>();
			for (int firstDigit = 0; firstDigit < digits.Length; firstDigit++)
			{
				List<char> innerList = new List<char>(digits);
				innerList.RemoveAt(firstDigit);
				foreach (string possible in GetPossibles(string.Concat(innerList)))
				{
					possibles.Add(digits.Substring(firstDigit, 1) + possible);
				}
			}
			return possibles;
		}
	}
}
