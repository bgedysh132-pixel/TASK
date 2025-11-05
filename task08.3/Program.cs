using System;

namespace Task08_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите позицию белого коня");
            var whiteKnightPosition = Console.ReadLine();
            Console.WriteLine("Введите позицию черного короля");
            var blackKingPosition = Console.ReadLine();

            if (whiteKnightPosition == blackKingPosition)
            {
                Console.WriteLine("Фигуры не могут стоять на одной клетке");
                return;
            }

            int whiteV, whiteH;
            int blackV, blackH;

            DecodePosition(whiteKnightPosition, out whiteV, out whiteH);
            DecodePosition(blackKingPosition, out blackV, out blackH);

            if (!IsValidPosition(whiteV, whiteH) || !IsValidPosition(blackV, blackH))
            {
                Console.WriteLine("Некорректные позиции фигур");
                return;
            }

            bool knightAttacksKing = IsUnderKnightAttack(blackV, blackH, whiteV, whiteH);
            bool kingAttacksKnight = IsUnderKingAttack(whiteV, whiteH, blackV, blackH);

            if (knightAttacksKing)
                Console.WriteLine("Конь бьет короля");
            else if (kingAttacksKnight)
                Console.WriteLine("Король бьет коня");
            else
                Console.WriteLine("Фигуры не бьют друг друга");
        }

        static void DecodePosition(string position, out int vert, out int hor)
        {
            vert = position[0] - 'a' + 1;
            hor = int.Parse(position[1].ToString());
        }

        static bool IsValidPosition(int vert, int hor)
        {
            return vert >= 1 && vert <= 8 && hor >= 1 && hor <= 8;
        }

        static bool IsUnderKnightAttack(int targetV, int targetH, int knightV, int knightH)
        {
            int deltaV = Math.Abs(targetV - knightV);
            int deltaH = Math.Abs(targetH - knightH);

            return (deltaV == 1 && deltaH == 2) || (deltaV == 2 && deltaH == 1);
        }

        static bool IsUnderKingAttack(int targetV, int targetH, int kingV, int kingH)
        {
            int deltaV = Math.Abs(targetV - kingV);
            int deltaH = Math.Abs(targetH - kingH);

            return deltaV <= 1 && deltaH <= 1 && (deltaV != 0 || deltaH != 0);
        }
    }
}