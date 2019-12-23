using AOC2019.Days.D13;
using AOC2019.Days.Tests.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AOC2019.Days.Tests
{
    public class Day13Tests : AbstractTests
    {
        [Fact]
        public void DayThirteenPartOne()
        {
            var input = ReadCommaSeperatedLine("Day13.txt", l => long.Parse(l));

            var day = NewDay();

            var result = day.CountBlockTiles(input);
        }

        private Day13 NewDay()
        {
            return new Day13();
        }

    }
}
