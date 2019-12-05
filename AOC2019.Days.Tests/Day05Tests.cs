using AOC2019.Days.D05;
using AOC2019.Days.Tests.Abstract;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace AOC2019.Days.Tests
{
    public class Day05Tests : AbstractTests
    {
        private readonly ITestOutputHelper _output;

        public Day05Tests(ITestOutputHelper output)
        {
            _output = output;
        }
               
        [Fact]
        public void DayFivePartOne()
        {
            var input = ReadCommaSeperatedLine("Day05.txt", i => int.Parse(i)).ToArray();

            var output = new Day05().Execute(input, 1);
        }

        [Fact]
        public void DayFivePartTwo()
        {
            var input = ReadCommaSeperatedLine("Day05.txt", i => int.Parse(i)).ToArray();

            var output = new Day05().Execute(input, 5);
        }
    }
}
