using AOC2019.Days.D07;
using AOC2019.Days.Tests.Abstract;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace AOC2019.Days.Tests
{
    public class Day07Tests : AbstractTests
    {
        [Fact]
        public void GetCombinations()
        {
            var results = new Day07().GetCombinations(new[] { 1, 2, });

            results.Should().HaveCount(2);
        }

        [Theory]
        [InlineData(new[] { 3, 15, 3, 16, 1002, 16, 10, 16, 1, 16, 15, 15, 4, 15, 99, 0, 0 }, new[] { 4, 3, 2, 1, 0 }, 43210)]
        [InlineData(new [] {  3,23,3,24,1002,24,10,24,1002,23,-1,23, 101,5,23,23,1,24,23,23,4,23,99,0,0}, new[] { 0, 1, 2, 3, 4 }, 54321)]
        [InlineData(new [] {  3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0}, new[] { 1, 0, 4, 3, 2 }, 65210)]
        public void CalculateOutput(int[] inputArray, int[] combination, int expected)
        {
            new Day07().CalculateOutput(combination, inputArray, 0).Should().Be(expected);
        }

        [Fact]
        public void DaySevenPartOne()
        {
            var day = new Day07();

            var combinations = day.GetCombinations(new[] { 0, 1, 2, 3, 4 });

            var input = ReadCommaSeperatedLine("Day07.txt", i => int.Parse(i)).ToArray();

            var maximum = combinations.Max(c => day.CalculateOutput(c, input, 0));
        }
               
        [Theory]
        [InlineData(new[] { 3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26, 27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5 }, new[] { 9, 8, 7, 6, 5, }, 139629729)]
        public void CalculateOutputUntilHalted(int[] inputArray, int[] combination, int expected)
        {
            new Day07().CalculateOutputUntilHalted(combination, inputArray).Should().Be(expected);
        }

        [Fact]
        public void DaySeventPartTwo()
        {
            var day = new Day07();

            var combinations = day.GetCombinations(new[] { 5, 6, 7, 8, 9, });

            var input = ReadCommaSeperatedLine("Day07.txt", i => int.Parse(i)).ToArray();

            var maximum = combinations.Max(c => day.CalculateOutputUntilHalted(c, input));
        }
    }
}
