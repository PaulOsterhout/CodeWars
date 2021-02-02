using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata_54e6533c92449cc251001667
{
	public static class Kata
	{
		public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
		{
			if (iterable.Count() == 0) return iterable;
			T last = iterable.FirstOrDefault();
			List<T> result = new List<T>();
			result.Add(last);
			foreach (T item in iterable)
			{
				if (!last.Equals(item))
				{
					result.Add(item);
				}
				last = item;
			}
			return result;
		}
	}
}