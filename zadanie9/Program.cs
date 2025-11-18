using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение аргумента");
            var x = double.Parse(Console.ReadLine());
            Console.WriteLine($"F({x:F2}) = {F(x):F2}");
        }

        static double F(double x)
        {
            if (x < -2)
                return 1 / x;
            else if (x <= 1)
                return x * x;
            else
                return 3 * x * x - x;
            //p
        }
    }
}