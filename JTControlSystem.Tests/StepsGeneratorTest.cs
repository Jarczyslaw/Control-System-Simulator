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
    public class StepsGeneratorTest
    {
        [Test]
        public void GetSampleTest()
        {
            var stepsGenerator = new StepsGenerator();

            var time = 0d;
            var desiredSample = new SignalSample() { time = time, value = 1d };

            var actualSample = stepsGenerator.GetSample(time);
            Assert.AreEqual(desiredSample, actualSample);
        }
    }
}
