using System;

namespace ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            String x = Console.ReadLine();
            double y;
            switch (x)
            {
                case "yes":
                    y = 20;
                    break;
                case "no":
                    y = 100;
                    break;
                default:
                    y = 0.5;
                    break;
            }

            Console.WriteLine(y);
        }
    }
}