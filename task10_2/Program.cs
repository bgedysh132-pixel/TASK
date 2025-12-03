using System;

namespace TaskRainfall
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите название месяца:");
            string month = Console.ReadLine();      

            Console.WriteLine("Введите количество дней в месяце:");
            int days = int.Parse(Console.ReadLine());

            double sum = 0;

            for (int i = 0; i < days; i++)           
            {
                Console.WriteLine($"Введите осадки за {i + 1}-й день:");
                double rainfall = double.Parse(Console.ReadLine());
                sum += rainfall;
            }

            double average = sum / days;            

            Console.WriteLine(
                $"Среднемесячное количество осадков за {month} равно {average:F2}");
        }
    }
}

