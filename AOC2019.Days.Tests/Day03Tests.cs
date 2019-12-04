using AOC2019.Days.D03;
using AOC2019.Days.Tests.Abstract;
using FluentAssertions;
using Xunit;

namespace AOC2019.Days.Tests
{
    public class Day03Tests : AbstractTests
    {

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(100, 100, 200)]
        [InlineData(50, -50, 100)]
        [InlineData(-60, -60, 120)]
        [InlineData(-70, 70, 140)]
        public void CoordinateManhattanDistance(int x, int y, int manhattanDistance)
        {
            new Coordinate(x, y, 0).CalculateManhattanDistance().Should().Be(manhattanDistance);
        }


        [Fact]
        public void Day03PartOne()
        {
            var input = ReadLineSeperatedFile("Day03.txt", s => s.Split(","));

            var result = new Day03().ManhattanDistanceOfNearestPoint(input);
        }

        [Fact]
        public void Day03PartTwo()
        {
            var input = ReadLineSeperatedFile("Day03.txt", s => s.Split(","));

            var result = new Day03().MinimumCombinedSteps(input);
        }
    }
}
