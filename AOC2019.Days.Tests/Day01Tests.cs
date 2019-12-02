using AOC2019.Days.D01;
using AOC2019.Days.Tests.Abstract;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace AOC2019.Days.Tests
{
    public class Day01Tests : AbstractTests
    {
        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 654)]
        [InlineData(100756, 33583)]
        public void DayPartOneExamples(int mass, int fuel)
        {
            new Day01().CalculateFuel(mass).Should().Be(fuel);
        }

        [Fact]
        public void DayPartOne()
        {
            var testInput = ReadLineSeperatedFile("Day01.txt", i => int.Parse(i));

            var day = new Day01();

            var result = testInput.Sum(i => day.CalculateFuel(i));
        }
      
        [Theory]
        [InlineData(14, 2)]
        [InlineData(1969, 966)]
        [InlineData(100756, 50346)]
        public void DayPartTwoExamples(int mass, int fuel)
        {
            new Day01().CalculateFuelWithFuel(mass).Should().Be(fuel);
        }

        [Fact]
        public void DayParthTwo()
        {
            var testInput = ReadLineSeperatedFile("Day01.txt", i => int.Parse(i));

            var day = new Day01();

            var result = testInput.Sum(i => day.CalculateFuelWithFuel(i));
        }
    }
}
