using Gherkin.Events.Args.Pickle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using TechTalk.SpecFlow;

namespace RayTracer.Tests.features
{
    [Binding]
    public class MatricesSteps
    {
        private rtMatrix matrix;
        [Given(@"the following four by four matrix m:")]
        public void GivenTheFollowingMatrixM(Table table)
        {
            matrix = Create4x4MatrixFromTable(table);
        }
        
        [Then(@"m\((.*), (.*)\) == (.*)")]
        public void ThenM(int row, int column, double expectedValue)
        {
            var value = matrix.GetValue(row, column);
            Assert.AreEqual(expectedValue, value);
        }

        [Given(@"the following two by two matrix m:")]
        public void GivenTheFollowingTwoByTwoMatrixM(Table table)
        {
            double[] row1 = Array.ConvertAll(table.Rows[0].Values.ToArray(), double.Parse);
            double[] row2 = Array.ConvertAll(table.Rows[1].Values.ToArray(), double.Parse);

            matrix = new rtMatrix(row1[0], row1[1], row2[0], row2[1]);
        }

        [Given(@"the following three by three matrix m:")]
        public void GivenTheFollowingThreeByThreeMatrixM(Table table)
        {
            double[] row1 = Array.ConvertAll(table.Rows[0].Values.ToArray(), double.Parse);
            double[] row2 = Array.ConvertAll(table.Rows[1].Values.ToArray(), double.Parse);
            double[] row3 = Array.ConvertAll(table.Rows[2].Values.ToArray(), double.Parse);

            matrix = new rtMatrix(row1[0], row1[1], row1[2], row2[0], row2[1], row2[2], row3[0], row3[1], row3[2]);
        }

        private rtMatrix matrixA, matrixB;
        [Given(@"the following matrixA:")]
        public void GivenTheFollowingMatrixA(Table table)
        {
            matrixA = Create4x4MatrixFromTable(table);
        }

        [Given(@"the following matrixB:")]
        public void GivenTheFollowingMatrixB(Table table)
        {
            matrixB = Create4x4MatrixFromTable(table);
        }

        [Then(@"matrixA == matrixB")]
        public void ThenMatrixAMatrixB()
        {
            Assert.IsTrue(matrixA.Equals(matrixB));
        }

        [Then(@"matrixA not equal to matrixB")]
        public void ThenMatrixANotEqualToMatrixB()
        {
            Assert.AreNotEqual(matrixA, matrixB);
        }

        [Then(@"matrixA \* matrixB is the follwing matrix:")]
        public void ThenMatrixAMatrixBIsTheFollwingMatrix(Table table)
        {
            var expected = Create4x4MatrixFromTable(table);

            rtMatrix result = matrixA * matrixB;
            Assert.AreEqual(expected, result);
        }

        private Tuple tupleB;
        [Given(@"tupleB = tuple\((.*), (.*), (.*), (.*)\)")]
        public void GivenTupleBTuple(double x, double y, double z, double w)
        {
            tupleB = new Tuple(x, y, z, w);
        }

        [Then(@"matrixA \* tupleB = tuple\((.*), (.*), (.*), (.*)\)")]
        public void ThenMatrixATupleBTuple(double x, double y, double z, double w)
        {
            var expected = new Tuple(x, y, z, w);
            var actual = matrixA * tupleB;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Helper method to create a matrix from a SpecFlow table
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private rtMatrix Create4x4MatrixFromTable(Table table)
        {
            double[] row1 = Array.ConvertAll(table.Rows[0].Values.ToArray(), double.Parse);
            double[] row2 = Array.ConvertAll(table.Rows[1].Values.ToArray(), double.Parse);
            double[] row3 = Array.ConvertAll(table.Rows[2].Values.ToArray(), double.Parse);
            double[] row4 = Array.ConvertAll(table.Rows[3].Values.ToArray(), double.Parse);

            var matrix = new rtMatrix(row1[0], row1[1], row1[2], row1[3], row2[0], row2[1], row2[2], row2[3], row3[0], row3[1], row3[2], row3[3], row4[0], row4[1], row4[2], row4[3]);
            return matrix;
        }

        /// <summary>
        /// Helper method to create a 2x2 matrix from a SpecFlow table
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private rtMatrix Create2x2MatrixFromTable(Table table)
        {
            double[] row1 = Array.ConvertAll(table.Rows[0].Values.ToArray(), double.Parse);
            double[] row2 = Array.ConvertAll(table.Rows[1].Values.ToArray(), double.Parse);

            var matrix = new rtMatrix(row1[0], row1[1], row2[0], row2[1]);
            return matrix;
        }

        [Then(@"matrixA \* identity_matrix == matrixA")]
        public void ThenMatrixAIdentity_MatrixMatrixA()
        {
            var expected = matrixA;
            var actual = matrixA * rtMatrix.IdentityMatrix();

            Assert.AreEqual(expected, actual);
        }

        [Then(@"Transpose\(matrixA\) is the following matrix:")]
        public void ThenTransposeMatrixAIsTheFollowingMatrix(Table table)
        {
            var expected = Create4x4MatrixFromTable(table);
            var actual = matrixA.Transpose();

            Assert.AreEqual(expected, actual);
        }

        [Given(@"matrixA = Transpose\(identity_matrix\)")]
        public void GivenMatrixATransposeIdentity_Matrix()
        {
            var identityMatrix = rtMatrix.IdentityMatrix();
            matrixA = identityMatrix.Transpose();
        }

        [Then(@"matrixA == identity_matrix")]
        public void ThenMatrixAIdentity_Matrix()
        {
            Assert.AreEqual(rtMatrix.IdentityMatrix(), matrixA);
        }

        [Given(@"the following two by two matrixA:")]
        public void GivenTheFollowingTwoByTwoMatrixA(Table table)
        {
            matrixA = Create2x2MatrixFromTable(table);
        }

        [Then(@"determinant\(A\) == (.*)")]
        public void ThenDeterminantA(double determinant)
        {
            double actual = rtMatrix.Determinant(matrixA);
            Assert.AreEqual(determinant, actual);
        }


    }
}
