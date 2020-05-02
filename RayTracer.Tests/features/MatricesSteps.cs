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
            double[] row1 = Array.ConvertAll(table.Rows[0].Values.ToArray(), double.Parse);
            double[] row2 = Array.ConvertAll(table.Rows[1].Values.ToArray(), double.Parse);
            double[] row3 = Array.ConvertAll(table.Rows[2].Values.ToArray(), double.Parse);
            double[] row4 = Array.ConvertAll(table.Rows[3].Values.ToArray(), double.Parse);

            matrix = new rtMatrix(row1[0], row1[1], row1[2], row1[3], row2[0], row2[1], row2[2], row2[3], row3[0], row3[1], row3[2], row3[3], row4[0], row4[1], row4[2], row4[3]);
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
            double[] row1 = Array.ConvertAll(table.Rows[0].Values.ToArray(), double.Parse);
            double[] row2 = Array.ConvertAll(table.Rows[1].Values.ToArray(), double.Parse);
            double[] row3 = Array.ConvertAll(table.Rows[2].Values.ToArray(), double.Parse);
            double[] row4 = Array.ConvertAll(table.Rows[3].Values.ToArray(), double.Parse);

            matrixA = new rtMatrix(row1[0], row1[1], row1[2], row1[3], row2[0], row2[1], row2[2], row2[3], row3[0], row3[1], row3[2], row3[3], row4[0], row4[1], row4[2], row4[3]);
        }

        [Given(@"the following matrixB:")]
        public void GivenTheFollowingMatrixB(Table table)
        {
            double[] row1 = Array.ConvertAll(table.Rows[0].Values.ToArray(), double.Parse);
            double[] row2 = Array.ConvertAll(table.Rows[1].Values.ToArray(), double.Parse);
            double[] row3 = Array.ConvertAll(table.Rows[2].Values.ToArray(), double.Parse);
            double[] row4 = Array.ConvertAll(table.Rows[3].Values.ToArray(), double.Parse);

            matrixB = new rtMatrix(row1[0], row1[1], row1[2], row1[3], row2[0], row2[1], row2[2], row2[3], row3[0], row3[1], row3[2], row3[3], row4[0], row4[1], row4[2], row4[3]);
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


    }
}
