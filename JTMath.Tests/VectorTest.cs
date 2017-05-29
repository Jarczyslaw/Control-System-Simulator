using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTMath;

namespace JTMath.Tests
{
    [TestFixture]
    public class VectorTest
    {
        [Test]
        public void Initialization()
        {
            int len = 5;
            Vector v1 = new Vector(len);
            Assert.AreEqual(len, v1.Count());

            Vector v2 = new Vector(new double[len]);
            Assert.AreEqual(len, v2.Count());

            Vector v3 = new Vector(len, 1d);
            CollectionAssert.AreEqual(new double[] { 1d, 1d, 1d, 1d, 1d }, v3.data);
        }

        [Test]
        public void BasicFunctionsTest()
        {
            Vector v = new Vector(new double[] { 1d, 2d, 3d, 4d, 5d });

            Assert.AreEqual(v.Min(), 1d);
            Assert.AreEqual(v.Max(), 5d);
            Assert.AreEqual(v.Average(), 3d);
            Assert.AreEqual(v.Sum(), 15d);

            v.Push(123);
            CollectionAssert.AreEqual(new double[] { 123d, 1d, 2d, 3d, 4d }, v.data);


        }

        [Test]
        public void OperatorsTest()
        {
            Vector v1 = new Vector(new double[] { 1d, 2d, 3d });
            Vector v2 = new Vector(new double[] { 4d, 5d, 6d });

            CollectionAssert.AreEqual(new double[] { 5d, 7d, 9d }, (v1 + v2).data);
            CollectionAssert.AreEqual(new double[] { 6d, 7d, 8d }, (v1 + 5d).data);
            CollectionAssert.AreEqual(new double[] { 6d, 7d, 8d }, (5d + v1).data);
            CollectionAssert.AreEqual(new double[] { -3d, -3d, -3d }, (v1 - v2).data);
            CollectionAssert.AreEqual(new double[] { 0d, 1d, 2d }, (v1 - 1d).data);
            CollectionAssert.AreEqual(new double[] { 0d, -1d, -2d }, (1d - v1).data);
            CollectionAssert.AreEqual(new double[] { 4d, 10d, 18d }, (v1 * v2).data);
            CollectionAssert.AreEqual(new double[] { 2d, 4d, 6d }, (v1 * 2d).data);
            CollectionAssert.AreEqual(new double[] { 2d, 4d, 6d }, (2d * v1).data);
            CollectionAssert.AreEqual(new double[] { -1d, -2d, -3d }, (-v1).data);

            CollectionAssert.AreEqual(new double[] { 3d, 8d, 15d }, (v1 * v2 - v1).data);
        }

        [Test]
        public void InvalidSizeTest()
        {
            var v1 = new Vector(new double[] { 1d, 2d, 3d });
            var v2 = new Vector(new double[] { 1d, 2d });
            Assert.Throws<InvalidVectorsLengthException>(
                () => { var v3 = v1 + v2; });
        }
    }
}
