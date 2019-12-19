using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2019.Days.D10
{
    public class Day10
    {
        public IEnumerable<Asteroid> BuildAsteroids(IEnumerable<string> input)
        {
            var inputArray = input.ToArray();

            var height = inputArray.Length;
            var width = inputArray[0].Length;

            var list = new List<Asteroid>();

            for (var y = 0; y < height; y++)
            {
                var row = inputArray[y].ToCharArray();

                for (var x = 0; x < width; x++)
                {
                    if (row[x] == '#')
                    {
                        list.Add(new Asteroid(x, y));
                    }
                }
            }

            return list;
        }

        public int MaxVisibleAsteroids(IEnumerable<Asteroid> asteroids)
        {
            return asteroids.Max(a => CountVisibleAsteroids(a, asteroids));
        }

        public Asteroid MostVisibleAsteroid(IEnumerable<Asteroid> asteroids)
        {
           return asteroids.OrderByDescending(a => CountVisibleAsteroids(a, asteroids)).FirstOrDefault();
        }

        public int CountVisibleAsteroids(Asteroid currentAsteroid, IEnumerable<Asteroid> asteroidField)
        {
            return asteroidField.Where(a => !(a.X == currentAsteroid.X && a.Y == currentAsteroid.Y)).Select(a => AngleBetweenAsteroids(currentAsteroid, a)).Distinct().Count();
        }

        public double AngleBetweenAsteroids(Asteroid root, Asteroid target)
        {
            var w = target.X - root.X;

            // Y Axis is inverted
            var h = root.Y - target.Y;

            var atan = 90 - (Math.Atan2(h, w) * (180 / Math.PI));

            if (atan < 0)
            {
                atan += 360;
            }

            return atan % 360;           
        }

        public int ManhattanDistance(Asteroid root, Asteroid target)
        {
            return Math.Abs(target.X - root.X) + Math.Abs(target.Y - root.Y);
        }

        public int ObliterateAll(IEnumerable<Asteroid> asteroids, Asteroid laser, int obliterationCount)
        {
            var asteroidsForObliteration = asteroids.ToList();

            asteroidsForObliteration.Remove(laser);

            var obliterated = new List<Asteroid>();
                                   
            while(asteroidsForObliteration.Any() && obliterated.Count != obliterationCount)
            {
                var ordered = asteroidsForObliteration
                    .GroupBy(a => AngleBetweenAsteroids(laser, a))
                    .OrderBy(g => g.Key)
                    .ToList();
                    
                    
                var rotation = ordered
                    .Select(g => g.OrderBy(a => ManhattanDistance(laser, a)).First())
                    .ToList();

                foreach (var asteroid in rotation)
                {
                    asteroidsForObliteration.Remove(asteroid);
                    obliterated.Add(asteroid);

                    if (obliterated.Count == obliterationCount)
                    {
                        return asteroid.X * 100 + asteroid.Y;
                    }
                }
            }

            return 0;
        }
    }
}
