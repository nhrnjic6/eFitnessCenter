using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Requests.Workout
{
    public class WorkoutAdviceCreate
    {
        public string Message { get; set; }
        public int? ClientId { get; set; }
        public int? TrainerId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
