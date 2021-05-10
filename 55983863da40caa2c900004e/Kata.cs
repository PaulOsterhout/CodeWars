using System.Linq;

namespace CodeWars.Kata_55983863da40caa2c900004e
{
	public class Kata
	{
		public static long NextBiggerNumber(long n)
		{
			long next = -1;
			string str = n.ToString();
			for (int i = str.Length - 2; i >= 0; i--)
			{
				string prefix = str.Substring(0, i);
				char current = str[i];
				char[] possible = str.Substring(i + 1, str.Length - i - 1).Where(x => x > current).ToArray();
				if (possible.Length > 0)
				{
					char middle = possible.Min();
					string postfix = string.Concat(str.Substring(i, str.Length - i).OrderBy(x => x));
					postfix = postfix.Remove(postfix.IndexOf(middle), 1);
					long bigger = long.Parse(prefix + middle + postfix);
					if (bigger > n)
					{
						next = bigger;
						break;
					}
				}
			}
			return next;
		}
	}
}
