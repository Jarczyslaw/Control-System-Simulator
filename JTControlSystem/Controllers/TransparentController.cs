namespace JTControlSystem.Controllers
{
    public class TransparentController : IController
    {
        public double GetControllerOutput(double setPoint, double processValue, double dt)
        {
            return setPoint;
        }

        public void Initialize(double dt) { }
    }
}
