using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer
{
    public class rtMatrix4x4
    {
        private double[,] matrixValues;

        public rtMatrix4x4(double v1, double v2, double v3, double v4, double v5, double v6, double v7, double v8, double v9, double v10, double v11, double v12, double v13, double v14, double v15, double v16)
        {
            matrixValues = new double[4, 4] { { v1, v2, v3, v4 }, { v5, v6, v7, v8 }, { v9, v10, v11, v12 }, { v13, v14, v15, v16 } };
        }

        public double GetValue(int row, int column)
        {
            return matrixValues[row, column];
        }
    }
}
