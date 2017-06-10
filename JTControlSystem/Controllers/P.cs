namespace JTControlSystem.Controllers
{
    public class P : IController
    {
        private double Kp = 3d;

        public P() { }

        public P(double gain)
        {
            Kp = gain;
        }

        public double NextIteration(double input, double systemOutput, double dt)
        {
            return Kp * input;
        }

        public void Initialize(double dt) { }
    }
}
