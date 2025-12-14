using System;

class Program
{
    static void FindRowWithFirstMax(int[,] a)
    {
        int rows = a.GetLength(0);
        int cols = a.GetLength(1);
        int index = -1;

        for (int i = 0; i < rows; i++)
        {
            int first = a[i, 0];
            bool isMax = true;

            for (int j = 1; j < cols; j++)
            {
                if (a[i, j] > first)
                {
                    isMax = false;
                    break;
                }
            }

            if (isMax)
            {
                index = i;
                break;      
            }
        }

        if (index != -1)
            Console.WriteLine("Индекс строки: " + index);
        else
            Console.WriteLine("В массиве нет таких строк.");
    }

    static void Main()
    {
        int[,] arr =
        {
            { 5, 3, 1 },
            { 2, 8, 4 },
            { 7, 1, 0 }
        };

        FindRowWithFirstMax(arr);
    }
}

