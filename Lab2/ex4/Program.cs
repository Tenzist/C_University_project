using System;

namespace ex4
{
    class Complex
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Complex()
        {
        }

        public Complex(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.X + b.X, a.Y + b.Y);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.X - b.X, a.Y - b.Y);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex((a.X * b.X) - (a.Y * b.Y), (b.X * a.Y) + (a.X * b.Y));
        }

        public static Complex operator /(Complex a, Complex b)
        {
            return new Complex(((a.X * b.X) + (a.Y * b.Y)) / ((b.X * b.X) + (b.Y * b.Y)),
                ((b.X * a.Y) - (a.X * b.Y)) / ((b.X * b.X) + (b.Y * b.Y)));
        }

        public static implicit operator string(Complex p)
        {
            return p.X + " " + p.Y + "i";
        }

        class Program
        {
            static void Main(string[] args)
            {
                Complex p1 = new Complex {X = 6, Y = 6};
                Complex p2 = new Complex {X = 3, Y = 4};
                Complex p3 = p1 + p2;
                Complex p4 = p1 * p2;
                Complex p5 = p1 - p2;
                Complex p6 = p1 / p2;
                Console.WriteLine(p5);
                Console.WriteLine(p4);
                Console.WriteLine(p3);
                Console.WriteLine(p6);
            }
        }
    }
}