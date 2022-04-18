using System;
using System.Text;
using System.IO;

namespace ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите максимальное количество символов в строке: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Результирующие строки"); 
            using (StreamReader reader = new StreamReader("input.txt", Encoding.Default))
            {
                using (StreamWriter writer = new StreamWriter("output.txt"))
                {
                    string s;
                    while ((s = reader.ReadLine()) != null)
                        if (s.Length <= n)
                        {
                            writer.WriteLine(s);
                            Console.WriteLine(s);
                        }
                }
            }
        }
    }
}