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

        public double GetControllerOutput(double setPoint, double processValue, double dt)
        {
            return Kp * (setPoint - processValue);
        }

        public void Initialize(double dt) { }
    }
}
