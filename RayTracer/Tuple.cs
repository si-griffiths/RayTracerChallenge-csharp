using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer
{
    public class Tuple
    {
        const double EPSILON = 0.00001;

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double W { get; set; }

        public Tuple(double x, double y, double z, double w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        public static Tuple Point(double x, double y, double z)
        {
            return new Tuple(x, y, z, 1);
        }

        public static Tuple Vector(double x, double y, double z)
        {
            return new Tuple(x, y, z, 0);
        }

        public bool IsPoint
        {
            get
            {
                return W == 1.0;
            }
        }

        public bool IsVector
        {
            get
            {
                return W == 0.0;
            }
        }

        public double Magnitude
        {
            get
            {
                return Math.Sqrt((X * X) + (Y * Y) + (Z * Z) + (W * W));
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || ! this.GetType().Equals(obj.GetType())) 
            {
                return false;
            }
            else
            {
                Tuple t = (Tuple)obj;
                return (
                    Equal (X, t.X) &&
                    Equal (Y, t.Y) &&
                    Equal (Z, t.Z) &&
                    Equal (W, t.W));
            }
        }

        public override string ToString()
        {
            return String.Format("X: {0}, Y: {1}, Z: {2}, W: {3}", X, Y, Z, W);
        }

        public static Tuple operator -(Tuple a) => new Tuple(-a.X, -a.Y, -a.Z, -a.W);

        public static Tuple operator *(double scalar, Tuple a) => new Tuple(a.X * scalar, a.Y * scalar, a.Z * scalar, a.W * scalar);

        public static Tuple operator *(Tuple a, double scalar) => new Tuple(a.X * scalar, a.Y * scalar, a.Z * scalar, a.W * scalar);

        public static Tuple operator /(double scalar, Tuple a) => new Tuple(a.X / scalar, a.Y / scalar, a.Z / scalar, a.W / scalar);

        public static Tuple operator /(Tuple a, double scalar) => new Tuple(a.X / scalar, a.Y / scalar, a.Z / scalar, a.W / scalar);

        public static bool Equal(double a, double b)
        {
            if (Math.Abs(a -b) < EPSILON)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public static Tuple Add(Tuple first, Tuple second)
        {
            return new Tuple(
                first.X + second.X, 
                first.Y + second.Y, 
                first.Z + second.Z, 
                first.W + second.W);
        }

        public static object Subtract(Tuple first, Tuple second)
        {
            return new Tuple(
                first.X - second.X,
                first.Y - second.Y,
                first.Z - second.Z,
                first.W - second.W);
        }

        public static Tuple Normalize(Tuple v)
        {
            double magnitude = v.Magnitude;
            return new Tuple(v.X / magnitude,
                v.Y / magnitude,
                v.Z / magnitude,
                v.W / magnitude);
        }
    }
}
