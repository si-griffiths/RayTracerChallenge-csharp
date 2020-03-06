Feature: tuples
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: A tuple with w=1.0 is a point
	Given a = tuple(4.3, -4.2, 3.1, 1.0)
	Then  a.x == 4.3
	And a.y == -4.2
	And a.z == 3.1
	And a.w == 1.0
	And a is a point
	And a is not a vector

Scenario: A tuple with w=0 is a vector
	Given b = tuple(4.3, -4.2, 3.1, 0)
	Then b.x == 4.3
	And b.y == -4.2
	And b.z == 3.1
	And b.w == 0
	And b is a not a point
	And b is a vector

Scenario: Point() creates tuple with w=1
	Given p = point(4, -4, 3)
	Then p == tuple(4, -4, 3, 1)

Scenario: Vector() create tuple with w=0
	Given v = vector(4, -4, 3)
	Then v == tuple(4, -4, 3, 0)

Scenario: Adding two tuples
	Given aa = tuple(3, -2, 5, 1)
	And ab = tuple(-2, 3, 1, 0)
	Then aa + ab == tuple(1, 1, 6, 1)

Scenario:  Subtracting two points
	Given pa = point(3, 2, 1)
	And pb = point(5, 6, 7)
	Then pa - pb == vector(-2, -4, -6)

Scenario: Subtracting a vector from a point
	Given pc = point(3, 2, 1)
	And vc = vector(5, 6, 7)
	Then pc - vc == point(-2, -4, -6)

Scenario: Subtracting two vectors
	Given vi = vector(3, 2, 1)
	And vii = vector(5, 6, 7)
	Then vi -vii = vector(-2, -4, -6)

