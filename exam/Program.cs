using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите число для проверки:");
        int n = int.Parse(Console.ReadLine());

        if (FreeSquares(n))
        {
            Console.WriteLine($"Число {n} свободно от квадратов");
        }
        else
        {
            Console.WriteLine($"Число {n} НЕ свободно от квадратов");
        }

        Console.WriteLine("Проверка примеров:");
        Console.WriteLine($"C(10) = {CountFreeNumbers(10)}");
        Console.WriteLine($"C(1000) = {CountFreeNumbers(1000)}");
        Console.WriteLine($"C(10^7) = {CountFreeNumbers(10000000)}");
    }

    static bool FreeSquares(int n)
    {
        if (n <= 1)
            return false;

        for (int i = 2; i * i <= n; i++)
        {
            if (n % (i * i) == 0)
            {
                return false;
            }
        }

        return true;
    }

    static int CountFreeNumbers(int limit)
    {
        int count = 0;

        for (int m = 1; m <= limit; m++)
        {
            if (FreeSquares(m))
            {
                count++;
            }
        }

        return count;
        //p
    }
}
