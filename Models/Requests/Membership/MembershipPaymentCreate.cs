using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Requests.Membership
{
    public class MembershipPaymentCreate
    {
        [Required]
        public int ClientId { get; set; }
        [Required]
        public int MembershipTypeId { get; set; }
    }
}
