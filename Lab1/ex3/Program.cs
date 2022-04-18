using System;

namespace ex3
{
    class Program
    {
        static double? Reciprocal(double x)
        {
            if (x < 0) return null;
            return Math.Sqrt(x);
        }

        static void Main(string[] args)
        {
            Console.Write("Уведiть x: ");
            double x = double.Parse(Console.ReadLine());
            double? y = Reciprocal(x);
            if (y == null)
                Console.WriteLine("Помилка");
            else
                Console.WriteLine(y);
        }
    }
}