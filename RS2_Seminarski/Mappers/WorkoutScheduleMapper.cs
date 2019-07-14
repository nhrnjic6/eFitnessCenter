using RS2_Seminarski.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Mappers
{
    public class WorkoutScheduleMapper
    {
        public static Models.Workout.WorkoutSchedule fromDb(WorkoutSchedule dbSchedule)
        {
            return new Models.Workout.WorkoutSchedule
            {
                DayOfTheWeek = dbSchedule.DayOfTheWeek.ToString(),
                Description = dbSchedule.Description,
                Id = dbSchedule.Id,
                TimeOfTheDay = dbSchedule.TimeOfTheDay.ToString("c"),
                WorkoutId = dbSchedule.Workout.Id,
                WorkoutName = dbSchedule.Workout.Name
            };
        }
    }
}
