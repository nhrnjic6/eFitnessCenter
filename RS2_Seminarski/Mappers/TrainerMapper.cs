using RS2_Seminarski.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Mappers
{
    public class TrainerMapper
    {
        public static Models.Trainers.Trainer fromDb(Database.Trainer dbTrainer)
        {
            return new Models.Trainers.Trainer
            {
                Address = dbTrainer.AppUser.Address,
                Status = (Models.Requests.UserStatus)(int)dbTrainer.AppUser.Status,
                CreatedAt = dbTrainer.AppUser.CreatedAt.ToString("dd-MM-yyyy"),
                Email = dbTrainer.AppUser.Email,
                FirstName = dbTrainer.AppUser.FirstName,
                LastName = dbTrainer.AppUser.LastName,
                Id = dbTrainer.AppUser.Id,
                PhoneNumber = dbTrainer.AppUser.PhoneNumber
            };
        }
    }
}
