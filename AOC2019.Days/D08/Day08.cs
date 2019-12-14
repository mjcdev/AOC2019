using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace AOC2019.Days.D08
{
    public class Day08
    {
        private const int Transparent = 2;
        private const int White = 1;
        private const int Black = 0;

        public int ImageCheckSum(IEnumerable<int> transmission, int width, int height)
        {
            var layers = BuildLayers(transmission, width, height);

            var minimumZeroLayer = layers.OrderBy(l => l.CountLayer(0)).First();
                       
            return minimumZeroLayer.CountLayer(1) * minimumZeroLayer.CountLayer(2);
        }

        public void RenderTransmission(IEnumerable<int> transmission, string fileName, int width, int height)
        {
            var layers = BuildLayers(transmission, width, height);

            Output(layers, fileName, width, height);
        }

        public void Output(IEnumerable<Layer> layers, string filePath, int width, int height)
        {
            var bitmap = new Bitmap(width, height);

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    var pixel = GetPixelValueFromLayers(layers, x, y);

                    var color = Color.Transparent;

                    if (pixel == Black)
                    {
                        color = Color.Black;
                    }
                    else if (pixel == White)
                    {
                        color = Color.White;
                    }

                    bitmap.SetPixel(x, y, color);
                }
            }

            using (var stream = File.OpenWrite(filePath))
            {
                bitmap.Save(stream, ImageFormat.Bmp);
            }
        }

        public int GetPixelValueFromLayers(IEnumerable<Layer> layers, int x, int y)
        {
            foreach (var layer in layers)
            {
                var pixel = layer.GetPixelValueFromLayer(x, y);

                if (pixel != Transparent)
                {
                    return pixel;
                }
            }

            return 3;
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
