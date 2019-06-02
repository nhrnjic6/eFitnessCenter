using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException(String msg) : base(msg) { }
    }
}
