Feature: colors
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Colors are (red, green, blue) tuples
	Given c = Color(-0.5, 0.4, 1.7)
	Then c.Red == -0.5
	And c.Green == 0.4
	And c.Blue == 1.7
