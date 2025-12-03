using System;

namespace Task10_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число a (1 < a < 1.25):");
            double a = double.Parse(Console.ReadLine());

            int n = 0;
            double sum = 0.0;
            double term = 1.0;       

            while (sum <= a)        
            {
                sum += term;
                n++;
                term /= 5.0;       
            }

            Console.WriteLine($"Наименьшая сумма S_n > a равна {sum}, при n = {n}");
        }
    }
}
