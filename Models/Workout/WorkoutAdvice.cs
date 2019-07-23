using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Workout
{
    public class WorkoutAdvice
    {
        public int Id { get; set; }

        public string Message { get; set; }
        public string ClientName { get; set; }
        public int? ClientId { get; set; }
        public string TrainerName { get; set; }
        public int? TrainerId { get; set; }
        public string CreatedAt { get; set; }
    }
}
