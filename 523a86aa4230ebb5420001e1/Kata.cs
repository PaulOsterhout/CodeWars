using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata_523a86aa4230ebb5420001e1
{
	public static class Kata
	{
		private static string OrderedWord(string word)
		{
			return string.Join('~', word.OrderBy(x => x)).Replace("~", "");
		}

		public static List<string> Anagrams(string word, List<string> words)
		{
			string compareValue = OrderedWord(word);
			List<string> anagrams = new List<string>();
			foreach (string testWord in words)
			{
				if (OrderedWord(testWord) == compareValue) anagrams.Add(testWord);
			}
			return anagrams;
		}
	}
}