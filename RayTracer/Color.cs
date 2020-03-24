using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer
{
    public class Color
    {
        const double EPSILON = 0.00001;

        public double Red { get; set; }
        public double Green { get; set; }
        public double Blue { get; set; }

        public Color(double red, double green, double blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public static Color operator *(double scalar, Color color) => Multiply(color, scalar);

        public static Color operator *(Color color, double scalar) => Multiply(color, scalar);

        public static Color operator +(Color first, Color second) => Add(first, second);

        public static Color operator -(Color first, Color second) => Subtract(first, second);

        public static Color Add(Color first, Color second)
        {
            return new Color(
                first.Red + second.Red,
                first.Green + second.Green,
                first.Blue + second.Blue);
        }

        public static Color Subtract(Color first, Color second)
        {
            return new Color(
                first.Red - second.Red,
                first.Green - second.Green,
                first.Blue - second.Blue);
        }

        public static Color Multiply(Color color, double scalar)
        {
            return new Color(
                color.Red * scalar,
                color.Green * scalar,
                color.Blue * scalar);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Color c = (Color)obj;
                return (
                    Equal(Red, c.Red) &&
                    Equal(Green, c.Green) &&
                    Equal(Blue, c.Blue));
            }
        }

        public static bool Equal(double a, double b)
        {
            if (Math.Abs(a - b) < EPSILON)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
