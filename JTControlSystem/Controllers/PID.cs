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

        private double inputSum = 0d;
        private double lastInput = 0d;

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

        public double NextIteration(double input, double systemOutput, double dt)
        {
            iteration++;
            double P = Kp * input;
            inputSum += input;
            double I = Kp * dt / Ti * inputSum;
            double D = 0d;
            if (iteration != 0)
                D = 1d / dt * Kp * Td * (input - lastInput);
            double output = P + I + D;
            if (antiwindup)
            {
                if (output > maxOutput)
                {
                    output = maxOutput;
                    inputSum -= input;
                }
                else if (output < minOutput)
                {
                    output = minOutput;
                    inputSum -= input;
                }
            }
            lastInput = input;
            
            return output;
        }

        public void Initialize(double dt)
        {
            iteration = -1;
            inputSum = 0d;
        }
    }
}
