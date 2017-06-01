namespace JTControlSystem.Controllers
{
    //          --4-----3-------- ON
    //          |   |
    //          |   |
    //          |   |
    // -----1-----2-- OFF
    // 1, 2, 3, 4 - relay states
    public class Relay : IController
    {
        public double outputOn = 1d;
        public double outputOff = -1d;

        public double errorOn = 1d;
        public double errorOff = -1d;

        private int state = 1;

        public Relay(double errorOn, double outputOn, double errorOff, double outputOff)
        {
            SetErrorThresholds(errorOn, errorOff);
            SetOutputs(outputOn, outputOff);
        }

        public void SetErrorThresholds(double errorOn, double errorOff)
        {
            if (errorOn > errorOff)
            {
                this.errorOn = errorOn;
                this.errorOff = errorOff;
            }
        }

        public void SetOutputs(double outputOn, double outputOff)
        {
            this.outputOn = outputOn;
            this.outputOff = outputOff;
        }

        public double NextIteration(double setPoint, double processValue, double dt)
        {
            double error = setPoint - processValue;

            if (error < errorOff)
                state = 1;
            else if (error > errorOn)
                state = 3;
            else
            {
                if (state == 1)
                    state = 2;
                else if (state == 3)
                    state = 4;
            }

            if (state == 1 || state == 2)
                return outputOff;
            else
                return outputOn;
        }

        public void Initialize(double dt)
        {
            state = 1;
        }
    }
}
