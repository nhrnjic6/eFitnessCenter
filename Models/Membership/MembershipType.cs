using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Membership
{
    public class MembershipType
    {
        public int Id { get; set; }
        public int MonthsValid { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
    }
}
