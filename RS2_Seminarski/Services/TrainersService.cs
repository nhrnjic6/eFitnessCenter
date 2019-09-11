using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models.Requests.Clients;
using Models.Requests.Trainers;
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
    public class TrainersService
    {
        private readonly IMapper _mapper;
        private readonly FitnessCenterDbContext _context;

        public TrainersService(FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Models.Trainers.Trainer> GetAll(SearchTrainerParams searchTrainerParams)
        {
            var query = _context.AppUsers.AsQueryable()
                .Include(x => x.Trainer)
                .Where(x => x.Trainer != null);

            if(searchTrainerParams.UserStatus != null)
            {
                Database.UserStatus userStatus = (Database.UserStatus)(int)searchTrainerParams.UserStatus;
                query = query.Where(x => x.Status == userStatus);
            }

            if(!string.IsNullOrEmpty(searchTrainerParams.FirstName))
            {
                query = query.Where(x => x.FirstName == searchTrainerParams.FirstName);
            }

            if (!string.IsNullOrEmpty(searchTrainerParams.LastName))
            {
                query = query.Where(x => x.LastName == searchTrainerParams.LastName);
            }

            List<Models.Trainers.Trainer> trainers = query
                .Select(x => _mapper.Map<Models.Trainers.Trainer>(x))
                .ToList();

            return trainers;
        }

        public Models.Trainers.Trainer GetById(int id)
        {
            Models.Trainers.Trainer trainer = _context.AppUsers
                .Where(x => x.Id == id)
                .Select(x => _mapper.Map<Models.Trainers.Trainer>(x))
                .FirstOrDefault();

            if(trainer == null)
            {
                throw new ResourceNotFoundException("Trainer with id: " + id + " not found");
            }

            return trainer;
        }

        public Models.Trainers.Trainer Create(CreateTrainerRequest createTrainerRequest)
        {   
            Database.AppUser appUser = _mapper.Map<Database.AppUser>(createTrainerRequest);
            appUser.HashedPassword = HashUtil.ComputeSha256Hash(createTrainerRequest.Password);
            appUser.CreatedAt = DateTime.UtcNow;
            appUser.Status = Database.UserStatus.ACTIVE;

            // add trainer specific data
            Database.Trainer trainer = new Database.Trainer();
            appUser.Trainer = trainer;

            _context.AppUsers.Add(appUser);
            _context.SaveChanges();
            return _mapper.Map<Models.Trainers.Trainer>(appUser);
        }

        public void Update(int id, UpdateTrainerRequest updateTrainerRequest)
        {
            Database.AppUser trainer = _context.AppUsers
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (trainer == null)
            {
                throw new ResourceNotFoundException("Trainer with id: " + id + " not found");
            }

            _mapper.Map(updateTrainerRequest, trainer);
            trainer.HashedPassword = HashUtil.ComputeSha256Hash(updateTrainerRequest.Password); 

            _context.AppUsers.Update(trainer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Database.AppUser trainer = _context.AppUsers
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (trainer == null)
            {
                throw new ResourceNotFoundException("Trainer with id: " + id + " not found");
            }

            trainer.Status = Database.UserStatus.DELETED;
            _context.AppUsers.Update(trainer);
            _context.SaveChanges();
        }
    }
}
