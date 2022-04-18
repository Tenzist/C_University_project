using System;
using System.Collections.Generic;

namespace ex5
{
    public class ArrayContainer<T>
    {
        int from;
        private T[] arr;
 
        public ArrayContainer(int from, params T[] arr)
        {
            this.from = from;
            this.arr = new T[arr.Length];
            Array.Copy(arr, this.arr, arr.Length);
        }
        public ArrayContainer(int from, int to)
        {
            this.arr = new T[to - (this.from = from)];
        }
        public T this[int index]
        {
            set { arr[index - from] = value; }
            get { return arr[index - from]; }
        }
        public int From { get { return from; } }
        public int To { get { return arr.Length + from; } }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T i in arr)
                yield return i;
        }

        public void Add(T elem)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = elem;
        }

        
        public void RemoveLast()
        {
            if (arr.Length > 0)
                Array.Resize(ref arr, arr.Length - 1);
        }

        public static implicit operator string(ArrayContainer<T> a)
        {
            string res = "";
            foreach (T i in a.arr)
                res += i + " ";
            return res;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ArrayContainer<int> a = new ArrayContainer<int>(10, 1, 2, 3, 4);
            for (int i = 10; i < a.To; i++)
                a[i] += 2;
            Console.WriteLine ( a );
            a.Add(38);
            Console.WriteLine( a );
            a.RemoveLast();
            Console.WriteLine( a );
            foreach (int i in a)
                Console.Write(i + " ");
            Console.WriteLine();
        }
    }
}