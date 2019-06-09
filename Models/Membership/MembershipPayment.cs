using Models.Clients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Membership
{
    public class MembershipPayment
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MembershipTypeName { get; set; }
        public string CreatedAt { get; set; }
        public string ValidDescriptor { get; set; }
        public double TotalPaid { get; set; }
    }
}
