Feature: Canvas
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Creating a canvas
	Given c = Canvas(10, 20)
	Then c.Width = 10
	And c.Height = 20
	And every pixel of c is Color(0, 0, 0)

Scenario: Constructing the PPM header
	Given c = Canvas(5, 3)
	When ppm = CanvasToPpm(c)
	Then lines one to three of ppm are
	"""
	P3
	5 3
	255
	"""

Scenario: Constructing the PPM pixel data
	Given c = Canvas(5, 3)
	And colorA = Color(1.5, 0, 0)
	And colorB = Color(0, 0.5, 0)
	And colorC = Color(-0.5, 0, 1)
	When WritePixel(c, 0, 0, colorA)
	And WritePixel(c, 2, 1, colorB)
	And WritePixel(x, 4, 2, colorC)
	And ppm = CanvasToPpm(c)
	Then lines four to six of ppm are
	"""
	255 0 0 0 0 0 0 0 0 0 0 0 0 0 0
	0 0 0 0 0 0 0 128 0 0 0 0 0 0 0
	0 0 0 0 0 0 0 0 0 0 0 0 0 0 255
	"""

Scenario: Splitting long lines in PPM files
	Given c = Canvas(10, 2)
	When every pixel of c is set to Color(1, 0.8, 0.6)
	And ppm = CanvasToPpm(c)
	Then lines four to seven of ppm are
         """
         255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204
		 153 255 204 153 255 204 153 255 204 153 255 204 153
		 255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204
		 153 255 204 153 255 204 153 255 204 153 255 204 153
         """

Scenario: PPM files are terminated by a new character
	Given c = Canvas(5, 3)
	When ppm = CanvasToPpm(c)
	Then ppm ends with a newline character


