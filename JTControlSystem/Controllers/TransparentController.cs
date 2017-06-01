namespace JTControlSystem.Controllers
{
    public class TransparentController : IController
    {
        public double NextIteration(double setPoint, double processValue, double dt)
        {
            return setPoint;
        }

        public void Initialize(double dt) { }
    }
}
