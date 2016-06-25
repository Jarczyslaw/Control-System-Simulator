namespace JTSim
{
    public class PID : GenericRegulator
    {
        double Kp = 1.9d;
        double Ti = 1d;
        double Td = 0.15d;

        bool antiwindup = false;
        double processMax = 100d;
        double processMin = -100d;

        double sumE = 0d;
        double lastE = 0d;

        int iteration = 0;

        public PID(double Kp, double Ti, double Td)
        {
            this.Kp = Kp;
            this.Ti = Ti;
            this.Td = Td;
        }

        public PID(double Kp, double Ti, double Td, double processMax, double processMin) : this(Kp, Ti, Td)
        {
            this.processMax = processMax;
            this.processMin = processMin;
            antiwindup = true;
        }

        public override double Step(double setValue, double processValue, double h)
        {
            double e = setValue - processValue;
            double P = Kp * e;
            sumE += e;
            double I = Kp * h / Ti * sumE;
            double D = 0d;
            if (iteration != 0)
                D = 1d / h * Kp * Td * (e - lastE);
            double u = P + I + D;
            if (antiwindup)
            {
                if (u > processMax)
                {
                    u = processMax;
                    sumE -= e;
                }
                else if (u < processMin)
                {
                    u = processMin;
                    sumE -= e;
                }
            }
            lastE = e;
            iteration++;

            return u;
        }

        public override void Init(double h)
        {
            iteration = 0;
            sumE = 0d;
        }
    }
}
