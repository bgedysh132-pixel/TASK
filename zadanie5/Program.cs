using System;

class Program
{
    static double y(double a, double b)
    {
        return Math.Tan((1 + Math.Sqrt(a)) / b);
    }

    static void Main()
    {
        double x = y(3, 2) * y(2, 4) * y(7, 5);

        Console.WriteLine($"x = {x:F3}");
        //o
    }
}
