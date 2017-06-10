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

        public double inputOn = 1d;
        public double inputOff = -1d;

        private int state = 1;

        public Relay(double inputOn, double outputOn, double inputOff, double outputOff)
        {
            SetErrorThresholds(inputOn, inputOff);
            SetOutputs(outputOn, outputOff);
        }

        public void SetErrorThresholds(double inputOn, double inputOff)
        {
            if (inputOn > inputOff)
            {
                this.inputOn = inputOn;
                this.inputOff = inputOff;
            }
        }

        public void SetOutputs(double outputOn, double outputOff)
        {
            this.outputOn = outputOn;
            this.outputOff = outputOff;
        }

        public double NextIteration(double input, double systemOutput, double dt)
        {
            if (input < inputOff)
                state = 1;
            else if (input > inputOn)
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
