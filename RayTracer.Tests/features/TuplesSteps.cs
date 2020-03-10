using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
namespace RayTracer.Tests.features
{
    [Binding]
    public class TuplesSteps
    {
        //
        // Given A tuple
        private Tuple a;
        [Given(@"a = tuple\((.*), (.*), (.*), (.*)\)")]
        public void GivenA_Tuple(float x, float y, float z, float w)
        {
            a = new Tuple(x, y, z, w);
        }

        [Then(@"a\.x == (.*)")]
        public void ThenA_X(float x)
        {
            Assert.IsTrue(Tuple.Equal(x, a.X));
        }

        [Then(@"a\.y == (.*)")]
        public void ThenA_Y(float y)
        {
            Assert.AreEqual(y, a.Y);
        }

        [Then(@"a\.z == (.*)")]
        public void ThenA_Z(float z)
        {
            Assert.AreEqual(z, a.Z);
        }

        [Then(@"a\.w == (.*)")]
        public void ThenA_W(float w)
        {
            Assert.AreEqual(w, a.W);
        }

        [Then(@"a is a point")]
        public void ThenAIsAPoint()
        {
            Assert.IsTrue(a.IsPoint);
        }

        [Then(@"a is not a vector")]
        public void ThenAIsNotAVector()
        {
            Assert.IsFalse(a.IsVector);
        }


        //
        // Given B Tuple
        private Tuple b;
        [Given(@"b = tuple\((.*), (.*), (.*), (.*)\)")]
        public void GivenB_Tuple(float x, float y, float z, float w)
        {
            b = new Tuple(x, y, z, w);
        }

        [Then(@"b\.x == (.*)")]
        public void ThenB_X(float x)
        {
            Assert.AreEqual(x, b.X);
        }

        [Then(@"b\.y == (.*)")]
        public void ThenB_Y(float y)
        {
            Assert.AreEqual(y, b.Y);
        }

        [Then(@"b\.z == (.*)")]
        public void ThenB_Z(float z)
        {
            Assert.AreEqual(z, b.Z);
        }

        [Then(@"b\.w == (.*)")]
        public void ThenB_W(float w)
        {
            Assert.AreEqual(w, b.W);
        }

        [Then(@"b is a not a point")]
        public void ThenAIsANotAPoint()
        {
            Assert.IsFalse(b.IsPoint);
        }

        [Then(@"b is a vector")]
        public void ThenAIsAVector()
        {
            Assert.IsTrue(b.IsVector);
        }

        //
        // Given Point() creates tuple with w=1
        Tuple p;

        [Given(@"p = point\((.*), (.*), (.*)\)")]
        public void GivenP_Point(float x, float y, float z)
        {
            p = Tuple.Point(x, y, z);
        }

        [Then(@"p == tuple\((.*), (.*), (.*), (.*)\)")]
        public void ThenPTuple(float x, float y, float z, float w)
        {
            var t = new Tuple(x, y, z, w);
            Assert.AreEqual(p, t);
        }

        //
        // Given Vector() creates tuple with w=0
        Tuple v;

        [Given(@"v = vector\((.*), (.*), (.*)\)")]
        public void GivenV_Vector(float x, float y, float z)
        {
            v = Tuple.Vector(x, y, z);
        }

        [Then(@"v == tuple\((.*), (.*), (.*), (.*)\)")]
        public void ThenVTuple(float x, float y, float z, float w)
        {
            var t = new Tuple(x, y, z, w);
            Assert.AreEqual(t, v);
        }

        //
        // Adding two tuples
        private Tuple aa, ab;
        [Given(@"aa = tuple\((.*), (.*), (.*), (.*)\)")]
        public void GivenAaTuple(float x, float y, float z, float w)
        {
            aa = new Tuple(x, y, z, w);
        }

        [Given(@"ab = tuple\((.*), (.*), (.*), (.*)\)")]
        public void GivenAbTuple(float x, float y, float z, float w)
        {
            ab = new Tuple(x, y, z, w);
        }

        [Then(@"aa \+ ab == tuple\((.*), (.*), (.*), (.*)\)")]
        public void ThenAaAbTuple(float x, float y, float z, float w)
        {
            var expected = new Tuple(x, y, z, w);
            var result = Tuple.Add(aa, ab);
            Assert.AreEqual(expected, result);
        }

        //
        // subtracting two points
        Tuple pa, pb;
        [Given(@"pa = point\((.*), (.*), (.*)\)")]
        public void GivenPaPoint(float x, float y, float z)
        {
            pa = Tuple.Point(x, y, z);
        }

        [Given(@"pb = point\((.*), (.*), (.*)\)")]
        public void GivenPbPoint(float x, float y, float z)
        {
            pb = Tuple.Point(x, y, z);
        }

        [Then(@"pa - pb == vector\((.*), (.*), (.*)\)")]
        public void ThenPa_PbVector(float x, float y, float z)
        {
            var expected = Tuple.Vector(x, y, z);
            var result = Tuple.Subtract(pa, pb);
            Assert.AreEqual(expected, result);
        }

        //
        // Subtracting a vector from a point
        Tuple pc, vc;
        [Given(@"pc = point\((.*), (.*), (.*)\)")]
        public void GivenPcPoint(float x, float y, float z)
        {
            pc = Tuple.Point(x, y, z);
        }

        [Given(@"vc = vector\((.*), (.*), (.*)\)")]
        public void GivenVcVector(float x, float y, float z)
        {
            vc = Tuple.Vector(x, y, z);
        }

        [Then(@"pc - vc == point\((.*), (.*), (.*)\)")]
        public void ThenPc_VcPoint(float x, float y, float z)
        {
            var expected = Tuple.Point(x, y, z);
            var result = Tuple.Subtract(pc, vc);
            Assert.AreEqual(expected, result);
        }

        //
        // Subtracting two vectors
        private Tuple vi, vii;
        [Given(@"vi = vector\((.*), (.*), (.*)\)")]
        public void GivenViVector(float x, float y, float z)
        {
            vi = Tuple.Vector(x, y, z);
        }

        [Given(@"vii = vector\((.*), (.*), (.*)\)")]
        public void GivenViiVector(float x, float y, float z)
        {
            vii = Tuple.Vector(x, y, z);
        }

        [Then(@"vi -vii = vector\((.*), (.*), (.*)\)")]
        public void ThenVi_ViiVector(float x, float y, float z)
        {
            var expected = Tuple.Vector(x, y, z);
            var result = Tuple.Subtract(vi, vii);
            Assert.AreEqual(expected, result);
        }

        //
        // Subtracting a vector from the zero vector
        private Tuple zero, viii;
        [Given(@"zero = vector\((.*), (.*), (.*)\)")]
        public void GivenZeroVector(float x, float y, float z)
        {
            zero = Tuple.Vector(x, y, z);
        }

        [Given(@"viii = vector\((.*), (.*), (.*)\)")]
        public void GivenViiiVector(float x, float y, float z)
        {
            viii = Tuple.Vector(x, y, z);
        }

        [Then(@"zero - viii == vector\((.*), (.*), (.*)\)")]
        public void ThenZero_ViiiVector(float x, float y, float z)
        {
            var expected = Tuple.Vector(x, y, z);
            var result = Tuple.Subtract(zero, viii);
            System.Diagnostics.Trace.WriteLine("Hello");
            Assert.AreEqual(expected, result);
        }

        //
        // Negating a tuple
        [Then(@"-a = tuple\((.*), (.*), (.*), (.*)\)")]
        public void Then_ATuple(float x, float y, float z, float w)
        {
            var expected = new Tuple(x, y, z, w);
            var result = -a;
            Assert.AreEqual(expected, result);
        }

        //
        // Multiplying a tuple by a scalar
        [Then(@"a \* (.*) == tuple\((.*), (.*), (.*), (.*)\)")]
        public void ThenATuple(float scalar, float x, float y, float z, float w)
        {
            var expected = new Tuple(x, y, z, w);
            var result = a * scalar;
            Assert.AreEqual(expected, result);
        }

        //
        // Dividing a tuple by a scalar
        [Then(@"a divided by (.*) = tuple\((.*), (.*), (.*), (.*)\)")]
        public void ThenADividedByTuple(float scalar, float x, float y, float z, float w)
        {
            var expected = new Tuple(x, y, z, w);
            var result = a / scalar;
            Assert.AreEqual(expected, result);
        }

        //
        // Computing the magnitude of a vector
        [Then(@"magnitude\(v\) = (.*)")]
        public void ThenMagnitudeV(double magnitude)
        {
            Assert.AreEqual(magnitude, v.Magnitude);
        }




    }
}
