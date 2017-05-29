using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTMath.Tests
{
    [TestFixture]
    public class MatrixTest
    {

        [Test]
        public void InitTest()
        {
            var d = new double[,] { { 1d, 2d }, { 3d, 4d }, { 5d, 6d } };
            CollectionAssert.AreEqual(d, (new Matrix(d)).data);

            CollectionAssert.AreEqual(new double[3,2], (new Matrix(3,2)).data);
            CollectionAssert.AreEqual(new double[,] { { 5d, 5d }, { 5d, 5d }, { 5d, 5d } }, (new Matrix(3, 2, 5d)).data);

            var m = new Matrix(d);
            CollectionAssert.AreEqual(d, (new Matrix(m)).data);

            var v = new Vector(new double[] { 1d, 2d, 3d });
            CollectionAssert.AreEqual(new double[3, 1] { { 1d }, { 2d }, { 3d } }, (new Matrix(v)).data);

        }

        [Test]
        public void BasicFunctions()
        {
            var m = new Matrix(new double[,] { { 1d, 2d }, { 3d, 4d }, { 5d, 6d } });
            Assert.AreEqual(3, m.Rows());
            Assert.AreEqual(2, m.Cols());

            Assert.AreEqual(6d, m.Max());
            Assert.AreEqual(1d, m.Min());
            Assert.AreEqual(3.5, m.Average());
            Assert.AreEqual(21d, m.Sum());
            Assert.AreEqual(new double[,] { { -1d, -2d }, { -3d, -4d }, { -5d, -6d } }, m.Neg().data);
            Assert.AreEqual(6, m.Count());
            Assert.AreEqual(new double[,] { { 1d, 3d, 5d }, { 2d, 4d, 6d } }, m.T().data);
        }

        [Test]
        public void InvalidSizes()
        {
            var m1 = new Matrix(new double[,] { { 1d, 2d }, { 3d, 4d }, { 5d, 6d } });
            var m2 = new Matrix(new double[,] { { 1d, 2d }, { 3d, 4d }, { 5d, 6d } });
            Assert.Throws<InvalidMatrixSizeException>(
                () => { var m3 = m1 * m2; });

            var v = new Vector(new double[] { 1d, 2d, 3d });
            Assert.Throws<InvalidMatrixSizeException>(
                () => { var m3 = m1 * v; });
        }
        
        [Test]
        public void Operators()
        {
            var m1 = new Matrix(new double[,] { { 1d, 2d }, { 3d, 4d }, { 5d, 6d } });
            var m2 = new Matrix(new double[,] { { 2d, 3d }, { 4d, 5d }, { 6d, 7d } });
            var m3 = new Matrix(new double[,] { { 1d, 2d }, { 3d, 4d } });
            var v1 = new Vector(new double[] { 2d,1d });

            CollectionAssert.AreEqual(new double[,] { { 3d, 5d }, { 7d, 9d }, { 11d, 13d } },(m1 + m2).data);
            CollectionAssert.AreEqual(new double[,] { { -1d, -1d }, { -1d, -1d }, { -1d, -1d } }, (m1 - m2).data);
            CollectionAssert.AreEqual(new double[,] { { 7d, 10d }, { 15d, 22d }, { 23d, 34d } }, (m1 * m3).data);
            CollectionAssert.AreEqual(new double[] { 4d,10d,16d}, (m1 * v1).data);
            CollectionAssert.AreEqual(new double[,] { { 2d, 4d }, { 6d, 8d }, { 10d, 12d } }, (2d * m1).data);
            CollectionAssert.AreEqual(new double[,] { { -1d, 0d }, { 1d, 2d }, { 3d, 4d } }, (m1 - 2d).data);
            CollectionAssert.AreEqual(new double[,] { { 1d, 0d }, { -1d, -2d }, { -3d, -4d } }, (2d - m1).data);
        }
    }
}
