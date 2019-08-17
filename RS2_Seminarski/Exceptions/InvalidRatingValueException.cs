using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Exceptions
{
    public class InvalidRatingValueException : Exception
    {
        public InvalidRatingValueException(string msg) : base(msg) { }
    }
}
