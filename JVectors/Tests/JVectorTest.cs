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
            CollectionAssert.AreEqual(new double[] { 1.0, 1.0, 1.0, 1.0, 1.0 }, v3.data);
        }

        [Test]
        public void BasicFunctionsTest()
        {
            JVector v = new JVector(new double[] { 1.0, 2.0, 3.0, 4.0, 5.0 });

            Assert.AreEqual(v.Min(), 1.0);
            Assert.AreEqual(v.Max(), 5.0);
            Assert.AreEqual(v.Average(), 3.0);
            Assert.AreEqual(v.Sum(), 15.0);

            v.Push(123);
            CollectionAssert.AreEqual(new double[] { 123.0, 1.0, 2.0, 3.0, 4.0 }, v.data);


        }

        [Test]
        public void OperatorsTest()
        {
            JVector v1 = new JVector(new double[] { 1.0, 2.0, 3.0 });
            JVector v2 = new JVector(new double[] { 4.0, 5.0, 6.0 });

            CollectionAssert.AreEqual(new double[] { 5.0, 7.0, 9.0 }, (v1 + v2).data);
            CollectionAssert.AreEqual(new double[] { 6.0, 7.0, 8.0 }, (v1 + 5.0).data);
            CollectionAssert.AreEqual(new double[] { 6.0, 7.0, 8.0 }, (5.0 + v1).data);
            CollectionAssert.AreEqual(new double[] { -3.0, -3.0, -3.0 }, (v1 - v2).data);
            CollectionAssert.AreEqual(new double[] { 0.0, 1.0, 2.0 }, (v1 - 1.0).data);
            CollectionAssert.AreEqual(new double[] { 0.0, -1.0, -2.0 }, (1.0 - v1).data);
            CollectionAssert.AreEqual(new double[] { 4.0, 10.0, 18.0 }, (v1 * v2).data);
            CollectionAssert.AreEqual(new double[] { 2.0, 4.0, 6.0 }, (v1 * 2.0).data);
            CollectionAssert.AreEqual(new double[] { 2.0, 4.0, 6.0 }, (2.0 * v1).data);
            CollectionAssert.AreEqual(new double[] { -1.0, -2.0, -3.0 }, (-v1).data);

            CollectionAssert.AreEqual(new double[] { 3.0, 8.0, 15.0 }, (v1 * v2 - v1).data);
        }

        [Test]
        public void InvalidSizeTest()
        {
            var v1 = new JVector(new double[] { 1.0, 2.0, 3.0 });
            var v2 = new JVector(new double[] { 1.0, 2.0 });
            Assert.Throws<InvalidVectorsLengthException>(
                () => { var v3 = v1 + v2; });
        }
    }
}
