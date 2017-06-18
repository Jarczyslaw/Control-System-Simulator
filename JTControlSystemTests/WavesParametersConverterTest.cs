using JTControlSystem.SignalGenerators;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystemTests
{
    [TestFixture]
    public class WavesParametersConverterTest
    {
        WavesParametersConverter validator = new WavesParametersConverter();

        [Test]
        public void ValidationTest()
        {
            Assert.False(validator.Validate("1", "a", "2"));
            Assert.False(validator.Validate("1", "-1", "2"));
            Assert.False(validator.Validate("", "-1", ""));
            Assert.True(validator.Validate("1", "2", "3"));
        }

        [Test]
        public void ConvertTest()
        {
            double frequency, amplitude, offset;
            validator.Convert("1", "2", "3", out frequency, out amplitude, out offset);

            Assert.AreEqual(frequency, 1d);
            Assert.AreEqual(amplitude, 2d);
            Assert.AreEqual(offset, 3d);
        }
    }
}
