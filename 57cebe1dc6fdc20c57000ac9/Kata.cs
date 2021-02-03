using System.Linq;

namespace CodeWars.Kata_57cebe1dc6fdc20c57000ac9
{
	public class Kata
	{
		public static int FindShort(string s)
		{
			return s.Split(' ').Min(x => x.Length);
		}
	}
}