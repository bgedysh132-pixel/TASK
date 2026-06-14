using System;

namespace PixelStruct
{
    public struct PixelCMYK
    {
        private const int MaxDensity = 255;
        private const int MinDensity = 0;

        private int c, m, y, k;

        public int C
        {
            get => c;
            set => c = ValidateDensity(value);
        }

        public int M
        {
            get => m;
            set => m = ValidateDensity(value);
        }

        public int Y
        {
            get => y;
            set => y = ValidateDensity(value);
        }

        public int K
        {
            get => k;
            set => k = ValidateDensity(value);
        }

        private int ValidateDensity(int value)
        {
            if (value < MinDensity || value > MaxDensity)
                throw new ArgumentException($"Плотность краски должна быть от {MinDensity} до {MaxDensity}");
            return value;
        }

        public double TotalInk => (C + M + Y + K) * (100.0 / 255.0);

        public PixelCMYK(int c, int m, int y, int k) : this()
        {
            C = c;
            M = m;
            Y = y;
            K = k;     
        }

        public override string ToString()
        {
            double cPercent = C * 100.0 / 255.0;
            double mPercent = M * 100.0 / 255.0;
            double yPercent = Y * 100.0 / 255.0;
            double kPercent = K * 100.0 / 255.0;

            return $"С:{cPercent:F2}% M: {mPercent:F2}% Y: {yPercent:F2}% K: {kPercent:F2}%"; 
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PixelCMYK))
                throw new ArgumentException("Объект для сравнения не является PixelCMYK");

            var other = (PixelCMYK)obj;
            return C == other.C && M == other.M && Y == other.Y && K == other.K; 
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + C.GetHashCode();
                hash = hash * 23 + M.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                hash = hash * 23 + K.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(PixelCMYK left, PixelCMYK right) => left.Equals(right);
        public static bool operator !=(PixelCMYK left, PixelCMYK right) => !left.Equals(right);

        public static PixelCMYK operator *(double kFloat, PixelCMYK pixel) 
        {
            if (kFloat <= 0)
                throw new ArgumentException("Коэффициент должен быть положительным числом");

            int CalculateChannel(int originalValue)
            {
                int newValue = (int)Math.Round(originalValue * kFloat);
                return newValue > MaxDensity ? MaxDensity : newValue;
            }

            return new PixelCMYK(
                CalculateChannel(pixel.C),
                CalculateChannel(pixel.M),
                CalculateChannel(pixel.Y),
                CalculateChannel(pixel.K)
            ); // 
        }
    }
}