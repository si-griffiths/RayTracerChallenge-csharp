﻿using Gherkin.Events.Args.Pickle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

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
            matrix = Create2x2MatrixFromTable(table);
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
        /// Helper method to create a 4x4 matrix from a SpecFlow table
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
        /// Helper method to create a 3x3 matrix from a SpecFlow table
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private rtMatrix Create3x3MatrixFromTable(Table table)
        {
            double[] row1 = Array.ConvertAll(table.Rows[0].Values.ToArray(), double.Parse);
            double[] row2 = Array.ConvertAll(table.Rows[1].Values.ToArray(), double.Parse);
            double[] row3 = Array.ConvertAll(table.Rows[2].Values.ToArray(), double.Parse);

            var matrix = new rtMatrix(row1[0], row1[1], row1[2], row2[0], row2[1], row2[2], row3[0], row3[1], row3[2]);
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

        [Given(@"the following three_by_three matrix matrixA")]
        public void GivenTheFollowingThree_By_ThreeMatrixMatrixA(Table table)
        {
            matrixA = Create3x3MatrixFromTable(table);
        }

        [Then(@"Submatrix\(matrixA, (.*), (.*)\) is the following two_by_two matrix:")]
        public void ThenSubmatrixMatrixAIsTheFollowingTwo_By_TwoMatrix(int row, int column, Table table)
        {
            var expected = Create2x2MatrixFromTable(table);
            var actual = matrixA.Submatrix(row, column);

            Assert.AreEqual(expected, actual);
        }

        [Given(@"the following four_by_four matrix matrixA:")]
        public void GivenTheFollowingFour_By_FourMatrixMatrixA(Table table)
        {
            matrixA = Create4x4MatrixFromTable(table);
        }

        [Then(@"Submatrix\(matrixA, (.*), (.*)\) is the following three_by_three matrix:")]
        public void ThenSubmatrixMatrixAIsTheFollowingThree_By_ThreeMatrix(int row, int column, Table table)
        {
            var expected = Create3x3MatrixFromTable(table);
            var actual = matrixA.Submatrix(row, column);

            Assert.AreEqual(expected, actual);
        
        }

        [Given(@"matrixB = Submatrix\(matrixA, (.*), (.*)\)")]
        public void GivenMatrixBSubmatrixMatrixA(int row, int column)
        {
            matrixB = matrixA.Submatrix(row, column);
        }

        [Then(@"Determinant\(matrixB\) == (.*)")]
        public void ThenDeterminantMatrixB(double determinant)
        {
            Assert.AreEqual(determinant, rtMatrix.Determinant(matrixB));
        }

        [Then(@"Minor\(matrixA, (.*), (.*)\) == (.*)")]
        public void ThenMinorMatrixA(int row, int column, double expectedMinor)
        {
            double actual = matrixA.Minor(row, column);
            Assert.AreEqual(expectedMinor, actual);
        }

        [Then(@"Cofactor\(matrixA, (.*), (.*)\) == (.*)")]
        public void ThenCofactorMatrixA(int row, int column, double expectedCofactor)
        {
            double actualCofactor = matrixA.Cofactor(row, column);
            Assert.AreEqual(expectedCofactor, actualCofactor);
        }

    }
}
