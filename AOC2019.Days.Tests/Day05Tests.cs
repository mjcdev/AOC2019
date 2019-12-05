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

            var output = new Day05().Execute(input);
        }

        [Fact]
        public void DayTwoPartTwo()
        {
            var anticipatedResult = 19690720;

            for (var noun = 0; noun <= 99; noun++)
            {
                for (var verb = 0; verb <= 99; verb++)
                {
                    var input = ReadCommaSeperatedLine<int>("Day02.txt", i => int.Parse(i)).ToArray();

                    input[1] = noun;
                    input[2] = verb;

                    var output = new Day05().Execute(input);

                    var result = output[0];

                    if (result == anticipatedResult)
                    {
                        var answer = (100 * noun) + verb;

                        _output.WriteLine(answer.ToString());

                        return;
                    }
                }
            }
        }
    }
}
