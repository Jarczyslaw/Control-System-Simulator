using JTControlSystem.Controllers;
using JTControlSystem.Solvers;
using JTControlSystem.Systems;
using JTMath;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.Tests
{
    [TestFixture]
    public class LoopsTest
    {
        [Test]
        public void OpelLoopTest()
        {
            var reference = ReferenceDataLoader.LoadFromProject(@"/LoopReferenceData/Open/reference_data.txt");

            var model = new ContinousFirstOrder(4d, 3d);
            ContinousSystem system = new ContinousSystem(model, new SolverEuler(), Vector.Ones(1));

            OpenLoop loop = new OpenLoop(system, 0.1d);
            Simulator.Step(loop, 10d);

            Assert.True(SamplesComparator.Compare(reference, loop.Data));
        }

        [Test]
        public void CloseLoopTest()
        {
            var reference = ReferenceDataLoader.LoadFromProject(@"/LoopReferenceData/Close/reference_data.txt");

            var model = new ContinousFirstOrder(4d, 3d);
            ContinousSystem system = new ContinousSystem(model, new SolverEuler(), new Vector(1, -1d));
            var controller = new P(0.1d);

            CloseLoop loop = new CloseLoop(system, controller, 0.1d);
            Simulator.Step(loop, 10d);

            Assert.True(SamplesComparator.Compare(reference, loop.Data));
        }

        [Test]
        public void ControlSystemTest()
        {
            var reference = ReferenceDataLoader.LoadFromProject(@"/LoopReferenceData/Control/reference_data.txt");

            var model = new ContinousFirstOrder(4d, 3d);
            ContinousSystem system = new ContinousSystem(model, new SolverEuler(), new Vector(1, -1d));
            var controller = new P(1d);

            ControlSystem loop = new ControlSystem(system, controller, 0.1d);

            loop.Initialize();
            double finishTime = 10d - loop.Dt;
            for (double t = 0d; t <= finishTime; t += loop.Dt)
            {
                // switch to open loop in 5th second
                if (t > 5d - loop.Dt)
                    loop.mode = ControlSystemMode.OpenLoop;
                loop.NextIteration(1d);
            }

            Assert.True(SamplesComparator.Compare(reference, loop.Data));
        }
    }
}
