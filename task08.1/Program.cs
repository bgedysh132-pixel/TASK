using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task08_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число k");
            var k = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите целое число m");
            var m = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите целое число n");
            var n = int.Parse(Console.ReadLine());

            if (IfLogicalExpressionTrue(k, m, n))
                Console.WriteLine("Хотя бы одно из чисел k, m или n положительное");
            else
                Console.WriteLine("Ни одно из чисел k, m и n не является положительным");
        }

        static bool IfLogicalExpressionTrue(int k, int m, int n) =>
            k > 0 || m > 0 || n > 0;
    }
}