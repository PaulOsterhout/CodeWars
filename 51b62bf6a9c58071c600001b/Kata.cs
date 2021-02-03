using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata_51b62bf6a9c58071c600001b
{
	public class RomanConvert
	{
		public static string Solution(int n)
		{
			Dictionary<int, string> RomanNumerals = new Dictionary<int, string>
			{
				{ 1, "I" },
				{ 4, "IV" },
				{ 5, "V" },
				{ 9, "IX" },
				{ 10, "X" },
				{ 40, "XL" },
				{ 50, "L" },
				{ 90, "XC" },
				{ 100, "C" },
				{ 400, "CD" },
				{ 500, "D" },
				{ 900, "CM" },
				{ 1000, "M" },
			};
			System.Text.StringBuilder builder = new System.Text.StringBuilder();
			int maxKey = RomanNumerals.Keys.Max();
			while (n > 0)
			{
				int key = RomanNumerals.Keys.Where(x => x <= n).Max();
				builder.Append(RomanNumerals[key]);
				n -= key;
			}
			return builder.ToString();
		}
	}
}