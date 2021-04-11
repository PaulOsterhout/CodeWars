using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata_5254ca2719453dcc0b00027d
{
	public class Permutations
	{
		public static List<string> SinglePermutations(string s)
		{
			return Better(s);
		}

		private static List<string> Mine(string s)
		{
			return GetPermutations(s).Distinct().ToList();
		}

		private static List<string> GetPermutations(string s)
		{
			List<string> permutations = new List<string>();
			if (s.Length == 1) return new List<string>() { s };
			for (int i = 0; i < s.Length; i++)
			{
				string s1 = (i > 0)
					? (i < s.Length - 1)
						? s.Substring(0, i) + s.Substring(i + 1, s.Length - i - 1)
						: s.Substring(0, s.Length - 1)
					: s.Substring(i + 1, s.Length - 1);
				permutations.AddRange(GetPermutations(s1).Select(x => s.Substring(i, 1) + x));
			}
			return permutations;
		}

		private static List<string> Better(string s) => $"{s}".Length < 2
			? new List<string> { s }
			: SinglePermutations(s.Substring(1))
				.SelectMany(x => Enumerable.Range(0, x.Length + 1)
					.Select((_, i) => x.Substring(0, i) + s[0] + x.Substring(i)))
				.Distinct()
				.ToList();
	}
}
