using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Workout
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedAt { get; set; }
        public string WorkoutType { get; set; }
        public int WorkoutTypeId { get; set; }
        public string Trainer { get; set; }
        public int TrainerId { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Difficulty { get; set; }
    }
}
