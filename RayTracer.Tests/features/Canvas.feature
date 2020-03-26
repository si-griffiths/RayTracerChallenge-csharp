Feature: Canvas
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Creating a canvas
	Given c = Canvas(10, 20)
	Then c.Width = 10
	And c.Height = 20
	And every pixel of c is Color(0, 0, 0)
