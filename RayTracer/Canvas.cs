using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RayTracer
{
    public class Canvas
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Color[,] Pixels;

        const int MIN_COLOR = 0;
        const int MAX_COLOR = 255;
        const int PPM_FILE_MAX_LINE_LENGTH = 70;

        public Canvas(int width, int height)
        {
            Width = width;
            Height = height;

            var initialColor = new Color(0.0, 0.0, 0.0);
            InitializePixels(initialColor);
        }

        public void InitializePixels(Color color)
        {
            Pixels = new Color[Width, Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Pixels[x, y] = color;
                }
            }
        }

        public void WritePixel(int x, int y, Color color)
        {
            if (x > Width || x < 0 || y > Height || y < 0)
            {
                // ignore pixels that are not on the canvas
                return;
            }
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
                var rowStack = new Stack<String>();
                rowStack.Push("");

                for (int x = 0; x < Width; x++)
                {
                    string row = rowStack.Pop();
                    if (row.Length + 3 < PPM_FILE_MAX_LINE_LENGTH)
                    {
                        row += ScaleAndClamp(Pixels[x, y].Red) + " ";
                    }
                    else
                    {
                        rowStack.Push(row);
                        row = ScaleAndClamp(Pixels[x, y].Red) + " ";
                    }

                    if (row.Length + 3 < PPM_FILE_MAX_LINE_LENGTH)
                    {
                        row += ScaleAndClamp(Pixels[x, y].Green) + " ";
                    }
                    else
                    {
                        rowStack.Push(row);
                        row = ScaleAndClamp(Pixels[x, y].Green) + " ";
                    }

                    if (row.Length + 3 < PPM_FILE_MAX_LINE_LENGTH)
                    {
                        row += ScaleAndClamp(Pixels[x, y].Blue) + " ";
                    }
                    else
                    {
                        rowStack.Push(row);
                        row = ScaleAndClamp(Pixels[x, y].Blue) + " ";
                    }
                    rowStack.Push(row);
                }
                
                foreach(string row in rowStack.Reverse())
                {
                    ppmText.AppendLine(row.Trim());
                }
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
