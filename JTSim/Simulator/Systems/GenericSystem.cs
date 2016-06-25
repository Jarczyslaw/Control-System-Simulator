namespace JTSim
{
    public abstract class GenericSystem
    {
        public double output;

        public abstract void Step(double u, double t, double h);

        public abstract void Init(double h);
    }
}
