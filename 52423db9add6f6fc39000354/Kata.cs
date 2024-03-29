using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CodeWars.Kata_52423db9add6f6fc39000354
{
	public class ConwayLife
	{
		public static int[,] GetGeneration(int[,] cells, int generation)
		{
			return Better(cells, generation);
		}

		private static int[,] Better(int[,] cells, int generation)
		{
			HashSet<Point> points = Enumerable.Range(0, cells.GetLength(0))
				.SelectMany(y => Enumerable.Range(0, cells.GetLength(1))
				.Select(x => new Point(x,y)))
				.Where(c => cells[c.Y,c.X] > 0)
				.ToHashSet();

			IEnumerable<Point> GetSurroundingPoints(Point point) => Enumerable.Range(-1, 3)
				.SelectMany(y => Enumerable.Range(-1, 3)
				.Select(x => new Point(point.X + x, point.Y + y)));
			int GetValue(Point point) => points.Contains(point) ? 1 : 0;
			int GetSum(Point point) => GetSurroundingPoints(point).Sum(GetValue);

			while (generation-- > 0)
			{
				HashSet<Point> pointsToScan = points.SelectMany(GetSurroundingPoints).ToHashSet();
				points = pointsToScan.Where(point => GetSum(point) == 3 || (GetSum(point) == 4 && GetValue(point) == 1))
					.ToHashSet();
			}

			int minX = points.Min(p => p.X);
			int maxX = points.Max(p => p.X) + 1;
			int minY = points.Min(p => p.Y);
			int maxY = points.Max(p => p.Y) + 1;
			int[,] result = new int[maxY - minY,maxX - minX];
			for (int y = minY; y < maxY; y++) for (int x = minX; x < maxX; x++) result[y - minY,x - minX] = GetValue(new Point(x,y));
			return result;
		}

		private static int[,] Mine(int[,] cells, int generation)
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
				yStart++;
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
				yEnd--;
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
				xStart++;
			}
			for (int x = xEnd; x >= xStart; x--)
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
				xEnd--;
			}
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
