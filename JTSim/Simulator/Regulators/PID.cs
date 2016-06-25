namespace JTSim
{
    public class PID : GenericRegulator
    {
        float Kp = 1.9f;
        float Ti = 1f;
        float Td = 0.15f;

        bool antiwindup = false;
        float processMax = 100f;
        float processMin = -100f;

        float sumE = 0f;
        float lastE = 0f;

        int iteration = 0;

        public PID(float Kp, float Ti, float Td)
        {
            this.Kp = Kp;
            this.Ti = Ti;
            this.Td = Td;
        }

        public PID(float Kp, float Ti, float Td, float processMax, float processMin) : this(Kp, Ti, Td)
        {
            this.processMax = processMax;
            this.processMin = processMin;
            antiwindup = true;
        }

        public override float Step(float setValue, float processValue, float h)
        {
            float e = setValue - processValue;
            float P = Kp * e;
            sumE += e;
            float I = Kp * h / Ti * sumE;
            float D = 0f;
            if (iteration != 0)
                D = 1f / h * Kp * Td * (e - lastE);
            float u = P + I + D;
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

        public override void Init(float h)
        {
            iteration = 0;
            sumE = 0f;
        }
    }
}
