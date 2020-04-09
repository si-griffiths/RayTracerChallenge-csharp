using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer
{
    public class Canvas
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Color[,] Pixels;

        const int MIN_COLOR = 0;
        const int MAX_COLOR = 255;

        public Canvas(int width, int height)
        {
            Width = width;
            Height = height;

            InitializePixels(width, height);
        }

        private void InitializePixels(int width, int height)
        {
            var initialColor = new Color(0.0, 0.0, 0.0);
            Pixels = new Color[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Pixels[x, y] = initialColor;
                }
            }
        }

        public void WritePixel(int x, int y, Color color)
        {
            Pixels[x, y] = color;
        }

        public string CanvasToPpm()
        {
            StringBuilder ppmText = new StringBuilder();
            // create header
            ppmText.AppendLine("P3"); // First line of PPM file = P3  *HARDCODED FOR NOW*
            ppmText.AppendLine(Width + " " + Height); // Width and Height, space separated
            ppmText.AppendLine(MAX_COLOR.ToString());

            // create body
            for (int y = 0; y < Height; y++)
            {
                string rowText = "";
                for (int x = 0; x < Width; x++)
                {
                    rowText += ScaleAndClamp(Pixels[x, y].Red) + " " + ScaleAndClamp(Pixels[x, y].Green) + " " + ScaleAndClamp(Pixels[x, y].Blue) + " ";
                }
                rowText = rowText.Trim();
                ppmText.AppendLine(rowText);
            }

            return ppmText.ToString();
        }

        private string ScaleAndClamp(double value)
        {
            int scaledValue = Convert.ToInt32(MAX_COLOR * value);
            return Math.Clamp(scaledValue, MIN_COLOR, MAX_COLOR).ToString();
        }
    }
}
