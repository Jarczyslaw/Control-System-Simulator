using JTControlSystem.SignalGenerators;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.Tests
{
    [TestFixture]
    public class StepsParametersConverterTest
    {
        StepsParametersConverter converter = new StepsParametersConverter();

        [Test]
        public void ValidationTest()
        {
            Assert.False(converter.Validate("", ""));
            Assert.True(converter.Validate("1", "1"));
            Assert.False(converter.Validate("1, 2", "3"));
            Assert.False(converter.Validate("1, a", "1, 5"));
            Assert.True(converter.Validate("1.0", "2.5"));
            Assert.False(converter.Validate("1", "2, 3"));
            Assert.False(converter.Validate("2, -1", "3, 4"));
        }

        [Test]
        public void ConvertTest()
        {
            double[] times = null;
            double[] values = null;

            converter.Convert("1, 2", "3,4", out times, out values);
            CollectionAssert.AreEqual(new double[] { 1d, 2d }, times);
            CollectionAssert.AreEqual(new double[] { 3d, 4d }, values);
        }
    }
}
