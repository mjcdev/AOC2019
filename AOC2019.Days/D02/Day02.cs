using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2019.Days.D02
{
    public class Day02
    {
        private const int Finish = 99;
        private const int Addition = 1;
        private const int Multiply = 2;

        public int[] Execute(int[] input)
        {
            var index = 0;

            var op = input[index];

            while (op != Finish)
            {
                input = ApplyOpCode(op, input[index + 1], input[index + 2], input[index + 3], input);

                index = index + 4;
                op = input[index];
            }

            return input;
        }

        public int[] ApplyOpCode(int op, int lhsIndex, int rhsIndex, int output, int[] input)
        {
            var result = 0;
            var lhs = input[lhsIndex];
            var rhs = input[rhsIndex];

            if (op == 1)
            {
                result = lhs + rhs;
            }
            else if (op == 2)
            {
                result = lhs * rhs;
            }

            input[output] = result;

            return input;
        }
    }
}
