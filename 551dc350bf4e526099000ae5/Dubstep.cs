using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata_551dc350bf4e526099000ae5
{
    public static class Dubstep
    {
        public static string SongDecoder(string input)
        {
            List<string> words = input.Split("WUB").ToList();
            words.RemoveAll(x => string.IsNullOrEmpty(x));
            return string.Join(' ', words);
        }
    }
}