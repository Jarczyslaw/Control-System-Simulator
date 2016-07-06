using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVectors
{
    public class InvalidMatrixSizeException : Exception
    {
        public InvalidMatrixSizeException(string message) : base(message) { }
    }
}
