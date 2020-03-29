using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace RayTracer.Tests
{
    [Binding]
    public class CanvasSteps
    {
        // Creating a canvas
        Canvas c;
        [Given(@"c = Canvas\((.*), (.*)\)")]
        public void GivenCCanvas(int width, int height)
        {
            c = new Canvas(width, height);
        }
        
        [Then(@"c\.Width = (.*)")]
        public void ThenC_Width(int width)
        {
            Assert.AreEqual(width, c.Width);
        }
        
        [Then(@"c\.Height = (.*)")]
        public void ThenC_Height(int height)
        {
            Assert.AreEqual(height, c.Height);
        }
        
        [Then(@"every pixel of c is Color\((.*), (.*), (.*)\)")]
        public void ThenEveryPixelOfCIsColor(double red, double green, double blue)
        {
            var expectedColor = new Color(red, green, blue);
            foreach(Color actualColor in c.Pixels)
            {
                Assert.AreEqual(expectedColor, actualColor);
            }
        }

        // Constructing the PPM header
        private string ppm = "";
        [When(@"ppm = CanvasToPpm\(c\)")]
        public void WhenPpmCanvasToPpmC()
        {
            ppm = Canvas.CanvasToPpm(c);
        }

        [Then(@"lines one to three of ppm are")]
        public void ThenLinesOneToThreeOfPpmAre(string multilineText)
        {
            Assert.AreEqual(multilineText, ppm);
        }

    }
}
