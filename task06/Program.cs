using System;

namespace LeetTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст на английском языке:");
            string text = Console.ReadLine();

            Console.WriteLine("Перевод в Leet:");
            Console.WriteLine(ToLeet(text));
        }

        static string ToLeet(string s)
        {
            string result = s.ToUpper();

            result = result
                .Replace("A", "4")
                .Replace("B", "8")
                .Replace("C", "(")
                .Replace("D", "|)")
                .Replace("E", "3")
                .Replace("F", "|=")
                .Replace("G", "6")
                .Replace("H", "|-|")
                .Replace("I", "!")
                .Replace("J", ")")
                .Replace("K", "|<")
                .Replace("L", "1")
                .Replace("M", "|\\/|")
                .Replace("N", "|\\|")
                .Replace("O", "0")
                .Replace("P", "|>")
                .Replace("Q", "9")
                .Replace("R", "|2")
                .Replace("S", "5")
                .Replace("T", "7")
                .Replace("U", "(_)")
                .Replace("V", "\\/")
                .Replace("W", "\\/\\/")
                .Replace("X", "><")
                .Replace("Y", "'/")
                .Replace("Z", "2");

            return result;
        }
    }
}