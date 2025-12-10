using System;

namespace TaskPi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое положительное n");
            int n = int.Parse(Console.ReadLine());

            int[] piDigits =
            {
                3,1,4,1,5,9,2,6,5,3,
                5,8,9,7,9,3,2,3,8,4,
                6,2,6,4,3,3,8,3,2,7,
                9,5,0,2,8,8,4,1,9,7,
                1,6,9,3,9,9,3,7,5,1
            };

            if (n < 1 || n > piDigits.Length)
            {
                Console.WriteLine("n должно быть от 1 до " + piDigits.Length);
                return;
            }

            var a = new int[n];
            for (int i = 0; i < a.Length; i++)
                a[i] = piDigits[i];

            Console.WriteLine("Исходный массив:");
            PrintIntArray10PerLine(a);

            ChangeToNineMinusA(a);
            Console.WriteLine("После замены каждого элемента на 9 - a[k]:");
            PrintIntArray10PerLine(a);

            Console.WriteLine("Введите число m (0 <= m <= 9)");
            int m = int.Parse(Console.ReadLine());

            int count = CountNumber(a, m);
            Console.WriteLine("Число {0} встречается в массиве {1} раз(а).\n", m, count);

            var zerosOnes = MakeEvenZeroOddOne(a);
            Console.WriteLine("Новый массив (чётные -> 0, нечётные -> 1):");
            PrintIntArray10PerLine(zerosOnes);
        }

        static void PrintIntArray10PerLine(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");

                if ((i + 1) % 10 == 0)
                    Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void ChangeToNineMinusA(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = 9 - array[i];
        }

        static int CountNumber(int[] array, int m)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
                if (array[i] == m)
                    count++;
            return count;
        }

        static int[] MakeEvenZeroOddOne(int[] array)
        {
            var result = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                    result[i] = 0;
                else
                    result[i] = 1;
            }

            return result;
            //p
        }
    }
}
