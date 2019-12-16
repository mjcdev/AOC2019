using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2019.Days.D10
{
    public class Asteroid
    {
        public Asteroid(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int CountVisibleAsteroids(IEnumerable<Asteroid> asteroidField)
        {
            var angles = asteroidField.Where(a => !(a.X == X && a.Y == Y)).Select(a => Math.Atan2(a.Y - Y, a.X - X));
                
            var distinct = angles.Distinct();

            var count = distinct.Count();

            return count;
        }
    }
}
