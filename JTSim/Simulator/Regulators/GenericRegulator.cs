namespace JTSim
{
    public abstract class GenericRegulator
    {
        public double output;

        public abstract double Step(double setValue, double processValue, double h);

        public virtual void Init(double h) { }
    }
}
