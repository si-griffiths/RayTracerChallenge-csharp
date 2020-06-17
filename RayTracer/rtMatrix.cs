using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RayTracer
{
    public class rtMatrix
    {
        private double[,] matrixValues;

        /// <summary>
        /// Constructor for a 4x4 Matrix
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        /// <param name="v4"></param>
        /// <param name="v5"></param>
        /// <param name="v6"></param>
        /// <param name="v7"></param>
        /// <param name="v8"></param>
        /// <param name="v9"></param>
        /// <param name="v10"></param>
        /// <param name="v11"></param>
        /// <param name="v12"></param>
        /// <param name="v13"></param>
        /// <param name="v14"></param>
        /// <param name="v15"></param>
        /// <param name="v16"></param>
        public rtMatrix(double v1, double v2, double v3, double v4, double v5, double v6, double v7, double v8, double v9, double v10, double v11, double v12, double v13, double v14, double v15, double v16)
        {
            matrixValues = new double[4, 4] { { v1, v2, v3, v4 }, { v5, v6, v7, v8 }, { v9, v10, v11, v12 }, { v13, v14, v15, v16 } };
        }

        /// <summary>
        /// Constructor for a 2x2 Matrix
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        /// <param name="v4"></param>
        public rtMatrix(double v1, double v2, double v3, double v4)
        {
            matrixValues = new double[2, 2] { { v1, v2 }, { v3, v4 } };
        }

        /// <summary>
        /// Constructor for a 3x3 Matrix
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        /// <param name="v4"></param>
        /// <param name="v5"></param>
        /// <param name="v6"></param>
        /// <param name="v7"></param>
        /// <param name="v8"></param>
        /// <param name="v9"></param>
        public rtMatrix(double v1, double v2, double v3, double v4, double v5, double v6, double v7, double v8, double v9)
        {
            matrixValues = new double[3, 3] { { v1, v2, v3 }, { v4, v5, v6 }, { v7, v8, v9 } };
        }

        public static rtMatrix operator *(rtMatrix first, rtMatrix second) => Multiply(first, second);

        public static Tuple operator *(rtMatrix matrix, Tuple tuple) => Multiply(matrix, tuple);

        public static Tuple operator *(Tuple tuple, rtMatrix matrix) => Multiply(matrix, tuple);

        /// <summary>
        /// Multiply two 4x4 matrices
        /// This will not work with matrices of different sizes
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static rtMatrix Multiply(rtMatrix first, rtMatrix second)
        {
            var result = new rtMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0); // need a better way to initialise a 4x4 matrix
            for(int row = 0; row < 4; row++)
            {
                for(int column = 0; column < 4; column++)
                {
                    double value =
                        first.GetValue(row, 0) * second.GetValue(0, column) +
                        first.GetValue(row, 1) * second.GetValue(1, column) +
                        first.GetValue(row, 2) * second.GetValue(2, column) +
                        first.GetValue(row, 3) * second.GetValue(3, column);
                    result.SetValue(row, column, value);
                }
            }
            return result;
        }

        public static Tuple Multiply(rtMatrix matrix, Tuple tuple)
        {
            double x = (matrix.GetValue(0, 0) * tuple.X) + (matrix.GetValue(0, 1) * tuple.Y) + (matrix.GetValue(0, 2) * tuple.Z) + (matrix.GetValue(0, 3) * tuple.W);
            double y = (matrix.GetValue(1, 0) * tuple.X) + (matrix.GetValue(1, 1) * tuple.Y) + (matrix.GetValue(1, 2) * tuple.Z) + (matrix.GetValue(1, 3) * tuple.W);
            double z = (matrix.GetValue(2, 0) * tuple.X) + (matrix.GetValue(2, 1) * tuple.Y) + (matrix.GetValue(2, 2) * tuple.Z) + (matrix.GetValue(2, 3) * tuple.W);
            double w = (matrix.GetValue(3, 0) * tuple.X) + (matrix.GetValue(3, 1) * tuple.Y) + (matrix.GetValue(3, 2) * tuple.Z) + (matrix.GetValue(3, 3) * tuple.W);
            
            return new Tuple(x, y, z, w);
        }

        public static double Determinant(rtMatrix matrix)
        {
            // assuming a 2x2 matrix for now...
            var a = matrix.GetValue(0, 0);
            var b = matrix.GetValue(0, 1);
            var c = matrix.GetValue(1, 0);
            var d = matrix.GetValue(1, 1);
            return (a * d) - (b * c);
        }

        /// <summary>
        /// Create a submatrix from the given matrix with the indicated row and column removed
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public rtMatrix Submatrix(int rowForRemoval, int columnForRemoval)
        {
            rtMatrix submatrix;
            int matrixSize = 0;
            switch (matrixValues.Length)
            {
                // 4x4
                case 16:
                    submatrix = new rtMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0);
                    matrixSize = 3;
                    break;

                // 3x3
                case 9:
                    submatrix = new rtMatrix(0, 0, 0, 0);
                    matrixSize = 2;
                    break;
                
                default:
                    throw new Exception("Cannot create a submatrix from a matrix of this size");
            }

            int ar = 0; // the original matrix row
            for (int sr = 0; sr < matrixSize; sr++)
            {
                if (ar == rowForRemoval)
                { 
                    ar++;
                }
                int ac = 0; // the original matrix column
                for (int sc = 0; sc < matrixSize; sc ++)
                {
                    if (ac == columnForRemoval)
                    {
                        ac++;
                    }
                    var value = this.GetValue(ar, ac);
                    submatrix.SetValue(sr, sc, value);
                    ac++;
                }
                ar++;
            }

            return submatrix;
        }

        public double GetValue(int row, int column)
        {
            return matrixValues[row, column];
        }

        public void SetValue(int row, int column, double value)
        {
            matrixValues[row, column] = value;
        }

        /// <summary>
        /// Transposes the current matrix
        /// </summary>
        /// <returns>A transposed matrix</returns>
        public rtMatrix Transpose()
        {
            var transposedMatrix = new rtMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            for(int row = 0; row < 4; row++)
            {
                for(int column = 0; column < 4; column++)
                {
                    double value = this.GetValue(row, column);
                    transposedMatrix.SetValue(column, row, value); // reverse the row and column to transpose the value
                }
            }
            return transposedMatrix;
        }

        public override bool Equals(object obj)
        {
            // this will not work comparing matrices of different sizes
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                rtMatrix m = (rtMatrix)obj;
                for (int row = 0; row < matrixValues.GetLength(0); row++)
                {
                    for (int column = 0; column < matrixValues.GetLength(1); column++)
                    {
                        var thisValue = GetValue(row, column);
                        var thatValue = m.GetValue(row, column);
                        if (!Tuple.Equal(thisValue, thatValue))
                        {
                            return false;
                        }

                    }
                }
                return true;
            }
        }

        public static rtMatrix IdentityMatrix()
        {
            return new rtMatrix(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
        }

        /// <summary>
        /// The Minor value is determinant of the Submatrix(row, column)
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public double Minor(int row, int column)
        {
            var submatrix = this.Submatrix(row, column);
            var determinant = Determinant(submatrix);
            return determinant;
        }

        /// <summary>
        /// Cofactors are minors that have (possibly) had their sign changed
        /// The minor is negated if row+colum is an odd number
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public double Cofactor(int row, int column)
        {
            double minor = this.Minor(row, column);
            if ((row + column) % 2 == 0)
            {
                return minor;
            }
            return -minor;
        }
    }
}
