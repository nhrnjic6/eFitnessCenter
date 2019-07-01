using Models.Workout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Mappers
{
    public class WorkoutMapper
    {
        public static Workout FromDb(Database.Workout dbWorkout) {
            return new Workout
            {
                Id = dbWorkout.Id,
                CreatedAt = dbWorkout.CreatedAt.ToString("dd-MM-yyyy"),
                Name = dbWorkout.Name,
                Description = dbWorkout.Description,
                Difficulty = dbWorkout.Difficulty,
                Duration = dbWorkout.Duration,
                WorkoutType = dbWorkout.WorkoutType.Name,
                Trainer = $"{dbWorkout.Trainer.AppUser.FirstName} {dbWorkout.Trainer.AppUser.LastName}"
            };
        }
    }
}
