﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVectors
{
    public class NonSquareMatrixException : Exception
    {
        public NonSquareMatrixException(string message) : base(message) { }
    }
}
