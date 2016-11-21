using JTSim;
using JVectors;
using System;

namespace HydraulicSystem
{
    public class HydraulicPlant : ContinousModel
    {
        // hydraulic plant model
        // differential:
        // dH = 1 / A * (Qin - KvMax * x * sqrt(H))
        // H = liquid height
        // A = tank surface area
        // Qin = input flow rate (constant)
        // KvMax = valve parameter
        // x = valve opening degree 0..1
        // HMax = tank height
        public double A;
        public double KvMax;
        public double Qin;
        public double HMax;

        public HydraulicPlant(double initState)
        {
            this.initState = new JVector(1, initState);
            A = Math.Pow(0.025, 2.0) * Math.PI; // A = pi * r^2
            KvMax = 0.8 / 3600.0; // KvMax = 0.5 * 0.001 / 60
            Qin = 0.5 * 0.001 / 60.0; // 0.5l/min
            HMax = 1.0; // max height
        }

        public override JVector DifferentialEquations(JVector state, double input, double t)
        {
            double diff = 1.0 / A * (Qin - KvMax * input * Math.Sqrt(state[0]));
            return new JVector(1, diff);
        }

        public override double OutputEquation(JVector state, double input)
        {
            if (state[0] < 0.0)
                state[0] = 0.0;
            else if (state[0] > HMax)
                state[0] = HMax;
            return state[0];
        }
    }
}
