using System.Linq;

namespace CodeWars.Kata_550554fd08b86f84fe000a58
{
	public class WhichAreIn
	{
		public static string[] inArray(string[] array1, string[] array2)
		{
			return array1.Where(x => array2.Any(y => y.Contains(x))).OrderBy(x => x).ToArray();
		}
	}
}