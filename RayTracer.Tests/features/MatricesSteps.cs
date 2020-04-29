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
        private rtMatrix4x4 matrix4x4;
        [Given(@"the following (.*) matrix m:")]
        public void GivenTheFollowingMatrixM(string p0, Table table)
        {
            double[] row1 = Array.ConvertAll(table.Rows[0].Values.ToArray(), double.Parse);
            double[] row2 = Array.ConvertAll(table.Rows[1].Values.ToArray(), double.Parse);
            double[] row3 = Array.ConvertAll(table.Rows[2].Values.ToArray(), double.Parse);
            double[] row4 = Array.ConvertAll(table.Rows[3].Values.ToArray(), double.Parse);

            matrix4x4 = new rtMatrix4x4(row1[0], row1[1], row1[2], row1[3], row2[0], row2[1], row2[2], row2[3], row3[0], row3[1], row3[2], row3[3], row4[0], row4[1], row4[2], row4[3]);
        }
        
        [Then(@"m\((.*), (.*)\) == (.*)")]
        public void ThenM(int row, int column, double expectedValue)
        {
            var value = matrix4x4.GetValue(row, column);
            Assert.AreEqual(expectedValue, value);
        }

    }
}
