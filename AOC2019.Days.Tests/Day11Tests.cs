using AOC2019.Days.D11;
using AOC2019.Days.Tests.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
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

            var result = day.Execute(input, 0);

            var uniqueCount = result.GroupBy(r => new { r.X, r.Y }).Count();
        }

        [Fact]
        public void DayElevenPartTwo()
        {
            var input = ReadCommaSeperatedLine("Day11.txt", i => long.Parse(i));

            var day = NewDay();

            var result = day.Execute(input, 1);

            Directory.CreateDirectory("Outputs");

            day.CreateImage(result, "Outputs/Day11.bmp");
        }

        private Day11 NewDay()
        {
            return new Day11();
        }
    }
}
