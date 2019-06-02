using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Exceptions
{
    public class InvalidTokenException : Exception
    {
        public InvalidTokenException(String msg) : base(msg) { }
    }
}
