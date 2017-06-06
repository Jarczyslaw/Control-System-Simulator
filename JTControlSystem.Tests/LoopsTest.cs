using JTControlSystem.Controllers;
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
        [Test]
        public void BareSystemTest()
        {
            var reference = ReferenceDataLoader.LoadFromProject(@"/LoopReferenceData/Bare/reference_data.txt");

            var model = new ContinousFirstOrder(4d, 3d);
            ContinousSystem system = new ContinousSystem(model, new SolverEuler(), new Vector(1, -1d));

            BareSystem loop = new BareSystem(system, 0.1d);
            Simulator.Step(loop, 10d);

            Assert.True(OutputSamplesComparator.Compare(reference, loop.Data));
        }

        [Test]
        public void OpelLoopTest()
        {
            var reference = ReferenceDataLoader.LoadFromProject(@"/LoopReferenceData/Open/reference_data.txt");

            var model = new ContinousFirstOrder(4d, 3d);
            ContinousSystem system = new ContinousSystem(model, new SolverEuler(), new Vector(1, -1d));
            var controller = new P(2d);

            OpenLoop loop = new OpenLoop(system, controller, 0.1d);
            Simulator.Step(loop, 10d);

            Assert.True(OutputSamplesComparator.Compare(reference, loop.Data));
        }

        [Test]
        public void CloseLoopTest()
        {
            var reference = ReferenceDataLoader.LoadFromProject(@"/LoopReferenceData/Close/reference_data.txt");

            var model = new ContinousFirstOrder(4d, 3d);
            ContinousSystem system = new ContinousSystem(model, new SolverEuler(), new Vector(1, -1d));
            var controller = new P(2d);

            CloseLoop loop = new CloseLoop(system, controller, 0.1d);
            Simulator.Step(loop, 2d);

            Assert.True(OutputSamplesComparator.Compare(reference, loop.Data));
        }

        [Test]
        public void ControlSystemTest()
        {
            var reference = ReferenceDataLoader.LoadFromProject(@"/LoopReferenceData/Control/reference_data.txt");

            var model = new ContinousFirstOrder(4d, 3d);
            ContinousSystem system = new ContinousSystem(model, new SolverEuler(), new Vector(1, -1d));
            var controller = new P(2d);

            ControlSystem loop = new ControlSystem(system, controller, 0.1d);

            loop.Initialize();
            int iterations = (int)Math.Ceiling(4d / loop.Dt);
            for (int i = 0; i < iterations; i++)
            {
                double currentTime = i * loop.Dt;
                if (currentTime >= 2d)
                    loop.mode = ControlSystemMode.OpenLoop;
                loop.NextIteration(1d);
            }

            Assert.True(OutputSamplesComparator.Compare(reference, loop.Data));
        }
    }
}
