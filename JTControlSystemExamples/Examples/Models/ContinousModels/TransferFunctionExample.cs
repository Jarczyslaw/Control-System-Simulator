using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTControlSystem.Systems;
using JTControlSystem.Solvers;
using JTMath;
using JTControlSystem.Models;

namespace JTControlSystemExamples
{
    public class TransferFunctionExample : BaseModelExample
    {
        public override ISystem GetSystem()
        {
            TransferFunction model = new TransferFunction(new double[] { 1d, 3d }, new double[] { 1d, 2d, 1d, 1d });
            var initialOutput = InitialStateConverter.ToOutput(model, -2d);
            return new ContinousSystem(model, new SolverRK4(), initialOutput);
        }
    }
}
