﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.SignalGenerators
{
    public interface ISignalGenerator
    {
        SignalGeneratorSample GetSample(double t);
    }
}