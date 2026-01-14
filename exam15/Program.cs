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
        long result = CountSquareFree(n);

        Console.WriteLine($"C({n}) = {result}");

        Console.WriteLine($"C(10) = {CountSquareFree(10)}");
        Console.WriteLine($"C(1000) = {CountSquareFree(1000)}");

        Console.WriteLine("Примеры проверки:");
        Console.WriteLine($"1^2 + 1 = 2, square-free: {FreeSquare(2)}");
        Console.WriteLine($"5^2 + 1 = 26, square-free: {FreeSquare(26)}");
        Console.WriteLine($"7^2 + 1 = 50, square-free: {FreeSquare(50)}");
    }
}

