using System;
using System.Linq;

namespace ex4
{
    public static class ArrayFuncs
    {
        public static void PomenyatGrupi(ref int[] arr, int a, int b, int a1, int b1)
        {
            var list = arr.ToList();
            list.Reverse(a, b - a + 1);
            list.Reverse(b + 1, a1 - b - 1);
            list.Reverse(a1, b1 - a1 + 1);
            list.Reverse(a, b1 - a + 1);
            arr = list.ToArray();
        }
        public static void PomenyatSosednie(ref int[] arr)
        {
            if (arr.Length % 2 == 0)
                for (int i = 0; i < arr.Length; i += 2)
                {
                    int elem = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = elem;
                }
            else
                for (int i = 0; i < arr.Length - 1; i += 2)
                {
                    int elem = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = elem;
                }
        } 
        public static void MasivVMasiv(ref int[] inArr, int[] pastedArr, int a)
        {
            Array.Resize(ref inArr, inArr.Length + pastedArr.Length);
            Array.Copy(inArr, a, inArr, a + pastedArr.Length, inArr.Length - 2 * pastedArr.Length);
            Array.Copy(pastedArr, 0, inArr, a, pastedArr.Length);
        }
        public static void MasivVmestoGrupi(ref int[] inArr, int[] pastedArr, int a)
        {
            Array.Copy(pastedArr, 0, inArr, a, pastedArr.Length);
            System.Console.WriteLine();
        }
        public static void Print(int[] arr)
        {
            foreach (int elem in arr)
                System.Console.Write(elem + " ");
            System.Console.WriteLine();
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr  = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int[] arr1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int[] arr2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int[] arr3 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int[] arr4 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int[] arr5 = { 99, 66 };
            ArrayFuncs.PomenyatGrupi(ref arr1, 1, 2, 5, 7);
            ArrayFuncs.PomenyatSosednie(ref arr2);
            ArrayFuncs.MasivVMasiv(ref arr3, arr5, 2);
            ArrayFuncs.MasivVmestoGrupi(ref arr4, arr5, 4);
            Console.WriteLine("Исходный массив:");
            ArrayFuncs.Print(arr);
            Console.WriteLine("обмiн мiсцями двох груп елементiв:");
            ArrayFuncs.Print(arr1);
            Console.WriteLine("обмiн мiсцями усiх пар сусiднiх елементiв:");
            ArrayFuncs.Print(arr2);
            Console.WriteLine("вставлення у масив iншого масиву елементiв у вказане мiсце:");
            ArrayFuncs.Print(arr3);
            Console.WriteLine("замiна групи елементiв iншим масивом елементiв:");
            ArrayFuncs.Print(arr4);
        }
    }
}

