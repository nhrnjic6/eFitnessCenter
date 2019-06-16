using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Database
{
    public class Client
    {
        [ForeignKey("Id")]
        public AppUser AppUser { get; set; } = new AppUser();
        public ICollection<MembershipPayment> MembershipPayments { get; set; }
        public ICollection<SuplementPayment> SuplementPayments { get; set; }
    }
}
