using Combinatorics.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Days.D07
{
    public class Day07
    {
        public IEnumerable<IList<long>> GetCombinations(IEnumerable<long> inputs)
        {
            var permutations = new Permutations<long>(inputs.ToArray());

            return permutations;
        }

        public long CalculateOutput(IList<long> combination, long[] input, long thrusterInput)
        {
            long result = 0;

            var intcodes = combination.Select(c => new Intcode.Intcode(input, c));


            foreach (var intcode in intcodes)
            {
                var copy = input.ToArray();
                result = intcode.Execute(thrusterInput).output;
                thrusterInput = result;
            }

            return result;
        }

        public long CalculateOutputUntilHalted(IList<long> combination, long[] input)
        {
            long result = 0;
            var halted = false;

            var intcodes = combination.Select(c => new Intcode.Intcode(input, c)).ToList();

            long thrusterInput = 0;

            while (!halted)
            {
                foreach (var intcode in intcodes)
                {                    
                    var executionResult = intcode.Execute(thrusterInput);
                    result = executionResult.output;
                    thrusterInput = result;
                    if (executionResult.halt)
                    {                        
                        halted = executionResult.halt;
                    }                   
                }
            }

            return result;
        }
    }
}
