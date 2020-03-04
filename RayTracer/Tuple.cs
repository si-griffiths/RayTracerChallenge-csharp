using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer
{
    public class Tuple
    {
        const double EPSILON = 0.00001;

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float W { get; set; }

        public Tuple(float x, float y, float z, float w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        public static Tuple Point(float x, float y, float z)
        {
            return new Tuple(x, y, z, 1);
        }

        public static Tuple Vector(float x, float y, float z)
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

        public static bool Equal(float a, float b)
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
    }
}
