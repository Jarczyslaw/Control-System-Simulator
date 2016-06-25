using System;
using System.Collections.Generic;
using VectorF = MathNet.Numerics.LinearAlgebra.Vector<float>;

namespace JTSim
{
    public class ContinousSystem : GenericSystem
    {
        private ISolver solver;
        private ContinousModel model;
        private VectorF state;
        private TransportDelay transportDelay;
        private float delay;

        public ContinousSystem(ContinousModel model, ISolver solver) : this(model, 0f, solver) { }

        public ContinousSystem (ContinousModel model, float delay, ISolver solver)
        {
            this.solver = solver;
            this.model = model;
            this.delay = delay;
        }

        public override void Step(float u, float t)
        {
            state = solver.Solve(model, state, u, t, h);
            output = model.OutputEquation(state, u);

            output = transportDelay.Step(output);
        }

        public override void Init()
        {
            state = model.initState.Clone();
            float initOutput = model.OutputEquation(state, 0f);
            transportDelay = new TransportDelay(delay, initOutput, h);
            output = initOutput;
        }
    }
}
