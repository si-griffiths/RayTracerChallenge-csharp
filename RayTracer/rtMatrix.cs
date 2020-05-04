using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RayTracer
{
    public class rtMatrix
    {
        private double[,] matrixValues;

        public double[,] MatrixValues { get => matrixValues; private set => matrixValues = value; } // todo: Remove this property

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
            MatrixValues = new double[4, 4] { { v1, v2, v3, v4 }, { v5, v6, v7, v8 }, { v9, v10, v11, v12 }, { v13, v14, v15, v16 } };
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
            MatrixValues = new double[2, 2] { { v1, v2 }, { v3, v4 } };
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
            MatrixValues = new double[3, 3] { { v1, v2, v3 }, { v4, v5, v6 }, { v7, v8, v9 } };
        }

        public static rtMatrix operator *(rtMatrix first, rtMatrix second) => Multiply(first, second);

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

        public double GetValue(int row, int column)
        {
            return MatrixValues[row, column];
        }

        public void SetValue(int row, int column, double value)
        {
            matrixValues[row, column] = value;
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
    }
}
