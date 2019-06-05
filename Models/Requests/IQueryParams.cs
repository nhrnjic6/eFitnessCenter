using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Requests
{
    public interface IQueryParams
    {
        string ToQueryParams();
    }
}
