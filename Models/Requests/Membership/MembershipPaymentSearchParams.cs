using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Requests.Membership
{
    public class MembershipPaymentSearchParams : IQueryParams
    {
        public int? ClientId { get; set; }

        public string ToQueryParams()
        {
            return $"?clientId={ClientId}";
        }
    }
}
