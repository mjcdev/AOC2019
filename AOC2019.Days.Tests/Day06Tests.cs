using AOC2019.Days.D06;
using AOC2019.Days.Tests.Abstract;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AOC2019.Days.Tests
{
    public class Day06Tests : AbstractTests
    {
        [Fact]
        public void CreateTree()
        {
            var inputModels = new[]
            {
                new InputModel("COM", "B"),
                new InputModel("B", "C"),
                new InputModel("C", "D"),
                new InputModel("D", "E"),
                new InputModel("E", "F"),
                new InputModel("B", "G"),
                new InputModel("G", "H"),
                new InputModel("D", "I"),
                new InputModel("E", "J"),
                new InputModel("J", "K"),
                new InputModel("K", "L"),
            };

            var result = new Day06().CreateTree(inputModels);                        
        }

        [Fact]
        public void CalculateTotalNumberOfOrbits()
        {
            var inputModels = new[]
{
                new InputModel("COM", "B"),
                new InputModel("B", "C"),
                new InputModel("C", "D"),
                new InputModel("D", "E"),
                new InputModel("E", "F"),
                new InputModel("B", "G"),
                new InputModel("G", "H"),
                new InputModel("D", "I"),
                new InputModel("E", "J"),
                new InputModel("J", "K"),
                new InputModel("K", "L"),
            };

            var result = new Day06().CalculateTotalNumberOfOrbits(inputModels);

            result.Should().Be(42);
        }

        [Fact]
        public void DaySixPartOne()
        {
            var inputs = ReadLineSeperatedFile(
                "Day06.txt",
                i =>
                {
                    var split = i.Split(")");

                    return new InputModel(split[0], split[1]);
                });

            var result = new Day06().CalculateTotalNumberOfOrbits(inputs);
        }
    }
}
