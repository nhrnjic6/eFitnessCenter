using AutoMapper;
using Models.Requests.Clients;
using RS2_Seminarski.Database;
using RS2_Seminarski.Mappers;
using RS2_Seminarski.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Services
{
    public class ClientsService
    {
        private readonly IMapper _mapper;
        private readonly FitnessCenterDbContext _context;

        public ClientsService(FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Models.Clients.Client Create(CreateClientRequest createClientRequest)
        {
            Database.AppUser appUser = _mapper.Map<Database.AppUser>(createClientRequest);
            appUser.HashedPassword = HashUtil.ComputeSha256Hash(createClientRequest.Password);
            appUser.CreatedAt = DateTime.UtcNow;
            appUser.Status = UserStatus.INACTIVE;

            // add client specific data
            Database.Client client = new Database.Client();
            appUser.Client = client;

            _context.AppUsers.Add(appUser);
            _context.SaveChanges();
            return _mapper.Map<Models.Clients.Client>(appUser);
        }
    }
}
