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

Scenario: Subtracting a vector from the zero vector
	Given zero = vector(0, 0, 0)
	And viii = vector(1, -2, 3)
	Then zero - viii == vector(-1, 2, -3)

Scenario: Negating a tuple
	Given a = tuple(1, -2, 3, -4)
	Then -a = tuple(-1, 2, -3, 4)

Scenario: Multiplying a tuple by a scalar
	Given a = tuple(1, -2, 3, -4)
	Then a * 3.5 == tuple(3.5, -7, 10.5, -14)

Scenario: Multiplying a tuple by a fraction
	Given a = tuple(1, -2, 3, -4)
	Then a * 0.5 == tuple(0.5, -1, 1.5, -2)

Scenario: Dividing a tuple by a scalar
	Given a = tuple(1, -2, 3, -4)
	Then a divided by 2 = tuple(0.5, -1, 1.5, -2)

Scenario: Computing the magnitude of a vector(1, 0, 0)
	Given v = vector(1, 0, 0)
	Then magnitude(v) = 1

Scenario: Computing the magnitude of a vector(0, 1, 0)
	Given v = vector(0, 1, 0)
	Then magnitude(v) = 1

Scenario: Computing the magnitude of a vector(0, 0, 1)
	Given v = vector(0, 0, 1)
	Then magnitude(v) = 1

Scenario: Computing the magnitude of a vector(1, 2, 3)
	Given v = vector(1, 2, 3)
	Then magnitude(v) = 3.741657386773941‬3

Scenario: Computing the magnitude of a vector(-1, -2, -3)
	Given v = vector(-1, -2, -3)
	Then magnitude(v) = 3.741657386773941‬3

