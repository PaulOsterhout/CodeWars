using System.Collections.Generic;

namespace CodeWars.Kata_515de9ae9dcfc28eb6000001
{
	public class SplitString
	{
		public static string[] Solution(string str)
		{
			List<string> solution = new List<string>();
			while (str.Length > 0)
			{
				int length = str.Length > 1 ? 2 : 1;
				string item = length == 2 ? str.Substring(0, 2) : str + '_';
				solution.Add(item);
				str = str.Substring(length);
			}
			return solution.ToArray();
		}
	}
}