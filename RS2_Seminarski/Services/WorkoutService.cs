using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RS2_Seminarski.Database;
using RS2_Seminarski.Exceptions;
using RS2_Seminarski.Mappers;
using System.Collections.Generic;
using System.Linq;

namespace RS2_Seminarski.Services
{
    public class WorkoutService
    {
        private readonly IMapper _mapper;
        private readonly FitnessCenterDbContext _context;

        public WorkoutService(FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Models.Workout.Workout> GetAll(Models.Requests.Workout.WorkoutSearchParams searchParams)
        {
            IQueryable<Workout> query = _context.Workouts
                .Include(x => x.WorkoutType)
                .Include(x => x.Trainer)
                    .ThenInclude(x => x.AppUser)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchParams.Difficulty))
            {
                query = query.Where(x => x.Difficulty.Equals(searchParams.Difficulty));
            }

            if (searchParams.Duration != null)
            {
                query = query.Where(x => x.Duration.Equals(searchParams.Difficulty));
            }

            if (searchParams.TrainerId != null)
            {
                query = query.Where(x => x.Trainer.AppUser.Id.Equals(searchParams.TrainerId));
            }

            if (string.IsNullOrEmpty(searchParams.WorkoutType))
            {
                query = query.Where(x => x.WorkoutType.Name.Equals(searchParams.WorkoutType));
            }

            return query.Select(x => WorkoutMapper.FromDb(x))
                .ToList();
        }

        public Models.Workout.Workout GetById(int Id)
        {
            Workout dbWorkout = _context.Workouts
                .Include(x => x.WorkoutType)
                .Include(x => x.Trainer)
                    .ThenInclude(x => x.AppUser)
                .Where(x => x.Id == Id)
                .FirstOrDefault();

            if (dbWorkout == null)
            {
                throw new ResourceNotFoundException($"Workout with id {Id} not found");
            }

            return WorkoutMapper.FromDb(dbWorkout);
        }

        public Models.Workout.Workout Create(Models.Requests.Workout.WorkoutCreateRequest createRequest)
        {
            Trainer dbTrainer = _context.Trainers.Find(createRequest.TrainerId);
            if(dbTrainer == null)
            {
                throw new ResourceNotFoundException($"Trainer with id {createRequest.TrainerId} not found");
            }

            WorkoutType workoutType = _context.WorkoutTypes.Find(createRequest.WorkoutTypeId);
            if (workoutType == null)
            {
                throw new ResourceNotFoundException($"Workout Type with id {createRequest.TrainerId} not found");
            }

            Workout dbWorkout = new Workout
            {
                Trainer = dbTrainer,
                WorkoutType = workoutType,
                Description = createRequest.Description,
                Difficulty = createRequest.Difficulty,
                Duration = createRequest.Duration,
                Name = createRequest.Name,
                CreatedAt = System.DateTime.Now
            };

            _context.Workouts.Add(dbWorkout);
            _context.SaveChanges();

            return GetById(dbWorkout.Id);
        }

        public void Update(int Id, Models.Requests.Workout.WorkoutCreateRequest updateRequest)
        {
            Workout dbWorkout = _context.Workouts.Find(Id);
            if(dbWorkout == null)
            {
                throw new ResourceNotFoundException($"Workout with id {Id} not found");
            }

            Trainer dbTrainer = _context.Trainers.Find(updateRequest.TrainerId);
            if (dbTrainer == null)
            {
                throw new ResourceNotFoundException($"Trainer with id {updateRequest.TrainerId} not found");
            }

            WorkoutType workoutType = _context.WorkoutTypes.Find(updateRequest.WorkoutTypeId);
            if (workoutType == null)
            {
                throw new ResourceNotFoundException($"Workout Type with id {updateRequest.TrainerId} not found");
            }

            dbWorkout.Trainer = dbTrainer;
            dbWorkout.WorkoutType = workoutType;
            dbWorkout.Name = updateRequest.Name;
            dbWorkout.Description = updateRequest.Description;
            dbWorkout.Difficulty = updateRequest.Difficulty;
            dbWorkout.Duration = updateRequest.Duration;

            _context.Workouts.Update(dbWorkout);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            Workout dbWorkout = _context.Workouts.Find(Id);
            if (dbWorkout == null)
            {
                throw new ResourceNotFoundException($"Workout with id {Id} not found");
            }

            _context.Workouts.Remove(dbWorkout);
            _context.SaveChanges();
        }
    }
}
