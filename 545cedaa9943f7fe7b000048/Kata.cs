using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata_545cedaa9943f7fe7b000048
{
	public static class Kata
	{
		public static bool IsPangram(string str)
		{
			List<char> letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray().ToList();
			foreach (char letter in str)
			{
				letters.Remove(letter.ToString().ToLower()[0]);
			}
			return letters.Count == 0;
		}
	}
}