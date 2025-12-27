using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Проверка принадлежности точки области");
        
        double[] testX = {0.5, 1.0, 1.5, 2.0, 0.5, 1.0};
        double[] testY = {0.5, 1.0, 0.5, 1.0, 1.5, 1.5};
        
        for (int i = 0; i < testX.Length; i++)
        {
            bool result = IsPointInArea(testX[i], testY[i]);
            Console.WriteLine($"Точка ({testX[i]}, {testY[i]}) -> Принадлежит области: {result}");
        }
        
        Console.WriteLine("\nВведите координаты точки:");
        Console.Write("x = ");
        double x = Convert.ToDouble(Console.ReadLine());
        Console.Write("y = ");
        double y = Convert.ToDouble(Console.ReadLine());
        
        bool inArea = IsPointInArea(x, y);
        Console.WriteLine($"Точка ({x}, {y}) принадлежит области: {inArea}");
    }
    
    static bool IsPointInArea(double x, double y)
    {
        bool inXRange = (x >= 0.5) && (x <= 1.5);
        bool inYRange = y >= 0;
        
        return inXRange && inYRange;
    }
}
