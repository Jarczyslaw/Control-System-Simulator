namespace JTControlSystem.Controllers
{
    public class TransparentController : IController
    {
        public double NextIteration(double input, double systemOutput, double dt)
        {
            return input;
        }

        public void Initialize(double dt) { }
    }
}
