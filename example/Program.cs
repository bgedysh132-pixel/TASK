using System;

class Program
{
    static void Main()
    {
        char letter = 'A'; //переменные
        char digit = '5';
        char symbol = '!';

        Console.WriteLine($"Символ '{letter}' имеет код: {(int)letter}"); //получение кода символа

        char newChar = (char)66;
        Console.WriteLine($"Код 66 = символ '{newChar}'"); //код в символ

        Console.WriteLine($"\n'{letter}' - буква? {Char.IsLetter(letter)}"); //методы проверки
        Console.WriteLine($"'{digit}' - цифра? {Char.IsDigit(digit)}");
        Console.WriteLine($"'{letter}' - заглавная? {Char.IsUpper(letter)}");

        Console.WriteLine($"\n'{letter}' в нижний регистр: '{Char.ToLower(letter)}'"); //регистр
        Console.WriteLine($"'z' в верхний регистр: '{Char.ToUpper('z')}'");

        Console.WriteLine($"\n'A' < 'Z'? {('A' < 'Z')}"); //сравнение символов

        string text = "Hello5!"; //пример
        Console.WriteLine($"Анализ строки '{text}':");
        foreach (char ch in text)
        {
            if (Char.IsLetter(ch))
                Console.WriteLine($"  '{ch}' - буква");
            else if (Char.IsDigit(ch))
                Console.WriteLine($"  '{ch}' - цифра");
            else
                Console.WriteLine($"  '{ch}' - спецсимвол");
        }
    }
}

