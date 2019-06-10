using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Requests
{
    public class SuplementSearchParams : IQueryParams
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public string ToQueryParams()
        {
            return $"?name={Name}&type={Type}";
        }
    }
}
