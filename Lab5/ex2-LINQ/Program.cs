using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ex2_LINQ
{
    public static class ListsWithLINQ
    {
        public static IEnumerable<double> SquaresInRange(this List<double> list)
        {
            return from x in list
                where Math.Sqrt(x) == (int)Math.Sqrt(x)
                select x;
        }

        public static List<double> SortBySines(this List<double> list)
        {
            return new List<double>(from x in list
                orderby Math.Abs(x) descending
                select x);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<double> list = new List<double> { 1, -2, 4, 3, 9, -64, 5, 81 };
            Console.WriteLine("Squares of numbers:");
            foreach (double x in list.SquaresInRange())
                Console.WriteLine("\t" + x);
            Console.WriteLine("\n");
            Console.WriteLine("Sort by decreasing values:");
            list = list.SortBySines();
            foreach (double x in list)
                Console.WriteLine("\t" + Math.Abs(x));
        }
    }
}