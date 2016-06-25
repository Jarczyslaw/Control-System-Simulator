﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTSim;
using System.Diagnostics;
using MathNet.Numerics.LinearAlgebra;

namespace SolversTest
{
    public class TestEntry
    {
        public double[] data;

        private TestModel model;
        private Vector<double> state;

        private ISolver solver;

        public long duration;
        public double mse = 0d;

        public TestEntry(TestModel model, ISolver solver)
        {
            this.model = model;
            this.solver = solver;
        }

        public void Test(Stopwatch stopwatch, double[] time, double h)
        {
            data = new double[time.Length];
            data[0] = Init();
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 1;i < time.Length;i++)
            {
                data[i] = Step(time[i] - h, h);
            }
            stopwatch.Stop();
            duration = stopwatch.ElapsedMilliseconds;
        }

        public void GetMse(double[] exact)
        {
            for (int i = 0; i < exact.Length; i++)
                mse += (double)Math.Pow(data[i] - exact[i], 2d);
        }

        public double Step(double t, double h)
        {
            state = solver.Solve(model, state, 0d, t, h);
            return state[0];
        }

        public double Init()
        {
            state = model.initState.Clone();
            return state[0];
        }

        public void ShowInfo ()
        {
            Console.WriteLine("Solver: {0}, duration: {1}, MSE: {2}", solver.GetType().Name, duration, mse);
        }
    }
}
