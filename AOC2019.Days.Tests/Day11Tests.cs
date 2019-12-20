using AOC2019.Days.D11;
using AOC2019.Days.Tests.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AOC2019.Days.Tests
{
    public class Day11Tests : AbstractTests
    {
        [Fact]
        public void DayElevenPartOne()
        {
            var input = ReadCommaSeperatedLine("Day11.txt", i => long.Parse(i));

            var day = NewDay();

            var result = day.Execute(input);

            var uniqueCount = result.GroupBy(r => new { r.X, r.Y }).Count();
        }

        private Day11 NewDay()
        {
            return new Day11();
        }
    }
}
