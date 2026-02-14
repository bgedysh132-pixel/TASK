using System;

class Program
{
    static void Main()
    {

        Console.Write("Введите значение x: ");

        double x = double.Parse(Console.ReadLine());

        double result = y(x);

        Console.WriteLine($"f({x}) = {result}");
    }

    static double y(double x)
    {
        double sinx = Math.Sin(x);
        double sin2x = Math.Sin(2 * x);
        double sin3x = Math.Sin(3 * x);
        double sin4x = Math.Sin(4 * x);

        double a = sinx - sin2x - sin3x - sin4x;


        double result = Math.Sqrt(a);

        return result;
    }
}
//p