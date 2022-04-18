using System;

namespace ex7
{
    public struct Point
    {
        public double x, y, z ;
        public Point(double x, double y,double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public double Formula(){

            return Math.Sqrt(x*x + y*y + z*z);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point(2,4,1);
            Console.WriteLine(p.Formula());
        }
    }
}