using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models.Requests.Clients;
using RS2_Seminarski.Database;
using RS2_Seminarski.Exceptions;
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

        public List<Models.Clients.Client> GetAll(SearchClientParams searchClientParams)
        {
            var query = _context.AppUsers.AsQueryable()
                .Include(x => x.Client)
                .Where(x => x.Client != null);
                //.Select(x => _mapper.Map<Models.Clients.Client>(x));

            if(searchClientParams.UserStatus != null)
            {
                Database.UserStatus userStatus = (Database.UserStatus)(int)searchClientParams.UserStatus;
                query = query.Where(x => x.Status == userStatus);
            }

            return query
                .Select(x => _mapper.Map<Models.Clients.Client>(x))
                .ToList();
        }

        public Models.Clients.Client GetById(int id)
        {
            Models.Clients.Client client = _context.AppUsers
                .Where(x => x.Id == id)
                .Select(x => _mapper.Map<Models.Clients.Client>(x))
                .FirstOrDefault();

            if(client == null)
            {
                throw new ResourceNotFoundException("Client with id: " + id + " not found");
            }

            return client;
        }

        public Models.Clients.Client Create(CreateClientRequest createClientRequest)
        {   
            Database.AppUser appUser = _mapper.Map<Database.AppUser>(createClientRequest);
            appUser.HashedPassword = HashUtil.ComputeSha256Hash(createClientRequest.Password);
            appUser.CreatedAt = DateTime.UtcNow;
            appUser.Status = Database.UserStatus.INACTIVE;

            // add client specific data
            Database.Client client = new Database.Client();
            appUser.Client = client;

            _context.AppUsers.Add(appUser);
            _context.SaveChanges();
            return _mapper.Map<Models.Clients.Client>(appUser);
        }

        public void Update(int id, UpdateClientRequest updateClientRequest)
        {
            Database.AppUser client = _context.AppUsers
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (client == null)
            {
                throw new ResourceNotFoundException("Client with id: " + id + " not found");
            }

            _mapper.Map(updateClientRequest, client);

            _context.AppUsers.Update(client);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Database.AppUser client = _context.AppUsers
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (client == null)
            {
                throw new ResourceNotFoundException("Client with id: " + id + " not found");
            }

            client.Status = Database.UserStatus.DELETED;
            _context.AppUsers.Update(client);
            _context.SaveChanges();
        }
    }
}
