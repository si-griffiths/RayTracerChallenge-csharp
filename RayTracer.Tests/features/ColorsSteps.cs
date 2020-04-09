using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace RayTracer.Tests.features
{
    [Binding]

    public class ColorsSteps
    {
        private Color c;
        [Given(@"c = Color\((.*), (.*), (.*)\)")]
        public void GivenCColor(double red, double green, double blue)
        {
            c = new Color(red, green, blue);
        }
        
        [Then(@"c\.Red == (.*)")]
        public void ThenC_Red(float red)
        {
            Assert.AreEqual(red, c.Red);
        }
        
        [Then(@"c\.Green == (.*)")]
        public void ThenC_Green(double green)
        {
            Assert.AreEqual(green, c.Green);
        }
        
        [Then(@"c\.Blue == (.*)")]
        public void ThenC_Blue(double blue)
        {
            Assert.AreEqual(blue, c.Blue);
        }

        // Adding colors
        private Color cA, cB;
        [Given(@"cA = Color\((.*), (.*), (.*)\)")]
        public void GivenCAColor(double red, double green, double blue)
        {
            cA = new Color(red, green, blue);
        }

        [Given(@"cB = Color\((.*), (.*), (.*)\)")]
        public void GivenCBColor(double red, double green, double blue)
        {
            cB = new Color(red, green, blue);
        }

        [Then(@"cA \+ cB = color\((.*), (.*), (.*)\)")]
        public void ThenCACBColor(double red, double green, double blue)
        {
            var expected = new Color(red, green, blue);
            var actual = cA + cB;
            Assert.AreEqual(expected, actual);
        }

        // Subtracting colors
        [Then(@"cA - cB = color\((.*), (.*), (.*)\)")]
        public void ThenCA_CBColor(double red, double green, double blue)
        {
            var expected = new Color(red, green, blue);
            var actual = cA - cB;
            Assert.AreEqual(expected, actual);
        }

        // Multiplying a color by a scalar
        [Then(@"c \* (.*) = Color\((.*), (.*), (.*)\)")]
        public void ThenCColor(double scalar, double red, double green, double blue)
        {
            var expected = new Color(red, green, blue);
            var actual = scalar * c;
            Assert.AreEqual(expected, actual);
        }

        // Multiplying colors
        [Then(@"cA multiplied by cB == Color\((.*), (.*), (.*)\)")]
        public void ThenCAMultipliedByCBColor(double red, double green, double blue)
        {
            var expected = cA * cB;
            var actual = new Color(red, green, blue);
            Assert.AreEqual(expected, actual);
        }

    }
}
