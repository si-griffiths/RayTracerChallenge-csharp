﻿Feature: tuples
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: A tuple with w=1.0 is a point
	Given a <- tuple(4.3, -4.2, 3.1, 1.0)
	Then  a.x = 4.3
	And a.y = -4.2
	And a.z = 3.1
	And a.w = 1.0
	And a is a point
	And a is not a vector

Scenario: A tuple with w=0 is a vector
	Given b <- tuple(4.3, -4.2, 3.1, 0)
	Then b.x = 4.3
	And b.y = -4.2
	And b.z = 3.1
	And b.w = 0
	And b is a not a point
	And b is a vector

Scenario: Point() creates tuple with w=1
	Given p <- point(4, -4, 3)
	Then p = tuple(4, -4, 3, 1)

Scenario: Vector() create tuple with w=0
	Given v <- vector(4, -4, 3)
	Then v = tuple(4, -4, 3, 0)

Scenario: Adding two tuples
	Given a1 <- tuple(3, -2, 5, 1)
	And a2 <- tuple(-2, 3, 1, 0)
	Then a1 + a2 = tuple(1, 1, 6, 1)

