using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Requests.Workout
{
    public class WorkoutCreateRequest
    {   
        [Required]
        public int TrainerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int WorkoutTypeId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public string Difficulty { get; set; }
    }
}
