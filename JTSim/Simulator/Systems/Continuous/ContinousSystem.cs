using System;
using System.Collections.Generic;
using JVectors;

namespace JTSim
{
    public class ContinousSystem : GenericSystem
    {
        private ISolver solver;
        private ContinousModel model;
        private JVector state;
        private TransportDelay transportDelay;
        private double delay;

        public ContinousSystem(ContinousModel model, ISolver solver) : this(model, 0d, solver) { }

        public ContinousSystem (ContinousModel model, double delay, ISolver solver)
        {
            this.solver = solver;
            this.model = model;
            this.delay = delay;
        }

        public override void Step(double u, double t, double h)
        {
            state = solver.Solve(model, state, u, t, h);
            output = model.OutputEquation(state, u);

            output = transportDelay.Step(output);
        }

        public override void Init(double h)
        {
            state = model.initState.Clone();
            double initOutput = model.OutputEquation(state, 0d);
            transportDelay = new TransportDelay(delay, initOutput, h);
            output = initOutput;
            solver.Init(h);
        }
    }
}
