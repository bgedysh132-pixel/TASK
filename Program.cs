using System;

class Program
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Автор: Александр Сергеевич Пушкин\n");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Название: Я помню чудное мгновенье\n");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Я помню чудное мгновенье:");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Передо мной явилась ты,");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Как мимолётное виденье,");
        Console.ForegroundColor = ConsoleColor.Purple;
        Console.WriteLine("Как гений чистой красоты..");

        Console.ResetColor();

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}