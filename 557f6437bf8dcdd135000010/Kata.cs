namespace CodeWars.Kata_557f6437bf8dcdd135000010
{
	public class Kata
	{
		public static string Factorial(int n)
		{
			return n < 0 ? null : ComputeFactorial(n);
		}

		private static string ComputeFactorial(int n)
		{
			if (n < 2) return "1";
			string factorial = "";
			string current = ComputeFactorial(n - 1);
			int previous = 0;
			for (int index = 0; index < current.Length; index++)
			{
				int digit = int.Parse(current.Substring(current.Length - index - 1, 1));
				int value = digit * n + previous;
				int newDigit = value % 10;
				factorial = $"{newDigit}{factorial}";
				previous = (value - newDigit) / 10;
			}
			if (previous > 0) factorial = $"{previous}{factorial}";
			return factorial;
		}
	}
}
