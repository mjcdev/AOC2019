using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2019.Days.D13
{
    public class Day13
    {
        public int CountBlockTiles(IEnumerable<long> input)
        {
            var inputArray = input.ToArray();

            var computer = new Intcode.Intcode(inputArray, 0);

            var pixels = new Dictionary<long, IDictionary<long, long>>();


            while (GameLoop(pixels, computer))
            {                
            }

            return pixels.Values.SelectMany(a => a.Values).Count(v => v == 2);
        }

        private bool GameLoop(IDictionary<long, IDictionary<long, long>> pixels, Intcode.Intcode computer)
        {
            var one = computer.Execute();

            if (one.halt)
            {
                return false;
            }                       

            var two = computer.Execute();

            if (two.halt)
            {
                return false;
            }
            var three = computer.Execute();
            
            if (three.halt)
            {
                return false;
            }


            SetPixels(pixels, one.output, two.output, three.output);

            return true;

            // one X
            // two Y
            // three Value
        }

        private void SetPixels(IDictionary<long, IDictionary<long, long>> pixels, long x, long y, long value)
        {
            if (!pixels.ContainsKey(x))
            {
                pixels[x] = new Dictionary<long, long>();
            }

            var yDictionary = pixels[x];

            yDictionary[y] = value;
        }
    }
}
