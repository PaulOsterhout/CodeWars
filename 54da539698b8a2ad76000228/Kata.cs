namespace CodeWars.Kata_54da539698b8a2ad76000228
{
	public class Kata
	{
		public static bool IsValidWalk(string[] walk)
		{
			if (walk.Length != 10) return false;

			int eastPosition = 0;
			int northPosition = 0;

			foreach(string walkDirection in walk)
			{
				switch (walkDirection)
				{
					case "e": eastPosition++; break;
					case "n": northPosition++; break;
					case "s": northPosition--; break;
					case "w": eastPosition--; break;
				}
			}

			return ((eastPosition == 0) && (northPosition == 0));
		}
	}
}