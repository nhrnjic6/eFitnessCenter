using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Database
{
    public class SuplementsRating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Client Client { get; set; }
        public int ClientId { get; set; }

        public Suplement Suplement { get; set; }
        public int SuplementId { get; set; }
        public int Rating { get; set; }
    }
}
