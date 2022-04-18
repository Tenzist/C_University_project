using System;
using System.Net;

namespace ex4
{
    class Program
    {
        public static void Solve(double a, double b, double c, out double x1, out double x2)
        {
            double d = b * b - 4 * a * c;
            if (d < 0)
            {
                Console.WriteLine("Дискриминант < 0");
            }

            x1 = (-b - Math.Sqrt(d)) / (2 * a);
            x2 = (-b + Math.Sqrt(d)) / (2 * a);
        }

        static void Main(string[] args)
        {
            double a = int.Parse(Console.ReadLine());
            double b = int.Parse(Console.ReadLine());
            double c = int.Parse(Console.ReadLine());
            double x1, x2;
            if (a == 0)
            {
                Console.WriteLine("'a' не должно = 0");
            }
            else
            {
                Solve(a, b, c, out x1, out x2);
                Console.WriteLine($"x1 = {x1}; x2 = {x2}");
            }
        }
    }
}