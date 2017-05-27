using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMath
{
    public class MatrixInversionException : Exception
    {
        public MatrixInversionException(string msg) : base(msg) { }
    }
}
