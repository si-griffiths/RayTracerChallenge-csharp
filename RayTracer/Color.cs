using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer
{
    public class Color
    {
        public double Red { get; set; }
        public double Green { get; set; }
        public double Blue { get; set; }

        public Color(double red, double green, double blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }
    }
}
