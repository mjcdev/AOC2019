using AOC2019.Days.D02;
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
    public class Day02Tests : AbstractTests
    {
        private readonly ITestOutputHelper _output;

        public Day02Tests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData(new[] { 1, 0, 0, 0, 99 }, new[] { 2, 0, 0, 0, 99 })]
        [InlineData(new[] { 2, 3, 0, 3, 99 }, new[] { 2, 3, 0, 6, 99 })]
        [InlineData(new[] { 2, 4, 4, 5, 99, 0 }, new [] { 2, 4, 4, 5, 99, 9801 })]
        [InlineData(new[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 }, new[] { 30, 1, 1, 4, 2, 5, 6, 0, 99 })]
        public void TestCases(int[] input, int[] expected)
        {
            var result = new Day02().Execute(input);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void DayTwoPartOne()
        {
            var input = ReadCommaSeperatedLine<int>("Day02.txt", i => int.Parse(i)).ToArray();

            input[1] = 12;
            input[2] = 2;

            var output = new Day02().Execute(input);

            var result = output[0];
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

                    var output = new Day02().Execute(input);

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
