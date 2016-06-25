namespace JTSim
{
    public class TransparentRegulator : GenericRegulator
    {
        public override float Step(float setValue, float processValue, float h)
        {
            output = setValue;
            return output;
        }
    }
}
