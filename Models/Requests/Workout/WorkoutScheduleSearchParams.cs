using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Requests.Workout
{
    public class WorkoutScheduleSearchParams : IQueryParams
    {
        public string WorkoutId { get; set; }
        public TimeSpan? TimeFrom { get; set; }
        public TimeSpan? TimeTo { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        public string ToQueryParams()
        {
            return $"?workoutId={WorkoutId}&timeFrom={TimeFrom}&timeTo={TimeTo}&dayOfWeek={DayOfWeek}";
        }
    }
}
