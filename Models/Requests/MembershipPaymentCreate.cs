using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Requests
{
    public class MembershipPaymentCreate
    {
        public int ClientId { get; set; }
        public int MembershipTypeId { get; set; }
    }
}
