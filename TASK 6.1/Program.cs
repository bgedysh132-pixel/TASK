using System;

namespace task6._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = "чемодан";

            string first_word = word.Substring(2, 1) +   
                                word.Substring(1, 1) +   
                                word.Substring(3, 1) +   
                                word.Substring(0, 1) +   
                                word.Substring(4, 1);    
            

            first_word = word.Substring(1, 1) +   
                         word.Substring(2, 1) +   
                         word.Substring(3, 1) +   
                         word.Substring(0, 1) +   
                         word.Substring(5, 1);    

            first_word = word.Substring(2, 1) +   
                         word.Substring(1, 1) +   
                         word.Substring(4, 1) +   
                         word.Substring(3, 1) +   
                         word.Substring(6, 1);    

            string second_word = word.Substring(2, 1) +   
                                 word.Substring(1, 1) +   
                                 word.Substring(0, 1);    

            Console.WriteLine("Первое слово: " + first_word);
            Console.WriteLine("Второе слово: " + second_word);
        }
    }
}