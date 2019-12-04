﻿using AOC2019.Days.D04;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AOC2019.Days.Tests
{
    public class Day04Tests
    {
        [Theory]
        [InlineData(1, new [] { 1 })]
        [InlineData(123456, new[] { 1, 2, 3, 4, 5, 6 })]
        public void CreateDigitArray(int input, int[] expected)
        {
            new Day04().CreateDigitArray(input).Should().BeEquivalentTo(expected);

        }

        [Fact]
        public void HasDouble_True()
        {
            new Day04().HasDouble(new[] { 4, 2, 2, 1, 0 }).Should().BeTrue();
        }

        [Fact]
        public void HasDouble_False()
        {
            new Day04().HasDouble(new[] { 4, 2, 4, 2, 1, 0 }).Should().BeFalse();
        }

        [Fact]
        public void OutOfBounds_True()
        {
            new Day04().OutOfBounds(new[] { 2, 3, 4 }, new[] { 2, 3, 3 }).Should().BeTrue();
        }

        [Fact]
        public void OutOfBounds_False_Equal()
        {
            new Day04().OutOfBounds(new[] { 2, 3, 4 }, new[] { 2, 3, 4 }).Should().BeFalse();
        }
        
        [Fact]
        public void OutOfBounds_False_Less()
        {
            new Day04().OutOfBounds(new[] { 2, 3, 4 }, new[] { 2, 3, 5 }).Should().BeFalse();
        }

        [Fact]
        public void NextAscendingArray()
        {
            new Day04().NextAscendingArray(new[] { 1, 0, 9, 0 }).Should().BeEquivalentTo(new[] { 1, 1, 1, 1 });
        }

        [Fact]
        public void IncrementArray()
        {
            new Day04().IncrementArray(new[] { 1, 2 }).Should().BeEquivalentTo(new[] { 1, 3 });
        }

        [Fact]
        public void IncrementArray_9()
        {
            new Day04().IncrementArray(new[] { 1, 9 }).Should().BeEquivalentTo(new []{ 2, 0 });
        }

        [Fact]
        public void DayFourPartOne()
        {
            var result = new Day04().CalculateMatches(206938, 679128);
        }
    }
}
