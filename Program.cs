using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите четырёхзначное число: ");
        int n = int.Parse(Console.ReadLine());

        if (n < 1000 || n > 9999)
        {
            Console.WriteLine("Ошибка: нужно ввести именно четырёхзначное число.");
            return;
        }

        int d1 = n / 1000;
        int d2 = (n / 100) % 10;
        int d3 = (n / 10) % 10;
        int d4 = n % 10;

        int x = d2 * 1000 + d1 * 100 + d4 * 10 + d3;

        Console.WriteLine("Результат: " + x);
    }
}
//p