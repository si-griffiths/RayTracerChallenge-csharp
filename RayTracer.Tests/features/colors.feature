Feature: colors
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Colors are (red, green, blue) tuples
	Given c = Color(-0.5, 0.4, 1.7)
	Then c.Red == -0.5
	And c.Green == 0.4
	And c.Blue == 1.7

Scenario: Adding colors
	Given cA = Color(0.9, 0.6, 0.75)
	And cB = Color(0.7, 0.1, 0.25)
	Then cA + cB = color(1.6, 0.7, 1.0)

Scenario: Subtracting colors
	Given cA = Color(0.9, 0.6, 0.75)
	And cB = Color(0.7, 0.1, 0.25)
	Then cA - cB = color(0.2, 0.5, 0.5)

Scenario: Multiplying a color by a scalar
	Given c = Color(0.2, 0.3, 0.4)
	Then c * 2.0 = Color(0.4, 0.6, 0.8)

Scenario: Multiplying colors
	Given cA = Color(1, 0.2, 0.4)
	And cB = Color(0.9, 1, 0.1)
	Then cA multiplied by cB == Color(0.9, 0.2, 0.04)


