using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Database
{
    public class Workout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public WorkoutType WorkoutType { get; set; }
        public int WorkoutTypeId { get; set; }
        public Trainer Trainer { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Difficulty { get; set; }
    }
}
