using System;
using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public class AlphaFilter2 : DiscreteModel
    {
        float k = 1f;
        float T = 1f;

        public AlphaFilter2 (float initState)
        {
            this.initStates = Vector<float>.Build.Dense(1, initState);
            this.initInputs = Vector<float>.Build.Dense(1, 0f);
        }

        public override float DifferenceEquasion(Vector<float> states, Vector<float> inputs, float t, float h)
        {
            float alpha = (float)Math.Exp(-h / T);
            return states[0] * alpha + (1 - alpha) * k * inputs[0]; 
        }

        public override float OutputEquation(Vector<float> states, Vector<float> inputs)
        {
            return states[0];
        }
    }
}
