using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Database
{
    public class WorkoutAdvice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Message { get; set; }
        public Client Client { get; set; }
        public int? ClientId { get; set; }
        public Trainer Trainer { get; set; }
        public int? TrainerId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
