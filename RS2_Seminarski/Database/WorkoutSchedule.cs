using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Database
{
    [Table("WorkoutSchedule")]
    public class WorkoutSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Workout Workout { get; set; }
        public int WorkoutId { get; set; }

        [Required]
        public DayOfWeek DayOfTheWeek { get; set; }

        [Required]
        public TimeSpan TimeOfTheDay { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
