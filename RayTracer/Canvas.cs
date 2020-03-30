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

        public static string CanvasToPpm(Canvas c)
        {
            StringBuilder ppmText = new StringBuilder();
            ppmText.AppendLine("P3"); // First line of PPM file = P3  *HARDCODED FOR NOW*
            ppmText.AppendLine(c.Width + " " + c.Height); // Width and Height, space separated
            ppmText.Append("255"); // Maximum color value *HARDCODED FOR NOW*
            return ppmText.ToString();
        }
    }
}
