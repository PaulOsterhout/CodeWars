using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata_550f22f4d758534c1100025a
{
	public class DirReduction
	{
		public static string[] dirReduc(string[] arr)
		{
			List<string> directions = new List<string>(arr);

			List<List<string>> removalSequences = new List<List<string>>
			{
				new List<string> { "EAST", "WEST" },
				new List<string> { "NORTH", "SOUTH" },
				new List<string> { "SOUTH", "NORTH" },
				new List<string> { "WEST", "EAST" }
			};

			int index = 0;

			while (index <= directions.Count - 2)
			{
				while ((directions.Count > 1) && (removalSequences.Any(x => directions.GetRange(index, 2).SequenceEqual(x))))
				{
					directions.RemoveRange(index, 2);
					index = 0;
				}
				index++;
			}

			return directions.ToArray();
		}
	}
}
