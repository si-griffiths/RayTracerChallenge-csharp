Feature: Matrices

Scenario: Constructing and inspecting a 4x4 Matrix
	Given the following four by four matrix m:
	| 1    | 2    | 3    | 4    |
	| 1    | 2    | 3    | 4    |
	| 5.5  | 6.5  | 7.5  | 8.5  |
	| 9    | 10   | 11   | 12   |
	| 13.5 | 14.5 | 15.5 | 16.5 |
	Then m(0, 0) == 1
	And m(0, 3) == 4
	And m(1, 0) == 5.5
	And m(1, 2) == 7.5
	And m(2, 2) == 11
	And m(3, 0) == 13.5
	And m(3, 2) == 15.5

Scenario: A 2x2 matrix ought to be representable
	Given the following two by two matrix m:
	| 1  | 2  |
	| -3 | 5  |
	| 1  | -2 |
	Then m(0, 0) == -3
	And m(0, 1) == 5
	And m(1, 0) == 1
	And m(1, 1) == -2

Scenario: A 3x3 matrix ought to be representable
	Given the following three by three matrix m:
	| 1  | 2  | 3  |
	| -3 | 5  | 0  |
	| 1  | -2 | -7 |
	| 0  | 1  | 1  |
	Then m(0, 0) == -3
	And m(1, 1) == -2
	And m(2, 2) == 1

