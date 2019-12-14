using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2019.Days.Intcode
{
    public class Intcode
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

        private int[] _currentState;
        private int _userInput;
        private int _currentOutput;

        private int _index = 0;
        private bool _useUserInput = true;

        public Intcode(IEnumerable<int> input, int userInput)
        {
            _currentState = input.ToArray();
            _userInput = userInput;
        }

        public (bool halt, int output, int[] state) Execute(int thrusterOutput)
        {
            while (true)
            {
                var instruction = _currentState[_index];

                var opcode = instruction % 100;
                instruction /= 100;
                var firstParameterMode = instruction % 10;
                instruction /= 10;
                var secondParameterMode = instruction % 10;

                if (opcode == Addition)
                {
                    var first = GetParameter(firstParameterMode, _index + 1);
                    var second = GetParameter(secondParameterMode, _index + 2);
                    var third = _currentState[_index + 3];

                    _currentState[third] = first + second;
                    _index += ParameterLengthFour;
                }
                else if (opcode == Multiply)
                {
                    var first = GetParameter(firstParameterMode, _index + 1);
                    var second = GetParameter(secondParameterMode, _index + 2);
                    var third = _currentState[_index + 3];

                    _currentState[third] = first * second;
                    _index += ParameterLengthFour;
                }
                else if (opcode == Input)
                {
                    int inputValue;
                    if (_useUserInput)
                    {
                        inputValue = _userInput;
                        _useUserInput = false;
                    }
                    else
                    {
                        inputValue = thrusterOutput;
                    }

                    _currentState[_currentState[_index + 1]] = inputValue;
                    _index += ParameterLengthTwo;
                }
                else if (opcode == Output)
                {
                    _currentOutput = GetParameter(firstParameterMode, _index + 1);
                    
                    _index += ParameterLengthTwo;

                    if (_currentOutput != 0)
                    {
                        return (false, _currentOutput, _currentState);
                    }
                }
                else if (opcode == JumpIfTrue)
                {
                    var first = GetParameter(firstParameterMode, _index + 1);

                    if (first != 0)
                    {
                        var second = GetParameter(secondParameterMode, _index + 2);
                        _index = second;
                    }
                    else
                    {
                        _index += ParameterLengthThree;
                    }
                }
                else if (opcode == JumpIfFalse)
                {
                    var first = GetParameter(firstParameterMode, _index + 1);

                    if (first == 0)
                    {
                        var second = GetParameter(secondParameterMode, _index + 2);
                        _index = second;
                    }
                    else
                    {
                        _index += ParameterLengthThree;
                    }
                }
                else if (opcode == LessThan)
                {
                    var first = GetParameter(firstParameterMode, _index + 1);
                    var second = GetParameter(secondParameterMode, _index + 2);
                    var third = _currentState[_index + 3];

                    _currentState[third] = first < second ? 1 : 0;

                    _index += ParameterLengthFour;
                }
                else if (opcode == Equals)
                {
                    var first = GetParameter(firstParameterMode, _index + 1);
                    var second = GetParameter(secondParameterMode, _index + 2);
                    var third = _currentState[_index + 3];

                    _currentState[third] = first == second ? 1 : 0;

                    _index += ParameterLengthFour;
                }
                else if (opcode == Finish)
                {
                    return (true, _currentOutput, _currentState);
                }
            }
        }

        private int GetParameter(int parameterMode, int parameterIndex)
        {
            if (parameterMode == PositionMode)
            {
                return _currentState[_currentState[parameterIndex]];
            }
            else if (parameterMode == ImmediateMode)
            {
                return _currentState[parameterIndex];
            }

            throw new Exception();
        }

    }
}
