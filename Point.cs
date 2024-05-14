using System.ComponentModel;

namespace ConsoleMaze
{
    internal class Point
    {
        private int x, y;
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value);
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value);
                y = value;
            }
        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is Point point)
            {
                return X == point.X && Y == point.Y;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
        public static bool operator ==(Point a, Point b)
        {
            if (a is null) return b is null;
            return a.Equals(b);
        }
        public static bool operator !=(Point a, Point b)
        {
            if (a is null) return b is not null;
            return !a.Equals(b);
        }
    }
}