using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2019.Days.D04
{
    public class Day04
    {
        public int CalculateMatches(int lower, int upper)
        {
            var lowerArray = CreateDigitArray(lower);
            var upperArray = CreateDigitArray(upper);

            var input = lowerArray;

            int matches = 0;

            if (!OutOfBounds(input, upperArray))
            {
                do
                {
                    input = NextAscendingArray(input);
                                       

                    if (HasDouble(input))
                    {
                        if (!OutOfBounds(input, upperArray))
                        {
                            matches++;
                        }
                    }

                    input = IncrementArray(input);

                } while (!OutOfBounds(input, upperArray));
            }

            return matches;
        }

        public int[] CreateDigitArray(int input)
        {
            int length = input.ToString().Length;
            int[] digitArray = new int[length];
            int index = length - 1;

            do
            {
                digitArray[index] = input % 10;
                input /= 10;
                index--;
            } while (input != 0);

            return digitArray;
        }


        public int[] NextAscendingArray(int[] input)
        {
            for (var i = 0; i < input.Length - 1; i++)
            {
                if (input[i + 1] < input[i])
                {
                    for (var j = i + 1; j < input.Length; j++)
                    {
                        input[j] = input[i];
                    }
                }
            }
            
            return input;
        }

        public int[] IncrementArray(int[] input)
        {
            for (var i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] != 9)
                {
                    input[i]++;
                    return input;
                }
                else
                {
                    input[i] = 0;
                }
            }

            return input;
        }

        public bool OutOfBounds(int[] input, int[] upper)
        {
            // assume same length
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] > upper[i])
                {
                    return true;
                }
                else if (input[i] < upper[i])
                {
                    return false;
                }
            }

            return false;
        }

        public bool HasDouble(int[] input)
        {
            for (var i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
