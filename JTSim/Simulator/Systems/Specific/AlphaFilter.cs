using System;

namespace JTSim
{
    public class AlphaFilter : GenericSystem
    {
        double k = 1d;
        double T = 1d;

        double initState;

        public AlphaFilter (double initState)
        {
            this.initState = initState;
        }

        public override void Init(double h)
        {
            output = initState;
        }

        public override void Step(double u, double t, double h)
        {
            double alpha = Math.Exp(-h / T);
            output = output * alpha + (1d - alpha) * u * k;
        }
    }
}
