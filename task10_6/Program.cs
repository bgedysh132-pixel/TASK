using System;

namespace task10_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите a:");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите b:");
            int b = int.Parse(Console.ReadLine());

            int bestNumber = a;
            int maxDivisors = 0;

            for (int n = a; n <= b; n++)                 
            {
                int count = 0;

                for (int d = 1; d <= n; d++)
                {
                    if (n % d == 0)
                        count++;
                }

                if (count > maxDivisors)
                {
                    maxDivisors = count;
                    bestNumber = n;
                }
            }

            Console.WriteLine(
                $"Минимальное число с максимальным количеством делителей на отрезке [{a}; {b}] — {bestNumber} (делителей: {maxDivisors}).");
        }
    }
}
