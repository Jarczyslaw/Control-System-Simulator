using JTControlSystem.Controllers;
using JTControlSystem.Models;
using JTControlSystem.Solvers;
using JTControlSystem.Systems;
using JTMath;
using NUnit.Framework;
using System;

namespace JTControlSystem.Tests
{
    [TestFixture]
    public class LoopsTest
    {
        private IContinousModel model;
        private ISystem system;
        private IController controller;

        private string projectPath = @"Y:\JTControlSystem\JTControlSystem.Tests";

        [SetUp]
        public void Init()
        {
            model = new ContinousFirstOrder(4d, 3d);
            system = new ContinousSystem(model, new SolverEuler(), new Vector(1, -1d));
            controller = new P(2d);
        }

        [Test]
        public void BareSystemTest()
        {
            var reference = ReferenceDataLoader.Load(projectPath + @"/LoopReferenceData/Bare/reference_data.txt");

            BareSystem loop = new BareSystem(system);
            Simulator.Step(loop, 10d, 0.1d);

            Assert.True(OutputSamplesComparator.Compare(reference, loop.Data));
        }

        [Test]
        public void OpelLoopTest()
        {
            var reference = ReferenceDataLoader.Load(projectPath + @"/LoopReferenceData/Open/reference_data.txt");

            OpenLoop loop = new OpenLoop(system, controller);
            Simulator.Step(loop, 10d, 0.1d);

            Assert.True(OutputSamplesComparator.Compare(reference, loop.Data));
        }

        [Test]
        public void CloseLoopTest()
        {
            var reference = ReferenceDataLoader.Load(projectPath + @"/LoopReferenceData/Close/reference_data.txt");

            CloseLoop loop = new CloseLoop(system, controller);
            Simulator.Step(loop, 2d, 0.1d);

            Assert.True(OutputSamplesComparator.Compare(reference, loop.Data));
        }

        [Test]
        public void ControlSystemTest()
        {
            var reference = ReferenceDataLoader.Load(projectPath + @"/LoopReferenceData/Control/reference_data.txt");

            ControlSystem loop = new ControlSystem(system, controller);

            Simulator.Step(loop, 4d, 0.1d, (iteration, time) => {
                if (iteration == 20)
                    loop.mode= ControlSystemMode.OpenLoop;
            });

            Assert.True(OutputSamplesComparator.Compare(reference, loop.Data));
        }
    }
}
