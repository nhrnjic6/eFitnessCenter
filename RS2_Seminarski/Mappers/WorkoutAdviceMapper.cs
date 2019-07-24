using Models.Requests.Workout;
using Models.Workout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Mappers
{
    public class WorkoutAdviceMapper
    {
        public static Database.WorkoutAdvice toDb(WorkoutAdviceCreate workoutAdvice)
        {
            return new Database.WorkoutAdvice
            {
                ClientId = workoutAdvice.ClientId,
                TrainerId = workoutAdvice.TrainerId,
                CreatedAt = DateTime.Now,
                Message = workoutAdvice.Message
            };
        }

        public static WorkoutAdvice fromDb(Database.WorkoutAdvice dbWorkoutAdvice)
        {
            return new WorkoutAdvice
            {
                ClientId = dbWorkoutAdvice.ClientId,
                TrainerId = dbWorkoutAdvice.TrainerId,
                ClientName = $"{dbWorkoutAdvice.Client.AppUser.FirstName} {dbWorkoutAdvice.Client.AppUser.FirstName}",
                TrainerName = $"{dbWorkoutAdvice.Trainer.AppUser.FirstName} {dbWorkoutAdvice.Trainer.AppUser.FirstName}",
                CreatedAt = dbWorkoutAdvice.CreatedAt.ToString("dd-MM-yyyy"),
                Id = dbWorkoutAdvice.Id,
                Message = dbWorkoutAdvice.Message
            };
        }
    }
}
