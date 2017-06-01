namespace JTControlSystem.Controllers
{
    public class PID : IController
    {
        public double Kp = 1.9d;
        public double Ti = 1d;
        public double Td = 0.15d;

        public bool antiwindup = false;
        public double minOutput = double.NegativeInfinity;
        public double maxOutput = double.PositiveInfinity;

        private double errorSum = 0d;
        private double lastError = 0d;

        private int iteration = -1;

        public PID() { }

        public PID(double Kp, double Ti, double Td)
        {
            SetBaseParameters(Kp, Ti, Td);
            antiwindup = false;
        }

        public PID(double Kp, double Ti, double Td, double minOutput, double maxOutput)
        {
            SetBaseParameters(Kp, Ti, Td);
            this.minOutput = minOutput;
            this.maxOutput = maxOutput;
            antiwindup = true;
        }

        public void SetBaseParameters(double Kp, double Ti, double Td)
        {
            this.Kp = Kp;
            this.Ti = Ti;
            this.Td = Td;
        }

        public double NextIteration(double setPoint, double processValue, double dt)
        {
            iteration++;
            double error = setPoint - processValue;
            double P = Kp * error;
            errorSum += error;
            double I = Kp * dt / Ti * errorSum;
            double D = 0d;
            if (iteration != 0)
                D = 1d / dt * Kp * Td * (error - lastError);
            double output = P + I + D;
            if (antiwindup)
            {
                if (output > maxOutput)
                {
                    output = maxOutput;
                    errorSum -= error;
                }
                else if (output < minOutput)
                {
                    output = minOutput;
                    errorSum -= error;
                }
            }
            lastError = error;
            
            return output;
        }

        public void Initialize(double dt)
        {
            iteration = -1;
            errorSum = 0d;
        }
    }
}
