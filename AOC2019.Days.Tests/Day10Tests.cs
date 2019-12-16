using AOC2019.Days.D10;
using AOC2019.Days.Tests.Abstract;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AOC2019.Days.Tests
{
    public class Day10Tests : AbstractTests
    {
        [Fact]
        public void BuildAsteroids()
        {
            var lines = ReadLineSeperatedFile("Day10.txt", i => i);

            var asteroids = NewDay().BuildAsteroids(lines);            
        }

        [Fact]
        public void CountVisibleAsteroids()
        {
            var lines = ReadLineSeperatedFile("Day10.txt", i => i);

            var day10 = NewDay();

            var asteroids = day10.BuildAsteroids(lines).ToList();

            var count = asteroids[0].CountVisibleAsteroids(asteroids);
        }

        [Fact]
        public void MaxVisibleAsteroids()
        {
            var lines = ReadLineSeperatedFile("Day10/ExampleOne.txt", i => i);

            var day10 = NewDay();

            var asteroids = day10.BuildAsteroids(lines).ToList();

            var max = asteroids.Max(a => a.CountVisibleAsteroids(asteroids));

            max.Should().Be(8);
        }

        [Fact]
        public void DayTenPartOne()
        {
            var lines = ReadLineSeperatedFile("Day10.txt", i => i);

            var day10 = NewDay();

            var asteroids = day10.BuildAsteroids(lines).ToList();

            var max = asteroids.Max(a => a.CountVisibleAsteroids(asteroids));
        }

        private Day10 NewDay()
        {
            return new Day10();
        }

    }
}
