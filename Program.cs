using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите радиус окружности: ");
        double R = double.Parse(Console.ReadLine());

        double squareArea = 2 * R * R;

        double triangleArea = (3 * Math.Sqrt(3) / 4) * R * R;
        //p

        Console.WriteLine($"Площадь вписанного квадрата: {squareArea:F2}");
        Console.WriteLine($"Площадь вписанного правильного треугольника: {triangleArea:F2}");
    }
}