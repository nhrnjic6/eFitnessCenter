using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Database
{
    public class Employee
    {   [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal Salary { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public virtual ICollection<MembershipPayment> MembershipPayments { get; set; }
    }
}
