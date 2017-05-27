using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMath
{
    public class InvalidVectorsLengthException : Exception
    {
        public InvalidVectorsLengthException(string message) : base(message) { }
    }
}
