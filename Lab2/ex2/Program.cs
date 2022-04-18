using System;

namespace Lab2
{
    public static class DoubleExt
    {
        public static string RemSpace(this string a)
        {
            for (int i = 0; i < a.Length; i++ )
                if (a[i] == ' ')
                    a = a.Replace("  ", " ");   
            return a;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine().RemSpace();
            Console.WriteLine(s);
        }
    }
}