using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Requests.Workout
{
    public class WorkoutScheduleCreate
    {   
        [Required]
        public int WorkoutId { get; set; }

        [Required]
        public DayOfWeek DayOfTheWeek { get; set; }

        [Required]
        public TimeSpan TimeOfTheDay { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
