using AOC2019.Days.Tests.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AOC2019.Days.Tests
{
    public class Day09Tests : AbstractTests
    {
        [Fact]
        public void DayNinePartOne()
        {
            var input = ReadCommaSeperatedLine("Day09.txt", i => long.Parse(i));

            var intCode = new Intcode.Intcode(input, 1);

            var halted = false;

            long output = 0;

            while(halted != true)
            {
                var result = intCode.Execute(1);

                if (result.halt)
                {
                    output = result.output;
                }

                halted = result.halt;
            }         
        }

        [Fact]
        public void DayNinePartTwo()
        {
            var input = ReadCommaSeperatedLine("Day09.txt", i => long.Parse(i));

            var intCode = new Intcode.Intcode(input, 2);

            var halted = false;

            long output = 0;

            while (halted != true)
            {
                var result = intCode.Execute(1);

                if (result.halt)
                {
                    output = result.output;
                }

                halted = result.halt;
            }
        }
    }
}
