using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Requests.Clients
{
    public class SearchClientParams : IQueryParams
    {
        public UserStatus? UserStatus { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ToQueryParams()
        {
            var queryParams = $"?userStatus={(int)UserStatus}";
            queryParams += $"&firstName={FirstName}";
            queryParams += $"&lastName={LastName}";
            return queryParams;
        }
    }
}
