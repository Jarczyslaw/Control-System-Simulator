using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTControlSystem.Systems;
using JTMath;
using JTControlSystem.Solvers;
using JTControlSystem.Models;

namespace JTControlSystemExamples
{
    public class StateSpaceExample : BaseModelExample
    {
        public override ISystem GetSystem()
        {
            Matrix A = new Matrix(new double[,] { { 0d, 1d, 0d }, { 0d, 0d, 1d }, { -1d, -1d, -2d } });
            Vector B = new Vector(new double[] { 0d, 0d, 1d });
            Vector C = new Vector(new double[] { 3d, 1d, 0d });
            double D = 0;

            StateSpaceModel model = new StateSpaceModel(A, B, C, D);
            return new ContinousSystem(model, new SolverRK4(), new Vector(new double[] { -1d, 1d, 2d }));
        }
    }
}
