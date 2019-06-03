using AutoMapper;
using Models.Requests.Clients;
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
        }
    }
}
