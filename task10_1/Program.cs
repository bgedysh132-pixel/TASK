using System;

namespace TaskPowerTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const double kWPerHp = 1.35962;

            Console.WriteLine("Л.с.\tКВт");

            for (int hp = 50; hp <= 250; hp += 5)
            {
                double kW = hp * kWPerHp;
                Console.WriteLine($"{hp}\t{kW:F4}");
            }
        }
    }
}

