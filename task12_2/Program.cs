using System;

class Program
{
    static void PrintRowsSquaresSum(int[,] a)
    {
        int rows = a.GetLength(0);
        int cols = a.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            int sumSquares = 0;

            for (int j = 0; j < cols; j++)
            {
                int value = a[i, j];
                sumSquares += value * value;
            }

            Console.WriteLine($"Строка {i}: сумма квадратов = {sumSquares}");
        }
    }

    static void Main()
    {
        int[,] arr =
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        PrintRowsSquaresSum(arr);
    }
}
