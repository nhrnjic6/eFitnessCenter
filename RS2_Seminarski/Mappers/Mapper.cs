using AutoMapper;
using Models.Requests.Clients;
using Models.Requests.Suplements;
using Models.Requests.Trainers;
using RS2_Seminarski.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CreateClientRequest, Database.AppUser>();
            CreateMap<Database.AppUser, Models.Clients.Client>();
            CreateMap<Database.AppUser, Models.Trainers.Trainer>();
            CreateMap<CreateTrainerRequest, Models.Trainers.Trainer>();
            CreateMap<Models.Requests.Clients.UpdateClientRequest, Database.AppUser>();
            CreateMap<Models.Requests.Trainers.UpdateTrainerRequest, Database.AppUser>();
            CreateMap<Database.MembershipPayment, Models.Membership.MembershipPayment>();
            CreateMap<Database.MembershipType, Models.Membership.MembershipType>();
            CreateMap<Database.SuplementType, Models.Suplements.SuplementType>();
            CreateMap<Database.Suplement, Models.Suplements.Suplement>();
            CreateMap<SuplementCreateRequest, Database.Suplement>().ReverseMap();
            CreateMap<WorkoutType, Models.Workout.WorkoutType>();
            CreateMap<Models.Requests.Workout.WorkoutScheduleCreate, WorkoutSchedule>();
        }
    }
}
