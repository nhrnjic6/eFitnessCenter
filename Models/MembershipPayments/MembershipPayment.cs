using Models.Clients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.MembershipPayments
{
    public class MembershipPayment
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public MembershipType MembershipType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
