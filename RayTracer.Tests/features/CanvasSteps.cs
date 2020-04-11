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
            ppm = c.CanvasToPpm();
        }

        [Then(@"lines one to three of ppm are")]
        public void ThenLinesOneToThreeOfPpmAre(string multilineText)
        {
            var expectedLines = multilineText.Split(Environment.NewLine);
            var actualLines = ppm.Split(Environment.NewLine);

            Assert.AreEqual(expectedLines[0], actualLines[0]);
            Assert.AreEqual(expectedLines[1], actualLines[1]);
            Assert.AreEqual(expectedLines[2], actualLines[2]);
        }

        // Constructing the PPM pixel data
        private Color colorA, colorB, colorC;
        [Given(@"colorA = Color\((.*), (.*), (.*)\)")]
        public void GivenColorAColor(double red, double green, double blue)
        {
            colorA = new Color(red, green, blue);
        }

        [Given(@"colorB = Color\((.*), (.*), (.*)\)")]
        public void GivenColorBColor(double red, double green, double blue)
        {
            colorB = new Color(red, green, blue);
        }

        [Given(@"colorC = Color\((.*), (.*), (.*)\)")]
        public void GivenColorCColor(double red, double green, double blue)
        {
            colorC = new Color(red, green, blue);
        }

        [When(@"WritePixel\(c, (.*), (.*), colorA\)")]
        public void WhenWritePixelCCA(int x, int y)
        {
            c.WritePixel(x, y, colorA);
        }

        [When(@"WritePixel\(c, (.*), (.*), colorB\)")]
        public void WhenWritePixelCCB(int x, int y)
        {
            c.WritePixel(x, y, colorB);
        }

        [When(@"WritePixel\(x, (.*), (.*), colorC\)")]
        public void WhenWritePixelXCC(int x, int y)
        {
            c.WritePixel(x, y, colorC);
        }

        [Then(@"lines four to six of ppm are")]
        public void ThenLinesFourToSixOfPpmAre(string multilineText)
        {
            ppm = c.CanvasToPpm();
            var expectedLines = multilineText.Split(Environment.NewLine);
            var actualLines = ppm.Split(Environment.NewLine);

            Assert.AreEqual(expectedLines[0], actualLines[3]);
            Assert.AreEqual(expectedLines[1], actualLines[4]);
            Assert.AreEqual(expectedLines[2], actualLines[5]);
        }

        // Splitting long lines in PPM files
        [When(@"every pixel of c is set to Color\((.*), (.*), (.*)\)")]
        public void WhenEveryPixelOfCIsSetToColor(double red, double green, double blue)
        {
            var color = new Color(red, green, blue);
            c.InitializePixels(color);
        }

        [Then(@"lines four to seven of ppm are")]
        public void ThenLinesFourToSevenOfPpmAre(string multilineText)
        {
            ppm = c.CanvasToPpm();
            var expectedLines = multilineText.Split(Environment.NewLine);
            var actualLines = ppm.Split(Environment.NewLine);

            Assert.AreEqual(expectedLines[0], actualLines[3]);
            Assert.AreEqual(expectedLines[1], actualLines[4]);
            Assert.AreEqual(expectedLines[2], actualLines[5]);
            Assert.AreEqual(expectedLines[3], actualLines[6]);
        }



    }
}
