using System.Linq;
using System.Text.RegularExpressions;

namespace CodeWars.Kata_55f8a9c06c018a0d6e000132
{
    public class Kata
    {
        public static bool ValidatePin(string pin)
        {
            int[] validLengths = { 4, 6 };
            return Regex.IsMatch(pin, @"^(\d{4}|\d{6})$") && validLengths.Any(x => x == pin.Length);
        }
    }
}