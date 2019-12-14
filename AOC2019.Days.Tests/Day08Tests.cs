using AOC2019.Days.D08;
using AOC2019.Days.Tests.Abstract;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace AOC2019.Days.Tests
{
    public class Day08Tests : AbstractTests
    {
        [Fact]
        public void DayEightPartOne()
        {
            var input = ReadFromCharArray("Day08.txt", c => int.Parse(c.ToString()));

            var result = NewDay().ImageCheckSum(input, 25, 6);
        }

        [Fact]
        public void BuildLayers()
        {
            var day = NewDay();

            var layers = day.BuildLayers(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2 }, 3, 2);

            layers.Should().HaveCount(2);
        }

        [Fact]
        public void CountLayer()
        {
            var layer = new Layer()
            {
                new Row()
                {
                    1, 2, 3,
                },
                new Row()
                {
                    2, 4, 5
                }
            };

            layer.CountLayer(2).Should().Be(2);
            layer.CountLayer(1).Should().Be(1);
        }
        
        [Fact]
        public void DayEightPartTwo()
        {
            var input = ReadFromCharArray("Day08.txt", c => int.Parse(c.ToString()));

            var directory = "Outputs";

            Directory.CreateDirectory(directory);

            NewDay().RenderTransmission(input, Path.Combine(directory, "Day08.bmp"), 25, 6);
        }

        private Day08 NewDay()
        {
            return new Day08();
        }
    }
}
