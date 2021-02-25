using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Metrics
{
    public class InvalidRawValueException: Exception
    {
        public InvalidRawValueException():base() {}
        public InvalidRawValueException(string message) : base(message) { }
    }
}
