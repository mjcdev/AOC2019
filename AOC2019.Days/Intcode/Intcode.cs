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
        private const int RelativeBaseOffset = 9;

        private const int ParameterLengthFour = 4;
        private const int ParameterLengthThree = 3;
        private const int ParameterLengthTwo = 2;

        private const int PositionMode = 0;
        private const int ImmediateMode = 1;
        private const int RelativeMode = 2;

        private long[] _currentState;
        private long _userInput;
        private long _currentOutput;

        private long _index = 0;
        private bool _useUserInput = true;
        private long _relativeAddress = 0;

        private int _memorySize = 100000;

        public Intcode(IEnumerable<long> input, long userInput)
        {
            _currentState = input.ToArray();

            Array.Resize(ref _currentState, _memorySize);

            _userInput = userInput;
        }

        public (bool halt, long output, long[] state) Execute(long thrusterOutput)
        {
            while (true)
            {
                var instruction = _currentState[_index];

                var opcode = instruction % 100;
                instruction /= 100;
                var firstParameterMode = instruction % 10;
                instruction /= 10;
                var secondParameterMode = instruction % 10;
                instruction /= 10;
                var thirdParameterMode = instruction % 10;
                                
                if (opcode == Addition)
                {
                    var first = GetParameter(firstParameterMode, _index + 1);
                    var second = GetParameter(secondParameterMode, _index + 2);

                    SetParameter(thirdParameterMode, _index + 3, first + second);

                    _index += ParameterLengthFour;
                }
                else if (opcode == Multiply)
                {
                    var first = GetParameter(firstParameterMode, _index + 1);
                    var second = GetParameter(secondParameterMode, _index + 2);

                    SetParameter(thirdParameterMode, _index + 3, first * second);
                    
                    _index += ParameterLengthFour;
                }
                else if (opcode == Input)
                {
                    long inputValue;
                    if (_useUserInput)
                    {
                        inputValue = _userInput;
                        _useUserInput = false;
                    }
                    else
                    {
                        inputValue = thrusterOutput;
                    }

                    SetParameter(firstParameterMode, _index + 1, inputValue);
                        
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

                    SetParameter(thirdParameterMode, _index + 3, first < second ? 1 : 0);

                    _index += ParameterLengthFour;
                }
                else if (opcode == Equals)
                {
                    var first = GetParameter(firstParameterMode, _index + 1);
                    var second = GetParameter(secondParameterMode, _index + 2);

                    SetParameter(thirdParameterMode, _index + 3, first == second ? 1 : 0);

                    _index += ParameterLengthFour;
                }
                else if (opcode == RelativeBaseOffset)
                {
                    var first = GetParameter(firstParameterMode, _index + 1);

                    _relativeAddress += first;
                    _index += ParameterLengthTwo;
                }
                else if (opcode == Finish)
                {
                    return (true, _currentOutput, _currentState);
                }
            }
        }

        private void SetParameter(long parameterMode, long parameterIndex, long value)
        {
            if (parameterMode == RelativeMode)
            {
                _currentState[_currentState[parameterIndex] + _relativeAddress] = value;
                return;
            }
            else if (parameterMode == PositionMode)
            {
                _currentState[_currentState[parameterIndex]] = value;
                return;
            }

            throw new Exception();
        }

        private long GetParameter(long parameterMode, long parameterIndex)
        {
            if (parameterMode == PositionMode)
            {
                return _currentState[_currentState[parameterIndex]];
            }
            else if (parameterMode == ImmediateMode)
            {
                return _currentState[parameterIndex];
            }
            else if (parameterMode == RelativeMode)
            {
                return _currentState[_currentState[parameterIndex] + _relativeAddress];
            }

            throw new Exception();
        }

    }
}
