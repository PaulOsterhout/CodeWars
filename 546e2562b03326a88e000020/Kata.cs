namespace CodeWars.Kata_546e2562b03326a88e000020
{
	public class Kata
	{
		public static int SquareDigits(int n)
		{
			System.Text.StringBuilder builder = new System.Text.StringBuilder();
			foreach (char c in n.ToString())
			{
				int i = int.Parse(c.ToString());
				builder.Append($"{i * i}");
			}
			return int.Parse(builder.ToString());
		}
	}
}