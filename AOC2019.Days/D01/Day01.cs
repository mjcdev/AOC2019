using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2019.Days.D01
{
    public class Day01
    {
        public int CalculateFuel(decimal mass)
        {
            return  ((int)Math.Floor(mass/3)) - 2;
        }

        public int CalculateFuelWithFuel(decimal mass)
        {
            decimal weight = mass;
            decimal total = 0;

            do
            {
                weight = CalculateFuel(weight);

                if (weight > 0)
                {
                    total += weight;
                }
            }
            while (weight > 0);

            return (int)total;
        }
    }
}
