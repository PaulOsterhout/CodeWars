using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata_552c028c030765286c00007d
{
	public class IQ
	{
		public static int Test(string numbers)
		{
			List<int> numbersToTest = numbers.Split(' ').Select(x => int.Parse(x)).ToList();
			int evenCount = numbersToTest.Count(x => x % 2 == 0);
			int modulus = evenCount == 1 ? 0 : 1;
			int differentNumber = numbersToTest.First(x => x % 2 == modulus);
			return numbersToTest.IndexOf(differentNumber) + 1;
		}
	}
}