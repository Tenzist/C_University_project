using System;
using System.Collections.Generic;

namespace ex2
{
    public static class ListsWithLambda
    {
        public static IEnumerable<double> SquaresInRange(this List<double> list)
        {
            return list.FindAll(x => Math.Sqrt(x) == (int)Math.Sqrt(x));
        }

        public static void SortBySines(this List<double> list)
        {
            list.Sort((d1, d2) => -Math.Abs(d1).CompareTo(Math.Abs(d2)));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<double> list = new List<double> { 1, 7, 4, -9, 16, -65, 25, -64, 98 };
            Console.WriteLine("Squares of numbers:");
            foreach (double x in list.SquaresInRange())
                Console.WriteLine("\t" + x);
            Console.WriteLine("\n");
            Console.WriteLine("Sort by decreasing values:");
            list.SortBySines();            
            foreach (double x in list)
                Console.WriteLine("\t" + Math.Abs(x));
        }
    }
}