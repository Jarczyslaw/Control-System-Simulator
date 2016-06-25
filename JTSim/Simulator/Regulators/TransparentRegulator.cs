namespace JTSim
{
    public class TransparentRegulator : GenericRegulator
    {
        public override double Step(double setValue, double processValue, double h)
        {
            output = setValue;
            return output;
        }
    }
}
