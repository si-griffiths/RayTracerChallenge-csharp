Feature: Matrices

Scenario: Constructing and inspecting a 4x4 Matrix
	Given the following "4x4" matrix m:
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
