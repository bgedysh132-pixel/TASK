using System;

class Program
{
    static int[] piDigits = {
        3,1,4,1,5,9,2,6,5,3,
        5,8,9,7,9,3,2,3,8,4,
        6,2,6,4,3,3,8,3,2,7,
        9,5,0,2,8,8,4,1,9,7,
        1,6,9,3,9,9,3,7,5,1
    };

    static void Main()
    {
        Console.Write("Введите целое положительное n: ");
        int n = int.Parse(Console.ReadLine());

        if (n < 1)
        {
            Console.WriteLine("n должно быть положительным.");
            return;
        }

        if (n > piDigits.Length)
        {
            Console.WriteLine("Слишком большое n, максимум " + piDigits.Length);
            return;
        }

        int[] a = new int[n];

        for (int i = 0; i < n; i++)
        {
            a[i] = piDigits[i];
        }

        PrintArray(a);
    }

    static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");

            if ((i + 1) % 10 == 0) 
                Console.WriteLine();
            //p
        }
    }
}
