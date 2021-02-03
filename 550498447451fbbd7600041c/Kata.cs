using System.Linq;

namespace CodeWars.Kata_550498447451fbbd7600041c
{
	public class Kata
	{
		public static bool comp(int[] a, int[] b)
		{
			if ((a == null) || (b == null)) return false;
			if (a.Length != b.Length) return false;
			int[] aInOrder = a.OrderBy(x => x).ToArray();
			int[] bInOrder = b.OrderBy(x => x).ToArray();
			for (int i = 0; i < a.Length; i++)
			{
				if (aInOrder[i] * aInOrder[i] != bInOrder[i]) return false;
			}
			return true;
		}
	}
}