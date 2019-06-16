using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Database
{
    public class Suplement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public int SuplementTypeId { get; set; }
        public SuplementType SuplementType { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string MessureUnit { get; set; }
        public ICollection<SuplementPayment> SuplementPayments { get; set; }
    }
}
