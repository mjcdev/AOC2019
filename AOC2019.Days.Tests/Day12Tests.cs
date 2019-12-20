using AOC2019.Days.D12;
using AOC2019.Days.Tests.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AOC2019.Days.Tests
{
    public class Day12Tests : AbstractTests
    {
        [Fact]
        public void DayTwelvePartOne()
        {
            var moons = ReadLineSeperatedFile("Day12.txt", l => MoonFromInputString(l));

            var totalEnergy = NewDay().TotalEnergyInSystemAfterSteps(moons, 1000);
        }

        private Moon MoonFromInputString(string inputString)
        {
            var array = inputString.Split('=', ',', '>');

            var x = int.Parse(array[1]);
            var y = int.Parse(array[3]);
            var z = int.Parse(array[5]);

            return new Moon(x, y, z);
        }

        private Day12 NewDay()
        {
            return new Day12();
        }
    }
}
