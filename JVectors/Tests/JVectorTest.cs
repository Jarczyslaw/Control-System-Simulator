using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JVectors;

namespace JVectors.Tests
{
    [TestFixture]
    public class JVectorTest
    {
        [Test]
        public void Initialization()
        {
            int len = 5;
            JVector v1 = new JVector(len);
            Assert.AreEqual(len, v1.Count());

            JVector v2 = new JVector(new double[len]);
            Assert.AreEqual(len, v2.Count());

            JVector v3 = new JVector(len, 1);
            CollectionAssert.AreEqual(new double[] { 1, 1, 1, 1, 1 }, v3.data);
        }

        [Test]
        public void BasicFunctionsTest()
        {
            JVector v = new JVector(new double[] { 1, 2, 3, 4, 5 });

            Assert.AreEqual(v.Min(), 1);
            Assert.AreEqual(v.Max(), 5);
            Assert.AreEqual(v.Average(), 3);
            Assert.AreEqual(v.Sum(), 15);

            v.Push(123);
            CollectionAssert.AreEqual(new double[] { 123, 1, 2, 3, 4 }, v.data);


        }

        [Test]
        public void OperatorsTest()
        {
            JVector v1 = new JVector(new double[] { 1, 2, 3 });
            JVector v2 = new JVector(new double[] { 4, 5, 6 });

            CollectionAssert.AreEqual(new double[] { 5, 7, 9 }, (v1 + v2).data);
            CollectionAssert.AreEqual(new double[] { 6, 7, 8 }, (v1 + 5).data);
            CollectionAssert.AreEqual(new double[] { 6, 7, 8 }, (5 + v1).data);
            CollectionAssert.AreEqual(new double[] { -3, -3, -3 }, (v1 - v2).data);
            CollectionAssert.AreEqual(new double[] { 0, 1, 2 }, (v1 - 1).data);
            CollectionAssert.AreEqual(new double[] { 0, -1, -2 }, (1 - v1).data);
            CollectionAssert.AreEqual(new double[] { 4, 10, 18 }, (v1 * v2).data);
            CollectionAssert.AreEqual(new double[] { 2, 4, 6 }, (v1 * 2).data);
            CollectionAssert.AreEqual(new double[] { 2, 4, 6 }, (2 * v1).data);
            CollectionAssert.AreEqual(new double[] { -1, -2, -3 }, (-v1).data);

            CollectionAssert.AreEqual(new double[] { 3, 8, 15 }, (v1 * v2 - v1).data);
        }

        [Test]
        public void InvalidSizeTest()
        {
            var v1 = new JVector(new double[] { 1, 2, 3 });
            var v2 = new JVector(new double[] { 1, 2 });
            Assert.Throws<InvalidVectorsLengthException>(
                () => { var v3 = v1 + v2; });
        }
    }
}
