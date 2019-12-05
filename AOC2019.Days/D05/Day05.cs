using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2019.Days.D05
{
    public class Day05
    {
        private const int Finish = 99;
        private const int Addition = 1;
        private const int Multiply = 2;
        private const int Input = 3;
        private const int Output = 4;
        private const int JumpIfTrue = 5;
        private const int JumpIfFalse = 6;
        private const int LessThan = 7;
        private const int Equals = 8;

        private const int ParameterLengthFour = 4;
        private const int ParameterLengthThree = 3;
        private const int ParameterLengthTwo = 2;

        private const int PositionMode = 0;
        private const int ImmediateMode = 1;

        public int[] Execute(int[] input, int userInput)
        {
            var index = 0;

            while (true)
            {
                var instruction = input[index];

                var opcode = instruction % 100;
                instruction /= 100;
                var firstParameterMode = instruction % 10;
                instruction /= 10;
                var secondParameterMode = instruction % 10;
             
                var outputs = new List<int>();

                if (opcode == Addition)
                {
                    var first = GetParameter(input, firstParameterMode, index + 1);
                    var second = GetParameter(input, secondParameterMode, index + 2);
                    var third = input[index + 3];

                    input[third] = first + second;
                    index += ParameterLengthFour;
                }
                else if (opcode == Multiply)
                {
                    var first = GetParameter(input, firstParameterMode, index + 1);
                    var second = GetParameter(input, secondParameterMode, index + 2);
                    var third = input[index + 3];

                    input[third] = first * second;
                    index += ParameterLengthFour;
                }
                else if (opcode == Input)
                {
                    input[input[index + 1]] = userInput;
                    index += ParameterLengthTwo;
                }
                else if (opcode == Output)
                {
                    var outputValue = GetParameter(input, firstParameterMode, index + 1);

                    outputs.Add(outputValue);

                    if (outputValue != 0)
                    {
                        throw new Exception();
                    }
                    
                    index += ParameterLengthTwo;
                }
                else if (opcode == JumpIfTrue)
                {
                    var first = GetParameter(input, firstParameterMode, index + 1);
                    
                    if (first != 0)
                    {
                        var second = GetParameter(input, secondParameterMode, index + 2);
                        index = second;
                    }
                    else
                    {
                        index += ParameterLengthThree;
                    }
                }
                else if (opcode == JumpIfFalse)
                {
                    var first = GetParameter(input, firstParameterMode, index + 1);

                    if (first == 0)
                    {
                        var second = GetParameter(input, secondParameterMode, index + 2);
                        index = second;
                    }
                    else
                    {
                        index += ParameterLengthThree;
                    }
                }
                else if (opcode == LessThan)
                {
                    var first = GetParameter(input, firstParameterMode, index + 1);
                    var second = GetParameter(input, secondParameterMode, index + 2);                  
                    var third = input[index + 3];

                    input[third] = first < second ? 1 : 0;

                    index += ParameterLengthFour;
                }
                else if (opcode == Equals)
                {
                    var first = GetParameter(input, firstParameterMode, index + 1);
                    var second = GetParameter(input, secondParameterMode, index + 2);
                    var third = input[index + 3];

                    input[third] = first == second ? 1 : 0;

                    index += ParameterLengthFour;
                }
                else if (opcode == Finish)
                {
                    return input;
                }
            }
        }

        private int GetParameter(int[] input, int parameterMode, int parameterIndex)
        {
            if (parameterMode == PositionMode)
            {
                return input[input[parameterIndex]];
            }
            else if (parameterMode == ImmediateMode)
            {
                return input[parameterIndex];
            }

            throw new Exception();
        }
    }
}
