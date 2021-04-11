using System.Collections.Generic;

namespace CodeWars.Kata_51ba717bb08c1cd60f00002f
{
	public class RangeExtraction
	{
		public static string Extract(int[] args)
		{
			int first = args[0];
			int last = first;
			List<string> range = new List<string>();
			for (int index = 1; index < args.Length; index++)
			{
				int current = args[index];
				if (current == last + 1)
				{
					last = current;
				}
				else
				{
					range.Add((first != last) && (last > first + 1) ? $"{first}-{last}" : (first == last) ? $"{first}" : $"{first},{last}");
					first = current;
					last = current;
				}
			}
			range.Add((first != last) && (last > first + 1) ? $"{first}-{last}" : (first == last) ? $"{first}" : $"{first},{last}");
			return string.Join(',', range);
		}
	}
}
