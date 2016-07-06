using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVectors.Tests
{
    [TestFixture]
    public class JMatrixTest
    {

        [Test]
        public void InitTest()
        {
            var d = new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            CollectionAssert.AreEqual(d, (new JMatrix(d)).data);

            CollectionAssert.AreEqual(new double[3,2], (new JMatrix(3,2)).data);
            CollectionAssert.AreEqual(new double[,] { { 5, 5 }, { 5, 5 }, { 5, 5 } }, (new JMatrix(3, 2, 5)).data);

            var m = new JMatrix(d);
            CollectionAssert.AreEqual(d, (new JMatrix(m)).data);

            var v = new JVector(new double[] { 1, 2, 3 });
            CollectionAssert.AreEqual(new double[3, 1] { { 1 }, { 2 }, { 3 } }, (new JMatrix(v)).data);

        }

        [Test]
        public void BasicFunctions()
        {
            var m = new JMatrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
            Assert.AreEqual(3, m.SizeX());
            Assert.AreEqual(2, m.SizeY());

            int x, y;
            m.Size(out x, out y);
            Assert.AreEqual(3, x);
            Assert.AreEqual(2, y);

            Assert.AreEqual(6, m.Max());
            Assert.AreEqual(1, m.Min());
            Assert.AreEqual(3.5, m.Average());
            Assert.AreEqual(21, m.Sum());
            Assert.AreEqual(new double[,] { { -1, -2 }, { -3, -4 }, { -5, -6 } }, m.Neg().data);
            Assert.AreEqual(6, m.Count());
            Assert.AreEqual(new double[,] { { 1, 3, 5 }, { 2, 4, 6 } }, m.T());
        }

        [Test]
        public void InvalidSizes()
        {
            var m1 = new JMatrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
            var m2 = new JMatrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
            Assert.Throws<InvalidMatrixSizeException>(
                () => { var m3 = m1 * m2; });

            var v = new JVector(new double[] { 1, 2, 3 });
            Assert.Throws<InvalidMatrixSizeException>(
                () => { var m3 = m1 * v; });
        }
        
        [Test]
        public void Operators()
        {
            var m1 = new JMatrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
            var m2 = new JMatrix(new double[,] { { 2, 3 }, { 4, 5 }, { 6, 7 } });
            var m3 = new JMatrix(new double[,] { { 1, 2 }, { 3, 4 } });
            var v1 = new JVector(new double[] { 2,1 });

            CollectionAssert.AreEqual(new double[,] { { 3, 5 }, { 7, 9 }, { 11, 13 } },(m1 + m2).data);
            CollectionAssert.AreEqual(new double[,] { { -1, -1 }, { -1, -1 }, { -1, -1 } }, (m1 - m2).data);
            CollectionAssert.AreEqual(new double[,] { { 7, 10 }, { 15, 22 }, { 23, 34 } }, (m1 * m3).data);
            CollectionAssert.AreEqual(new double[] { 4,10,16}, (m1 * v1).data);
            CollectionAssert.AreEqual(new double[,] { { 2, 4 }, { 6, 8 }, { 10, 12 } }, (2d * m1).data);
            CollectionAssert.AreEqual(new double[,] { { -1, 0 }, { 1, 2 }, { 3, 4 } }, (m1 - 2).data);
            CollectionAssert.AreEqual(new double[,] { { 1, 0 }, { -1, -2 }, { -3, -4 } }, (2 - m1).data);
        }
    }
}
