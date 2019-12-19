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

            var count = day10.CountVisibleAsteroids(asteroids[0], asteroids);
        }

        [Fact]
        public void MaxVisibleAsteroids()
        {
            var lines = ReadLineSeperatedFile("Day10/ExampleOne.txt", i => i);

            var day10 = NewDay();

            var asteroids = day10.BuildAsteroids(lines).ToList();

            var max = day10.MaxVisibleAsteroids(asteroids);

            max.Should().Be(8);
        }

        [Fact]
        public void DayTenPartOne()
        {
            var lines = ReadLineSeperatedFile("Day10.txt", i => i);

            var day10 = NewDay();

            var asteroids = day10.BuildAsteroids(lines).ToList();

            var max = day10.MaxVisibleAsteroids(asteroids);
        }

        [Fact]
        public void BestAsteroid()
        {
            var lines = ReadLineSeperatedFile("Day10.txt", i => i);

            var day10 = NewDay();

            var asteroids = day10.BuildAsteroids(lines).ToList();

            var best = day10.MostVisibleAsteroid(asteroids);
        }

        [Fact]
        public void Obliterate()
        {
            var lines = ReadLineSeperatedFile("Day10/ExampleTwo.txt", i => i);

            var day10 = NewDay();

            var asteroids = day10.BuildAsteroids(lines).ToList();

            var best = asteroids.First(a => a.X == 8 && a.Y == 3);

            var result = day10.ObliterateAll(asteroids, best, 10);
        }

        [Fact]
        public void DayTenPartTwo()
        {
            var lines = ReadLineSeperatedFile("Day10.txt", i => i);

            var day10 = NewDay();

            var asteroids = day10.BuildAsteroids(lines).ToList();
            
            var best = day10.MostVisibleAsteroid(asteroids);

            var result = day10.ObliterateAll(asteroids, best, 200);
        }

        [Theory]
        //[InlineData(2, 3, 30)]
        //[InlineData(3, 2, 60)]
        [InlineData(1, 0, 90)]
        [InlineData(0, 1, 0)]
        [InlineData(-1, 0, 270)]
        [InlineData(0, -1, 180)]
        [InlineData(1, 1, 45)]
        [InlineData(5, 5, 45)]
        [InlineData(-1, 1, 315)]
        [InlineData(-1, -1, 225)]
        [InlineData(1, -1, 135)]
        public void AnglesFromVectors(int x, int y, double expectedAngle)
        {
            var angle = NewDay().AngleBetweenAsteroids(new Asteroid(0, 0), new Asteroid(x, y));

            angle.Should().Be(expectedAngle);
        }


        private Day10 NewDay()
        {
            return new Day10();
        }

    }
}
