using System;

namespace Task10_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите натуральное число n:");
            long n = long.Parse(Console.ReadLine());      

            Console.WriteLine("Введите цифру k (0–9), которую нужно удалить:");
            int k = int.Parse(Console.ReadLine());

            long resultReversed = 0;
            long pow10 = 1;

            while (n > 0)
            {
                int digit = (int)(n % 10);

                if (digit != k)                
                {
                    resultReversed += digit * pow10;
                    pow10 *= 10;
                }

                n /= 10;
            }

            Console.WriteLine($"Результат после удаления цифр {k}: {resultReversed}");
        }
    }
}
