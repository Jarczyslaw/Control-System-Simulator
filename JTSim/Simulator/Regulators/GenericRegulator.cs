namespace JTSim
{
    public abstract class GenericRegulator
    {
        public float output;

        public abstract float Step(float setValue, float processValue, float h);

        public virtual void Init(float h) { }
    }
}
