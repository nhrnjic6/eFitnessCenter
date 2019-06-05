using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Requests.Clients
{
    public class SearchClientParams : IQueryParams
    {
        public UserStatus? UserStatus { get; set; }

        public string ToQueryParams()
        {
            var queryParams = $"?userStatus={(int)UserStatus}";
            return queryParams;
        }
    }
}
