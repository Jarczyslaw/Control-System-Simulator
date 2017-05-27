using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMath.Tests
{
    [TestFixture]
    public class JMatrixTest
    {

        [Test]
        public void InitTest()
        {
            var d = new double[,] { { 1.0, 2.0 }, { 3.0, 4.0 }, { 5.0, 6.0 } };
            CollectionAssert.AreEqual(d, (new JMatrix(d)).data);

            CollectionAssert.AreEqual(new double[3,2], (new JMatrix(3,2)).data);
            CollectionAssert.AreEqual(new double[,] { { 5.0, 5.0 }, { 5.0, 5.0 }, { 5.0, 5.0 } }, (new JMatrix(3, 2, 5.0)).data);

            var m = new JMatrix(d);
            CollectionAssert.AreEqual(d, (new JMatrix(m)).data);

            var v = new JVector(new double[] { 1.0, 2.0, 3.0 });
            CollectionAssert.AreEqual(new double[3, 1] { { 1.0 }, { 2.0 }, { 3.0 } }, (new JMatrix(v)).data);

        }

        [Test]
        public void BasicFunctions()
        {
            var m = new JMatrix(new double[,] { { 1.0, 2.0 }, { 3.0, 4.0 }, { 5.0, 6.0 } });
            Assert.AreEqual(3, m.SizeX());
            Assert.AreEqual(2, m.SizeY());

            Assert.AreEqual(6.0, m.Max());
            Assert.AreEqual(1.0, m.Min());
            Assert.AreEqual(3.5, m.Average());
            Assert.AreEqual(21.0, m.Sum());
            Assert.AreEqual(new double[,] { { -1.0, -2.0 }, { -3.0, -4.0 }, { -5.0, -6.0 } }, m.Neg().data);
            Assert.AreEqual(6, m.Count());
            Assert.AreEqual(new double[,] { { 1.0, 3.0, 5.0 }, { 2.0, 4.0, 6.0 } }, m.T().data);
        }

        [Test]
        public void InvalidSizes()
        {
            var m1 = new JMatrix(new double[,] { { 1.0, 2.0 }, { 3.0, 4.0 }, { 5.0, 6.0 } });
            var m2 = new JMatrix(new double[,] { { 1.0, 2.0 }, { 3.0, 4.0 }, { 5.0, 6.0 } });
            Assert.Throws<InvalidMatrixSizeException>(
                () => { var m3 = m1 * m2; });

            var v = new JVector(new double[] { 1.0, 2.0, 3.0 });
            Assert.Throws<InvalidMatrixSizeException>(
                () => { var m3 = m1 * v; });
        }
        
        [Test]
        public void Operators()
        {
            var m1 = new JMatrix(new double[,] { { 1.0, 2.0 }, { 3.0, 4.0 }, { 5.0, 6.0 } });
            var m2 = new JMatrix(new double[,] { { 2.0, 3.0 }, { 4.0, 5.0 }, { 6.0, 7.0 } });
            var m3 = new JMatrix(new double[,] { { 1.0, 2.0 }, { 3.0, 4.0 } });
            var v1 = new JVector(new double[] { 2.0,1.0 });

            CollectionAssert.AreEqual(new double[,] { { 3.0, 5.0 }, { 7.0, 9.0 }, { 11.0, 13.0 } },(m1 + m2).data);
            CollectionAssert.AreEqual(new double[,] { { -1.0, -1.0 }, { -1.0, -1.0 }, { -1.0, -1.0 } }, (m1 - m2).data);
            CollectionAssert.AreEqual(new double[,] { { 7.0, 10.0 }, { 15.0, 22.0 }, { 23.0, 34.0 } }, (m1 * m3).data);
            CollectionAssert.AreEqual(new double[] { 4.0,10.0,16.0}, (m1 * v1).data);
            CollectionAssert.AreEqual(new double[,] { { 2.0, 4.0 }, { 6.0, 8.0 }, { 10.0, 12.0 } }, (2d * m1).data);
            CollectionAssert.AreEqual(new double[,] { { -1.0, 0.0 }, { 1.0, 2.0 }, { 3.0, 4.0 } }, (m1 - 2.0).data);
            CollectionAssert.AreEqual(new double[,] { { 1.0, 0.0 }, { -1.0, -2.0 }, { -3.0, -4.0 } }, (2.0 - m1).data);
        }
    }
}
