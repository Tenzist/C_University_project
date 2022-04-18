using System;

namespace ex5
{
    class vector
    {
        private double[] vec;

        public vector(double[] vec)
        {
            this.vec = vec;
        }

        public static vector operator +(vector a, vector b)
        {
            double[] arr = new double[a.vec.Length];
            for (int i = 0; i < a.vec.Length; i++) arr[i] = a.vec[i] + b.vec[i];
            return new vector(arr);
        }

        public static vector operator -(vector a, vector b)
        {
            double[] arr = new double[a.vec.Length];
            for (int i = 0; i < a.vec.Length; i++) arr[i] = a.vec[i] - b.vec[i];
            return new vector(arr);
        }

        public static vector operator *(vector a, double g)
        {
            double[] arr = new double[a.vec.Length];
            for (int i = 0; i < a.vec.Length; i++) arr[i] = a.vec[i] * g;
            return new vector(arr);
        }

        public static vector operator /(vector a, double g)
        {
            double[] arr = new double[a.vec.Length];
            for (int i = 0; i < a.vec.Length; i++) arr[i] = a.vec[i] / g;
            return new vector(arr);
        }

        public static vector operator *(vector a, vector b)
        {
            double[] arr = new double[a.vec.Length];
            for (int i = 0; i < a.vec.Length; i++) arr[i] = a.vec[i] * b.vec[i];
            return new vector(arr);
        }

        public static implicit operator string(vector c)
        {
            string res = "";
            for (int i = 0; i < c.vec.Length; i++) res += c.vec[i] + " ";
            return res;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double[] arr1 = {1, 3, 5};
            double[] arr2 = {2, 4, 6};
            vector a = new vector(arr1);
            vector b = new vector(arr2);
            vector c;

            Console.WriteLine("Сумма векторов: ");
            c = a + b;
            Console.WriteLine(c);

            Console.WriteLine("Разность векторов: ");
            c = a - b;
            Console.WriteLine(c);

            Console.WriteLine("Умножение вектора на скаляр: ");
            c = a * 5;
            Console.WriteLine(c);

            Console.WriteLine("Деление вектора на скаляр: ");
            c = a / 2;
            Console.WriteLine(c);

            Console.WriteLine("Скалярное произведение векторов: ");
            c = a * b;
            Console.WriteLine(c);
        }
    }
}