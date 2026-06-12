using System;

namespace MusicStructures
{
    public struct Duration
    {
        public int Minutes { get; }
        public int Seconds { get; }

        public Duration(int minutes, int seconds)
        {
            if (minutes < 0)
                throw new ArgumentException("Минуты не могут быть отрицательными.");
            if (seconds < 0 || seconds > 59)
                throw new ArgumentException("Секунды должны быть в диапазоне от 0 до 59.");

            Minutes = minutes;
            Seconds = seconds;
        }

        public int TotalSeconds => (Minutes * 60) + Seconds;

        public override string ToString()
        {
            return $"{Minutes:D2}:{Seconds:D2}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Duration other)
            {
                return this.TotalSeconds == other.TotalSeconds;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return TotalSeconds.GetHashCode();
        }

        public static Duration operator +(Duration d1, Duration d2)
        {
            int total = d1.TotalSeconds + d2.TotalSeconds;
            return new Duration(total / 60, total % 60);
        }

        public static Duration operator -(Duration d1, Duration d2)
        {
            int total = d1.TotalSeconds - d2.TotalSeconds;
            if (total < 0)
                throw new InvalidOperationException("Результат вычитания длительностей не может быть отрицательным.");

            return new Duration(total / 60, total % 60);
        }

        public static Duration operator *(Duration d, int factor)
        {
            if (factor < 0)
                throw new ArgumentException("Множитель не может быть отрицательным.");

            int total = d.TotalSeconds * factor;
            return new Duration(total / 60, total % 60);
        }

        public static Duration operator *(int factor, Duration d)
        {
            return d * factor;
        }

        public static bool operator ==(Duration d1, Duration d2) => d1.Equals(d2);
        public static bool operator !=(Duration d1, Duration d2) => !d1.Equals(d2);
    }
}