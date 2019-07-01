using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Requests.Workout
{
    public class WorkoutSearchParams : IQueryParams
    {
        public int? TrainerId { get; set; }
        public string Difficulty { get; set; }
        public string WorkoutType { get; set; }
        public int? Duration { get; set; }

        public string ToQueryParams()
        {
            return $"?trainerId={TrainerId}&difficulty={Difficulty}&workoutType={WorkoutType}&duration={Duration}";
        }
    }
}
