using JTMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.Models
{
    public class InitialStateConverter
    {
        public static Vector ToOutput(StateSpaceModel stateSpace, double initialOutput)
        {
            return ToOutput(stateSpace.C, initialOutput);
        }

        public static Vector ToOutput(TransferFunction transferFunction, double initialOutput)
        {
            return ToOutput(transferFunction.StateSpace.C, initialOutput);
        }

        private static Vector ToOutput(Vector C, double initialOutput)
        {
            Vector newState = new Vector(C.Rows, 0d);
            newState[0] = initialOutput / C[0];
            return newState;
        }
    }
}
