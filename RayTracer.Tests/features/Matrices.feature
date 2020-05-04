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

Scenario: Matrix equality with identical matrices
	Given the following matrixA:
	| 1 | 2 | 3 | 4 |
	| 1 | 2 | 3 | 4 |
	| 5 | 6 | 7 | 8 |
	| 9 | 8 | 7 | 6 |
	| 5 | 4 | 3 | 2 |
	And the following matrixB:
	| 1 | 2 | 3 | 4 |
	| 1 | 2 | 3 | 4 |
	| 5 | 6 | 7 | 8 |
	| 9 | 8 | 7 | 6 |
	| 5 | 4 | 3 | 2 |
	Then matrixA == matrixB

Scenario: Matrix equality with different matrices
	Given the following matrixA:
	| 1 | 2 | 3 | 4 |
	| 1 | 2 | 3 | 4 |
	| 5 | 6 | 7 | 8 |
	| 9 | 8 | 7 | 6 |
	| 5 | 4 | 3 | 2 |
	And the following matrixB:
	| 1 | 2 | 3 | 4 |
	| 2 | 3 | 4 | 5 |
	| 6 | 7 | 8 | 9 |
	| 8 | 7 | 6 | 5 |
	| 4 | 3 | 2 | 2 |
	Then matrixA not equal to matrixB

Scenario: Multiplying two matrices
	Given the following matrixA:
	| 1 | 2 | 3 | 4 |
	| 1 | 2 | 3 | 4 |
	| 5 | 6 | 7 | 8 |
	| 9 | 8 | 7 | 6 |
	| 5 | 4 | 3 | 2 |
	And the following matrixB:
	| 1  | 2 | 3 | 4  |
	| -2 | 1 | 2 | 3  |
	| 3  | 2 | 1 | -1 |
	| 4  | 3 | 6 | 5  |
	| 1  | 2 | 7 | 8  |
	Then matrixA * matrixB is the follwing matrix:
	| 1  | 2  | 3   | 4   |
	| 20 | 22 | 50  | 48  |
	| 44 | 54 | 114 | 108 |
	| 40 | 58 | 110 | 102 |
	| 16 | 26 | 46  | 42  |


