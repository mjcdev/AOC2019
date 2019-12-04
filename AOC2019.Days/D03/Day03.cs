using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2019.Days.D03
{
    public class Day03
    {
        private const char Horizontal = '-';
        private const char Vertical = '|';
        private const char Start = 'O';
        private const char Corner = '+';
        private const char Collision = 'X';

        public int ManhattanDistanceOfNearestPoint(IEnumerable<IEnumerable<string>> input)
        {
            List<List<Coordinate>> coordinatesByWire = new List<List<Coordinate>>();
                        
            foreach (var wire in input)
            {
                var coordinatesForWire = new List<Coordinate>();
                
                foreach (var instruction in wire)
                {
                    MapLine(instruction, coordinatesForWire);
                }

                coordinatesByWire.Add(coordinatesForWire);
            }

            var wire1 = new HashSet<Coordinate>(coordinatesByWire[0]);
            var wire2 = new HashSet<Coordinate>(coordinatesByWire[1]);

            var overlap = wire1.Where(c => wire2.Contains(c));                        
            
            return overlap.Min(c => c.CalculateManhattanDistance());
        }
        
        public List<Coordinate> MapLine(string input, List<Coordinate> wire)
        {
            var direction = input[0];
            var distance = int.Parse(input.Substring(1));

            var currentCoordinate = wire.DefaultIfEmpty(new Coordinate(0, 0, 0)).LastOrDefault();
            
            var directionFunction = GetDirectionFunction(direction);
            
            for (var travelled = 0; travelled < distance; travelled++)
            {
                currentCoordinate = directionFunction(currentCoordinate);

                wire.Add(currentCoordinate);  
            }

            return wire;
        }    

        public Func<Coordinate, Coordinate> GetDirectionFunction(char direction)
        {
            switch (direction)
            {
                case 'L':
                    return c => c.Left();
                case 'R':
                    return c => c.Right();
                case 'U':
                    return c => c.Up();
                case 'D':
                    return c => c.Down();
                default:
                    break;
            }

            return null;
        }
    }
}
