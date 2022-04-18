using System;

namespace ex5
{
    class Program
    {
        static double X(double a = 1, double x = 1, double b = 1)
        {
            return a * x * b;
        }

        static void Main(string[] args)
        {
            double a = 5;
            double b = 2;
            double c = 7;
            Console.WriteLine(1);
            Console.WriteLine(X(a));
            Console.WriteLine(X(b));
            Console.WriteLine(X(c));
            Console.WriteLine(X(c, a, b));
        }
    }
}