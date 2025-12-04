using System;

namespace Task10_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите последовательность целых чисел, оканчивающуюся 0:");

            int signChanges = 0;
            int? prev = null;   

            while (true)
            {
                int x = int.Parse(Console.ReadLine());

                if (x == 0)          
                    break;

                if (prev.HasValue)
                {
                   
                    if (prev.Value * x < 0)   
                        signChanges++;
                }

                prev = x;
            }

            Console.WriteLine($"Знак меняется {signChanges} раз(а).");
            //p
        }
    }
}
