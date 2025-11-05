using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Логическое выражение");

        for (int A = 0; A <= 1; A++)
        {
            for (int B = 0; B <= 1; B++)
            {
                for (int C = 0; C <= 1; C++)
                {
                    bool result = YourLogicalExpression(A, B, C);

                    Console.WriteLine($"A={A}, B={B}, C={C} -> Результат = {result}");
                }
            }
        }
    }

    static bool YourLogicalExpression(int A, int B, int C)
    {

        bool expression = (A == 1 && B == 1) || (A == 0 && C == 1);
        return expression;
    }
}