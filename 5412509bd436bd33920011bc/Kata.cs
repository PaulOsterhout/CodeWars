namespace CodeWars.Kata_5412509bd436bd33920011bc
{
    public static class Kata
    {
        public static string Maskify(string cc)
        {
            return (cc.Length < 5)
                ? cc
                : ("").PadLeft(cc.Length - 4, '#') + cc.Substring(cc.Length - 4, 4);
        }
    }
}