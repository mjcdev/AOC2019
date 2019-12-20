using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2019.Days.D11
{
    public class Day11
    {
        private const long White = 1;
        private const long Black = 0;

        public IEnumerable<HullSquare> Execute(IEnumerable<long> input)
        {
            var hullSquares = new List<HullSquare>();

            var intcode = new Intcode.Intcode(input, 0);

            long userInput = 0;
            int currentX = 0;
            int currentY = 0;
            int direction = 0;

            var halted = false;

            while (!halted)
            {
                var currentColour = GetCurrentColour(hullSquares, currentX, currentY);

                var hullSquare = new HullSquare();

                hullSquare.X = currentX;
                hullSquare.Y = currentY;

                var colour = intcode.Execute(currentColour);
                
                if (colour.halt)
                {
                    break;
                }

                var turn = intcode.Execute(userInput);

                if (turn.halt)
                {
                    break;
                }
                

                hullSquare.Colour = colour.output;

                hullSquares.Add(hullSquare);

                direction = NewDirection(direction, turn.output);

                switch (direction)
                {
                    case 0:
                        currentY++;
                        break;
                    case 90:
                        currentX++;
                        break;
                    case 180:
                        currentY--;
                        break;
                    case 270:
                        currentX--;
                        break;
                    default:
                        throw new Exception();
                }


            }

            return hullSquares;
        }

        public long GetCurrentColour(IEnumerable<HullSquare> hullSquares, long x, long y)
        {
            return hullSquares.LastOrDefault(s => s.X == x && s.Y == y)?.Colour ?? Black;
        }

        public int NewDirection(int currentDirection, long turn)
        {
            if (turn == 0)
            {
                currentDirection -= 90;
            }
            else if (turn == 1)
            {
                currentDirection += 90;
            }

            if (currentDirection < 0)
            {
                currentDirection += 360;
            }

            currentDirection %= 360;

            return currentDirection;
        }
    }
}
