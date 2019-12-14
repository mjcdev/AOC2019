using Combinatorics.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Days.D07
{
    public class Day07
    {
        public IEnumerable<IList<int>> GetCombinations(IEnumerable<int> inputs)
        {
            var permutations = new Permutations<int>(inputs.ToArray());

            return permutations;
        }

        public int CalculateOutput(IList<int> combination, int[] input, int thrusterInput)
        {
            int result = 0;

            var intcodes = combination.Select(c => new Intcode.Intcode(input, c));


            foreach (var intcode in intcodes)
            {
                var copy = input.ToArray();
                result = intcode.Execute(thrusterInput).output;
                thrusterInput = result;
            }

            return result;
        }

        public int CalculateOutputUntilHalted(IList<int> combination, int[] input)
        {
            int result = 0;
            var halted = false;

            var intcodes = combination.Select(c => new Intcode.Intcode(input, c)).ToList();

            var thrusterInput = 0;

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
