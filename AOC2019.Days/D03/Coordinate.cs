using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2019.Days.D03
{
    public struct Coordinate
    {
        public Coordinate(int x, int y, int steps)
        {
            X = x;
            Y = y;
            Steps = steps;
        }

        public int X { get; }

        public int Y { get; }

        public int Steps { get; }

        public override bool Equals(object obj)
        {
            return obj is Coordinate coordinate &&
                   X == coordinate.X &&
                   Y == coordinate.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public int CalculateManhattanDistance() => Math.Abs(X) + Math.Abs(Y);

        public Coordinate Up() => new Coordinate(X, Y + 1, Steps + 1);

        public Coordinate Down() => new Coordinate(X, Y - 1, Steps + 1);

        public Coordinate Left() => new Coordinate(X - 1, Y, Steps + 1);

        public Coordinate Right() => new Coordinate(X + 1, Y, Steps + 1);
    }
}
