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

Scenario: A matrix multiplied by a tuple
	Given the following matrixA:
         | 1 | 2 | 3 | 4 |
		 | 1 | 2 | 3 | 4 |
         | 2 | 4 | 4 | 2 |
         | 8 | 6 | 4 | 1 |
         | 0 | 0 | 0 | 1 |
	And tupleB = tuple(1, 2, 3, 1)
	Then matrixA * tupleB = tuple(18, 24, 33, 1)

Scenario: Multiplying a matrix by the identity matrix
	Given the following matrixA:
		| 1 | 2 | 3  | 4  |
		| 0 | 1 | 2  | 4  |
		| 1 | 2 | 4  | 8  |
		| 2 | 4 | 8  | 16 |
		| 4 | 8 | 16 | 32 |
	Then matrixA * identity_matrix == matrixA

Scenario: Transposing a matrix
	Given the following matrixA:
		| 1 | 2 | 3 | 4 |
		| 0 | 9 | 3 | 0 |
		| 9 | 8 | 0 | 8 |
		| 1 | 8 | 5 | 3 |
		| 0 | 0 | 5 | 8 |
	Then Transpose(matrixA) is the following matrix:
		| 1 | 2 | 3 | 4 |
		| 0 | 9 | 1 | 0 |
		| 9 | 8 | 8 | 0 |
		| 3 | 0 | 5 | 5 |
		| 0 | 8 | 3 | 8 |

Scenario: Transposing the identity matrix
	Given matrixA = Transpose(identity_matrix)
	Then matrixA == identity_matrix

Scenario: Calculating the determinant of a 2x2 matrix
	Given the following two by two matrixA:
		| 1  | 2 |
		| 1  | 5 |
		| -3 | 2 |
	Then determinant(A) == 17

Scenario: A submatrix of a three_by_three matrix is a two_by_two matrix
	Given the following three_by_three matrix matrixA
		| 1  | 2 | 3  |
		| 1  | 5 | 0  |
		| -3 | 2 | 7  |
		| 0  | 6 | -3 |
	Then Submatrix(matrixA, 0, 2) is the following two_by_two matrix:
		| 1  | 2 |
		| -3 | 2 |
		| 0  | 6 |

Scenario: A submatrix of a four_by_four matrix is a three_by_three matrix
	Given the following four_by_four matrix matrixA:
		| 1  | 2 | 3  | 4 |
		| -6 | 1 | 1  | 6 |
		| -8 | 5 | 8  | 6 |
		| -1 | 0 | 8  | 2 |
		| -7 | 1 | -1 | 1 |
	Then Submatrix(matrixA, 2, 1) is the following three_by_three matrix:
         | 1  | 2  | 3 |
         | -6 | 1  | 6 |
         | -8 | 8  | 6 |
         | -7 | -1 | 1 |

Scenario: Calculating the minor of a 3x3 matrix
	Given the following three_by_three matrix matrixA
	| 1 | 2  | 3  |
	| 3 | 5  | 0  |
	| 2 | -1 | -7 |
	| 6 | -1 | 5  |
	And matrixB = Submatrix(matrixA, 1, 0)
	Then Determinant(matrixB) == 25
	And Minor(matrixA, 1, 0) == 25
	
Scenario: Calculating a cofactor of a 3x3 matrix
	Given the following three_by_three matrix matrixA
         | 1 | 2  | 3  |
         | 3 | 5  | 0  |
         | 2 | -1 | -7 |
         | 6 | -1 | 5  |
	Then Minor(matrixA, 0, 0) == -12
	And Cofactor(matrixA, 0, 0) == -12
	And Minor(matrixA, 1, 0) == 25
	And Cofactor(matrixA, 1, 0) == -25


