using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Workout
{
    public class WorkoutSchedule
    {
        public int Id { get; set; }
        public int WorkoutId { get; set; }
        public string WorkoutName { get; set; }
        public string DayOfTheWeek { get; set; }
        public string TimeOfTheDay { get; set; }
        public string Description { get; set; }
    }
}
