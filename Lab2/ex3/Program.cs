using System;

namespace ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            int recurs(int n)
            {
                if (n == 0 || n == 1) return n;

                return recurs(n - 2) + recurs(n - 1);
            }
            static int loop(int n)
            {
                int result = 0;
                int b = 1;
                int tmp;
 
                for (int i = 0; i < n; i++)
                {
                    tmp = result;
                    result = b;
                    b += tmp;
                }
 
                return result;
            }

            int a = recurs(4);
            int b = recurs(8);
            int c = loop(5);
            int d = loop(9);

            Console.WriteLine("rec Фибоначчи = " + a);
            Console.WriteLine("rec Фибоначчи = " + b);
            Console.WriteLine("loop Фибоначчи = " + c);
            Console.WriteLine("loop Фибоначчи = " + d);
        }
    }
}