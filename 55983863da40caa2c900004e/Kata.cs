using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata_55983863da40caa2c900004e
{
	public class Kata
	{
		public static long NextBiggerNumber(long n)
		{
			long next = -1;
			List<int> digits = n.ToString().Select(x => int.Parse(x.ToString())).ToList();
			int digitsLength = digits.Count;
			for (int startDigit = digitsLength - 2; startDigit >= 0; startDigit--)
			{
				bool foundNumber = false;
				foreach (string combination in GetCombinations(digits.GetRange(startDigit, digitsLength - startDigit)))
				{
					long possible = long.Parse(string.Concat(digits.GetRange(0, startDigit)) + combination);
					if (possible > n)
					{
						foundNumber = true;
						if ((next == -1) || (possible < next)) next = possible;
					}
				}
				if (foundNumber) return next;
			}
			return next;
		}

		public static HashSet<string> GetCombinations(List<int> digits)
		{
			int digitsLength = digits.Count;
			if (digitsLength == 2)
			{
				return new HashSet<string>
				{
					$"{digits[0]}{digits[1]}",
					$"{digits[1]}{digits[0]}",
				};
			}
			HashSet<string> combinations = new HashSet<string>();
			foreach (int firstDigit in digits.Distinct())
			{
				List<int> innerDigits = digits.Distinct().OrderBy(x => x).ToList();
				innerDigits.Remove(firstDigit);
				foreach (string combination in GetCombinations(innerDigits))
				{
					if (!combinations.Contains(combination)) combinations.Add(firstDigit.ToString() + combination);
				}
			}
			return combinations;
		}

		private static long Old(long n)
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
