using System;

class Program
{
    static double F(double x)
    {
        double value = Math.Sin(x) * Math.Sin(2 * x) * Math.Sin(3 * x) * Math.Sin(4 * x);

        if (value < 0)
        {
            Console.WriteLine("Подкоренное выражение отрицательное!");
            return double.NaN;
        }

        return Math.Sqrt(value);
    }

    static void Main()
    {
        Console.Write("Введите значение x: ");
        double x = Convert.ToDouble(Console.ReadLine());

        double result = F(x);

        Console.WriteLine("f(x) = " + result);
    }
}