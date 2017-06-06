﻿using JTControlSystem.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem
{
    /// <summary>
    /// Wrapper around system which simulates only system itself
    /// </summary>
    public class BareSystemScheme
    {
        private ISystem system;

        public BareSystemScheme(ISystem system)
        {
            this.system = system;
        }

        public BareSystemDataSample NextIteration(double dt, double currentTime,
            double input)
        {
            double systemOutput = system.NextIteration(input, currentTime - dt, dt);
            return new BareSystemDataSample(currentTime, input, systemOutput); ;
        }

        public BareSystemDataSample Initialize(double dt, double currentTime)
        {
            double initialOutput = system.Initialize(dt);
            return new BareSystemDataSample(currentTime, 0d, initialOutput); ;
        }
    }
}