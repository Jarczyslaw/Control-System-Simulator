namespace JTSim
{
    public abstract class GenericSystem
    {
        public float output;

        public abstract void Step(float u, float t, float h);

        public abstract void Init(float h);
    }
}
