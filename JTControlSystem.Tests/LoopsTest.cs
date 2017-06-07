﻿using JTControlSystem.Controllers;
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
            var reference = ReferenceDataLoader.LoadFromProject(@"/LoopReferenceData/Bare/reference_data.txt");

            BareSystem loop = new BareSystem(system, 0.1d);
            Simulator.Step(loop, 10d);

            Assert.True(OutputSamplesComparator.Compare(reference, loop.Data));
        }

        [Test]
        public void OpelLoopTest()
        {
            var reference = ReferenceDataLoader.LoadFromProject(@"/LoopReferenceData/Open/reference_data.txt");

            OpenLoop loop = new OpenLoop(system, controller, 0.1d);
            Simulator.Step(loop, 10d);

            Assert.True(OutputSamplesComparator.Compare(reference, loop.Data));
        }

        [Test]
        public void CloseLoopTest()
        {
            var reference = ReferenceDataLoader.LoadFromProject(@"/LoopReferenceData/Close/reference_data.txt");

            CloseLoop loop = new CloseLoop(system, controller, 0.1d);
            Simulator.Step(loop, 2d);

            Assert.True(OutputSamplesComparator.Compare(reference, loop.Data));
        }

        [Test]
        public void ControlSystemTest()
        {
            var reference = ReferenceDataLoader.LoadFromProject(@"/LoopReferenceData/Control/reference_data.txt");

            ControlSystem loop = new ControlSystem(system, controller, 0.1d);

            bool modeSwitched = false;
            Simulator.Step(loop, 4d, (iteration, time) => {
                if (!modeSwitched && iteration >= 20)
                {
                    loop.mode= ControlSystemMode.OpenLoop;
                    modeSwitched = true;
                }
            });

            Assert.True(OutputSamplesComparator.Compare(reference, loop.Data));
        }
    }
}
