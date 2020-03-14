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
    }
}
