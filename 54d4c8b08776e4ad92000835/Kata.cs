using System;

namespace CodeWars.Kata_54d4c8b08776e4ad92000835
{
	public class PerfectPower
	{
		public static (int, int)? IsPerfectPower(int n)
		{
			int limit = (int)Math.Sqrt(n);
			for (int integer = 2; integer <= limit; integer++)
			{
				int power = 1;
				while (Math.Pow(integer, power) <= n)
				{
					power++;
					if (Math.Pow(integer, power) == n)
					{
						return (integer, power);
					}
				}
			}
			return null;
		}
	}
}
