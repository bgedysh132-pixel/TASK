using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Программа для вычисления функции y = √(sinx - sin2x - sin3x - sin4x)");
        Console.Write("Введите значение x: ");

        double x = double.Parse(Console.ReadLine());

        double result = CalculateFunction(x);

        Console.WriteLine($"f({x}) = {result}");
    }

    static double CalculateFunction(double x)
    {
        double sinx = Math.Sin(x);
        double sin2x = Math.Sin(2 * x);
        double sin3x = Math.Sin(3 * x);
        double sin4x = Math.Sin(4 * x);

        double expression = sinx - sin2x - sin3x - sin4x;

        if (expression < 0)
        {
            Console.WriteLine("Внимание: выражение под корнем отрицательное!!");
            return double.NaN;
        }

        double result = Math.Sqrt(expression);

        return result;
    }
}