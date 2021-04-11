using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata_52423db9add6f6fc39000354
{
	public class ConwayLife
	{
		internal static int[,] GetGeneration(int[,] cells, int generation)
		{
			int originalSize = cells.GetLength(0);
			int size = originalSize + (generation * 2);
			// Create Blank Matrix
			List<List<int>> blank = new List<List<int>>();
			for (int i = 0; i < size; i++)
			{
				int[] item = new int[size];
				blank.Add(item.ToList());
			}
			// Copy Original Cells into Starting Matriz
			List<List<int>> current = new List<List<int>>(blank);
			for (int x = 0; x < originalSize; x++)
			{
				for (int y = 0; y < originalSize; y++)
				{
					current[x + generation][y + generation] = cells[x,y];
				}
			}
			// Compute Generations
			for (int gen = 1; gen <= generation; gen++)
			{
				List<List<int>> next = new List<List<int>>(blank);
				for (int x = 0; x < size; x++)
				{
					for (int y = 0; y < size; y++)
					{
						int minX = Math.Max(x - 1, 0);
						int maxX = Math.Min(size - 1, x + 1);
						int minY = Math.Max(y - 1, 0);
						int maxY = Math.Min(size - 1, y + 1);
						int liveCount = 0;
						for (int x1 = minX; x1 <= maxX; x1++)
						{
							for (int y1 = minY; y1 <= maxY; y1++)
							{
								liveCount += current[x1][y1];
							}
						}
						liveCount -= current[x][y];
						next[x][y] = current[x][y] == 0 ? (liveCount == 3 ? 1 : 0) : (liveCount == 2 || liveCount == 3 ? 1 : 0);
					}
				}
				current = next;
			}
			// Copy Matrix into Result Array
			int[,] result = new int[size, size];
			for (int x = 0; x < size; x++)
			{
				for (int y = 0; y < size; y++)
				{
					result[x,y] = current[x][y];
				}
			}
			return result;
		}

		// internal static int[,] GetGeneration(int[,] cells, int generation)
		// {
		// 	int cellsLength = cells.GetLength(0);
		// 	int size = cellsLength + (generation * 2);
		// 	int[,] newCells = new int[size,size];
		// 	for (int x = 0; x < cellsLength; x++)
		// 	{
		// 		for (int y = 0; y < cellsLength; y++)
		// 		{
		// 			newCells[x + generation,y+generation] = cells[x,y];
		// 		}
		// 	}
		// 	for (int gen = 1; gen <= generation; gen++)
		// 	{
		// 		int[,] next = new int[size,size];
		// 		for (int x = 0; x < size; x++)
		// 		{
		// 			for (int y = 0; y < size; y++)
		// 			{
		// 				int liveCount = GetLiveCount(newCells, size, x, y);
		// 				next[x,y] = newCells[x,y] == 0 ? (liveCount == 3 ? 1 : 0) : (liveCount == 2 || liveCount == 3 ? 1 : 0);
		// 			}
		// 		}
		// 		newCells = next;
		// 	}
		// 	int x1 = 0;
		// 	while (newCells[x1].Sum() == 0)
		// 	{
		// 		x1++;
		// 	}
		// 	return newCells;
		// }

		// private static int GetLiveCount(int[,] cells, int size, int x, int y)
		// {
		// 	List<int> xValues = new List<int>() { x - 1, x, x + 1 };
		// 	List<int> yValues = new List<int>() { y - 1, y, y + 1 };
		// 	xValues.RemoveAll(x2 => x2 < 0 || x2 >= size);
		// 	yValues.RemoveAll(y2 => y2 < 0 || y2 >= size);
		// 	int liveCount = cells[x,y] * -1;
		// 	foreach (int x1 in xValues)
		// 	{
		// 		foreach (int y1 in yValues)
		// 		{
		// 			liveCount += cells[x1,y1];
		// 		}
		// 	}
		// 	return liveCount;
		// }
	}
}
