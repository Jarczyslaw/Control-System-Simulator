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
    public class WavesParametersValidatorTest
    {
        [Test]
        public void ValidationTest()
        {
            var validator = new WavesParametersValidator();

            Assert.False(validator.Validate("1", "a", "2"));
            Assert.False(validator.Validate("1", "-1", "2"));
            Assert.False(validator.Validate("", "-1", ""));
            Assert.True(validator.Validate("1", "2", "3"));
        }

        [Test]
        public void ConvertTest()
        {
            var validator = new WavesParametersValidator();

            double frequency, amplitude, offset;
            validator.Convert("1", "2", "3", out frequency, out amplitude, out offset);

            Assert.AreEqual(frequency, 1d);
            Assert.AreEqual(amplitude, 2d);
            Assert.AreEqual(offset, 3d);
        }
    }
}
