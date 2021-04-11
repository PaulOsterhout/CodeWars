using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata_52423db9add6f6fc39000354
{
	public class ConwayLife
	{
		public static int[,] GetGeneration(int[,] cells, int generation)
		{
			for (int index = 0; index < generation; index++)
			{
				cells = Live(cells);
			}
			return Trim(cells);
		}

		private static int[,] Live(int[,] cells)
		{
			int xLength = cells.GetLength(0) + 2;
			int yLength = cells.GetLength(1) + 2;
			int[,] liveCells = new int[xLength, yLength];
			for (int x = 0; x < xLength; x++)
			{
				for (int y = 0; y < yLength; y++)
				{
					int liveCount = GetLiveCount(cells, x - 1, y - 1, xLength - 2, yLength - 2);
					int current = GetCellValue(cells, x - 1, y - 1, xLength - 2, yLength - 2);
					liveCells[x, y] = current == 0 ? (liveCount == 3 ? 1 : 0) : ((liveCount == 2) || (liveCount == 3) ? 1 : 0);
				}
			}
			return liveCells;
		}

		private static int GetLiveCount(int[,] cells, int xCell, int yCell, int xLength, int yLength)
		{
			int liveCount = 0;
			for (int x = xCell - 1; x <= xCell + 1; x++)
			{
				for (int y = yCell - 1; y <= yCell + 1; y++)
				{
					liveCount += GetCellValue(cells, x, y, xLength, yLength);
				}
			}
			return liveCount - GetCellValue(cells, xCell, yCell, xLength, yLength);
		}

		private static int GetCellValue(int[,] cells, int x, int y, int xLength, int yLength)
		{
			if ((x < 0) || (y < 0)) return 0;
			if ((x >= xLength) || (y >= yLength)) return 0;
			return cells[x, y];
		}

		private static int[,] Trim(int[,] cells)
		{
			int xStart = 0;
			int xEnd = cells.GetLength(0) - 1;
			int yLength = cells.GetLength(1);
			int yStart = 0;
			int yEnd = yLength - 1;
			for (int y = 0; y < yLength; y++)
			{
				bool empty = true;
				for (int x = xStart; x <= xEnd; x++)
				{
					if (cells[x, y] == 1)
					{
						empty = false;
						break;
					}
				}
				if (!empty) break;
				xStart++;
			}
			for (int y = yLength - 1; y >= 0; y--)
			{
				bool empty = true;
				for (int x = xStart; x <= xEnd; x++)
				{
					if (cells[x, y] == 1)
					{
						empty = false;
						break;
					}
				}
				if (!empty) break;
				xEnd--;
			}
			int xLength = xEnd - xStart + 1;
			for (int x = xStart; x < xLength; x++)
			{
				bool empty = true;
				for (int y = yStart; y <= yEnd; y++)
				{
					if (cells[x, y] == 1)
					{
						empty = false;
						break;
					}
				}
				if (!empty) break;
				yStart++;
			}
			// for (int x = xEnd; x >= xStart; x--)
			// {
			// 	bool empty = true;
			// 	for (int y = yStart; y <= yEnd; y++)
			// 	{
			// 		if (cells[x, y] == 1)
			// 		{
			// 			empty = false;
			// 			break;
			// 		}
			// 	}
			// 	if (!empty) break;
			// 	yEnd--;
			// }
			int[,] trimmedCells = new int[xEnd - xStart + 1, yEnd - yStart + 1];
			for (int x = xStart; x <= xEnd; x++)
			{
				for (int y = yStart; y <= yEnd; y++)
				{
					trimmedCells[x - xStart, y - yStart] = cells[x, y];
				}
			}
			return trimmedCells;
		}
	}
}
