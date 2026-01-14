using System;

class Program
{
    static bool FreeSquare(long n)
    {
        if (n <= 1)
            return n == 1;

        for (long i = 2; i * i <= n; i++)
        {
            if (n % (i * i) == 0)
            {
                return false;
            }
        }
        return true;
    }

    static long CountSquareFree(long n)
    {
        long count = 0;

        for (long m = 1; m < n; m++)
        {
            if (FreeSquare(m * m + 1))
            {
                count++;
            }
        }

        return count;
    }

    static void Main()
    {
        long n = 1000000;
        Console.WriteLine($"Вычисляю C({n})");
        long result = CountSquareFree(n);
        Console.WriteLine($"C({n}) = {result}");
        Console.WriteLine();

        Console.WriteLine("Проверка известных значений:");
        Console.WriteLine($"C(10) = {CountSquareFree(10)} (ожидается 8)");
        Console.WriteLine($"C(1000) = {CountSquareFree(1000)} (ожидается 894)");
        Console.WriteLine();

        Console.WriteLine("Примеры проверки:");
        Console.WriteLine($"1^2 + 1 = 2, square-free: {FreeSquare(2)}");
        Console.WriteLine($"5^2 + 1 = 26, square-free: {FreeSquare(26)}");
        Console.WriteLine($"7^2 + 1 = 50, square-free: {FreeSquare(50)}");
        Console.WriteLine();

        Console.WriteLine("Интерактивная проверка");
        while (true)
        {
            Console.Write("Введите n для вычисления C(n)");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || input.ToLower() == "exit")
                break;

            if (long.TryParse(input, out long testN))
            {
                if (testN > 0 && testN <= 10000000)
                {
                    Console.WriteLine($"Вычисляю C({testN})...");
                    long testResult = CountSquareFree(testN);
                    Console.WriteLine($"C({testN}) = {testResult}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Введите число от 1 до 10000000");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод!");
                Console.WriteLine();
            }
        }

        Console.WriteLine("Программа завершена.");
        Console.ReadKey();
    }
}
