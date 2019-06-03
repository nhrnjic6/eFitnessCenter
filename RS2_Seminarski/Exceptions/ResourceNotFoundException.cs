using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string msg) : base(msg) { }
    }
}
