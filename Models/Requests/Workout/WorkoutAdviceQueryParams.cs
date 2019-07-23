using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Requests.Workout
{
    public class WorkoutAdviceQueryParams : IQueryParams
    {
        public int? ClientId { get; set; }
        public int? TrainerId { get; set; }

        public string ToQueryParams()
        {
            return $"?clientId={ClientId}&trainerId={TrainerId}";
        }
    }
}
