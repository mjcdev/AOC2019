using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2019.Days.D08
{
    public class Day08
    {
        public int ImageCheckSum(IEnumerable<int> transmission, int width, int height)
        {
            var layers = BuildLayers(transmission, width, height);

            var minimumZeroLayer = layers.OrderBy(l => l.CountLayer(0)).First();
                       
            return minimumZeroLayer.CountLayer(1) * minimumZeroLayer.CountLayer(2);
        }

        public List<Layer> BuildLayers(IEnumerable<int> transmission, int width, int height)
        {
            var currentRow = new Row();

            var currentLayer = new Layer()
            {
                currentRow 
            };

            var layers = new List<Layer>()
            {
                currentLayer
            };

            foreach (var value in transmission)
            {
                if (currentRow.Count == width)
                {
                    if (currentLayer.Count == height)
                    {
                        currentLayer = new Layer();
                        layers.Add(currentLayer);
                    }
                    currentRow = new Row();
                    currentLayer.Add(currentRow);
                }

                currentRow.Add(value);               
            }

            return layers;
        }
    }
}
