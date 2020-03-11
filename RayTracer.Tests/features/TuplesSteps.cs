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
        public void GivenA_Tuple(double x, double y, double z, double w)
        {
            a = new Tuple(x, y, z, w);
        }

        [Then(@"a\.x == (.*)")]
        public void ThenA_X(double x)
        {
            Assert.IsTrue(Tuple.Equal(x, a.X));
        }

        [Then(@"a\.y == (.*)")]
        public void ThenA_Y(double y)
        {
            Assert.AreEqual(y, a.Y);
        }

        [Then(@"a\.z == (.*)")]
        public void ThenA_Z(double z)
        {
            Assert.AreEqual(z, a.Z);
        }

        [Then(@"a\.w == (.*)")]
        public void ThenA_W(double w)
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
        public void GivenB_Tuple(double x, double y, double z, double w)
        {
            b = new Tuple(x, y, z, w);
        }

        [Then(@"b\.x == (.*)")]
        public void ThenB_X(double x)
        {
            Assert.AreEqual(x, b.X);
        }

        [Then(@"b\.y == (.*)")]
        public void ThenB_Y(double y)
        {
            Assert.AreEqual(y, b.Y);
        }

        [Then(@"b\.z == (.*)")]
        public void ThenB_Z(double z)
        {
            Assert.AreEqual(z, b.Z);
        }

        [Then(@"b\.w == (.*)")]
        public void ThenB_W(double w)
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
        public void GivenP_Point(double x, double y, double z)
        {
            p = Tuple.Point(x, y, z);
        }

        [Then(@"p == tuple\((.*), (.*), (.*), (.*)\)")]
        public void ThenPTuple(double x, double y, double z, double w)
        {
            var t = new Tuple(x, y, z, w);
            Assert.AreEqual(p, t);
        }

        //
        // Given Vector() creates tuple with w=0
        Tuple v;

        [Given(@"v = vector\((.*), (.*), (.*)\)")]
        public void GivenV_Vector(double x, double y, double z)
        {
            v = Tuple.Vector(x, y, z);
        }

        [Then(@"v == tuple\((.*), (.*), (.*), (.*)\)")]
        public void ThenVTuple(double x, double y, double z, double w)
        {
            var t = new Tuple(x, y, z, w);
            Assert.AreEqual(t, v);
        }

        //
        // Adding two tuples
        private Tuple aa, ab;
        [Given(@"aa = tuple\((.*), (.*), (.*), (.*)\)")]
        public void GivenAaTuple(double x, double y, double z, double w)
        {
            aa = new Tuple(x, y, z, w);
        }

        [Given(@"ab = tuple\((.*), (.*), (.*), (.*)\)")]
        public void GivenAbTuple(double x, double y, double z, double w)
        {
            ab = new Tuple(x, y, z, w);
        }

        [Then(@"aa \+ ab == tuple\((.*), (.*), (.*), (.*)\)")]
        public void ThenAaAbTuple(double x, double y, double z, double w)
        {
            var expected = new Tuple(x, y, z, w);
            var result = Tuple.Add(aa, ab);
            Assert.AreEqual(expected, result);
        }

        //
        // subtracting two points
        Tuple pa, pb;
        [Given(@"pa = point\((.*), (.*), (.*)\)")]
        public void GivenPaPoint(double x, double y, double z)
        {
            pa = Tuple.Point(x, y, z);
        }

        [Given(@"pb = point\((.*), (.*), (.*)\)")]
        public void GivenPbPoint(double x, double y, double z)
        {
            pb = Tuple.Point(x, y, z);
        }

        [Then(@"pa - pb == vector\((.*), (.*), (.*)\)")]
        public void ThenPa_PbVector(double x, double y, double z)
        {
            var expected = Tuple.Vector(x, y, z);
            var result = Tuple.Subtract(pa, pb);
            Assert.AreEqual(expected, result);
        }

        //
        // Subtracting a vector from a point
        Tuple pc, vc;
        [Given(@"pc = point\((.*), (.*), (.*)\)")]
        public void GivenPcPoint(double x, double y, double z)
        {
            pc = Tuple.Point(x, y, z);
        }

        [Given(@"vc = vector\((.*), (.*), (.*)\)")]
        public void GivenVcVector(double x, double y, double z)
        {
            vc = Tuple.Vector(x, y, z);
        }

        [Then(@"pc - vc == point\((.*), (.*), (.*)\)")]
        public void ThenPc_VcPoint(double x, double y, double z)
        {
            var expected = Tuple.Point(x, y, z);
            var result = Tuple.Subtract(pc, vc);
            Assert.AreEqual(expected, result);
        }

        //
        // Subtracting two vectors
        private Tuple vi, vii;
        [Given(@"vi = vector\((.*), (.*), (.*)\)")]
        public void GivenViVector(double x, double y, double z)
        {
            vi = Tuple.Vector(x, y, z);
        }

        [Given(@"vii = vector\((.*), (.*), (.*)\)")]
        public void GivenViiVector(double x, double y, double z)
        {
            vii = Tuple.Vector(x, y, z);
        }

        [Then(@"vi -vii = vector\((.*), (.*), (.*)\)")]
        public void ThenVi_ViiVector(double x, double y, double z)
        {
            var expected = Tuple.Vector(x, y, z);
            var result = Tuple.Subtract(vi, vii);
            Assert.AreEqual(expected, result);
        }

        //
        // Subtracting a vector from the zero vector
        private Tuple zero, viii;
        [Given(@"zero = vector\((.*), (.*), (.*)\)")]
        public void GivenZeroVector(double x, double y, double z)
        {
            zero = Tuple.Vector(x, y, z);
        }

        [Given(@"viii = vector\((.*), (.*), (.*)\)")]
        public void GivenViiiVector(double x, double y, double z)
        {
            viii = Tuple.Vector(x, y, z);
        }

        [Then(@"zero - viii == vector\((.*), (.*), (.*)\)")]
        public void ThenZero_ViiiVector(double x, double y, double z)
        {
            var expected = Tuple.Vector(x, y, z);
            var result = Tuple.Subtract(zero, viii);
            System.Diagnostics.Trace.WriteLine("Hello");
            Assert.AreEqual(expected, result);
        }

        //
        // Negating a tuple
        [Then(@"-a = tuple\((.*), (.*), (.*), (.*)\)")]
        public void Then_ATuple(double x, double y, double z, double w)
        {
            var expected = new Tuple(x, y, z, w);
            var result = -a;
            Assert.AreEqual(expected, result);
        }

        //
        // Multiplying a tuple by a scalar
        [Then(@"a \* (.*) == tuple\((.*), (.*), (.*), (.*)\)")]
        public void ThenATuple(double scalar, double x, double y, double z, double w)
        {
            var expected = new Tuple(x, y, z, w);
            var result = a * scalar;
            Assert.AreEqual(expected, result);
        }

        //
        // Dividing a tuple by a scalar
        [Then(@"a divided by (.*) = tuple\((.*), (.*), (.*), (.*)\)")]
        public void ThenADividedByTuple(double scalar, double x, double y, double z, double w)
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

        [Then(@"magnitude\(v\) == square root of \((.*)\)")]
        public void ThenMagnitudeVSquareRootOf(int magnitude)
        {
            Assert.AreEqual(Math.Sqrt(magnitude), v.Magnitude);
        }

        //
        // Normalizing a vector
        [Then(@"normalize\(v\) = vector\((.*), (.*), (.*)\)")]
        public void ThenNormalizeVVector(double x, double y, double z)
        {
            Tuple expected = Tuple.Vector(x, y, z);
            var result = Tuple.Normalize(v);
            Assert.AreEqual(expected, result);
        }

        [Then(@"normalize\(v\) = approximately vector\((.*), (.*), (.*)\)")]
        public void ThenNormalizeVApproximatelyVector(double x, double y, double z)
        {
            Tuple expected = Tuple.Vector(x, y, z);
            var result = Tuple.Normalize(v);
            Assert.AreEqual(expected, result);
        }

        Tuple norm;
        [When(@"norm = normalize\(v\)")]
        public void WhenNormNormalizeV()
        {
            norm = Tuple.Normalize(v);
        }

        [Then(@"magnitude\(norm\) = (.*)")]
        public void ThenMagnitudeNorm(double n)
        {
            Assert.AreEqual(n, norm.Magnitude);
        }



    }
}
