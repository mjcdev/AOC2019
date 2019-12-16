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

    }
}
