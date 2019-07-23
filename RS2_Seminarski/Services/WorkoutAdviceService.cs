﻿using Microsoft.EntityFrameworkCore;
using Models.Requests.Workout;
using RS2_Seminarski.Database;
using RS2_Seminarski.Exceptions;
using RS2_Seminarski.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Services
{
    public class WorkoutAdviceService
    {
        private readonly FitnessCenterDbContext _context;

        public WorkoutAdviceService(FitnessCenterDbContext context)
        {
            _context = context;
        }

        public List<Models.Workout.WorkoutAdvice> GetAll(WorkoutAdviceQueryParams queryParams)
        {
            var query = _context.WorkoutAdvices
                .Include(x => x.Client)
                    .ThenInclude(x => x.AppUser)
                .Include(x => x.Trainer)
                    .ThenInclude(x => x.AppUser)
                .AsQueryable();

            if(queryParams.ClientId != null)
            {
                query = query.Where(x => x.ClientId == queryParams.ClientId);
            }

            if (queryParams.TrainerId != null)
            {
                query = query.Where(x => x.TrainerId == queryParams.TrainerId);
            }

            return query.Select(x => WorkoutAdviceMapper.fromDb(x))
                .ToList();
        }

        public Models.Workout.WorkoutAdvice GetById(int id)
        {
            var dbAdvice = _context.WorkoutAdvices
                .Include(x => x.Client)
                    .ThenInclude(x => x.AppUser)
                .Include(x => x.Trainer)
                    .ThenInclude(x => x.AppUser)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (dbAdvice == null)
            {
                throw new ResourceNotFoundException($"Workour advice with id {id} not found");
            }

            return WorkoutAdviceMapper.fromDb(dbAdvice);
        }

        public Models.Workout.WorkoutAdvice Create(Models.Requests.Workout.WorkoutAdviceCreate adviceCreate)
        {
            Client dbClient = _context.Clients.Find(adviceCreate.ClientId);
            if(dbClient == null)
            {
                throw new ResourceNotFoundException($"Client with id {adviceCreate.ClientId} not found");
            }

            Trainer dbTrainer = _context.Trainers.Find(adviceCreate.TrainerId);
            if (dbTrainer == null)
            {
                throw new ResourceNotFoundException($"Trainer with id {adviceCreate.TrainerId} not found");
            }

            WorkoutAdvice dbWorkoutAdvice = WorkoutAdviceMapper.toDb(adviceCreate);
            _context.WorkoutAdvices.Add(dbWorkoutAdvice);
            _context.SaveChanges();
            return GetById(dbWorkoutAdvice.Id);
        }

        public void Update(int id, Models.Requests.Workout.WorkoutAdviceCreate adviceCreate)
        {
            WorkoutAdvice dbWorkoutAdvice = _context.WorkoutAdvices.Find(id);
            if (dbWorkoutAdvice == null)
            {
                throw new ResourceNotFoundException($"Workout advice with id {id} not found");
            }

            Client dbClient = _context.Clients.Find(adviceCreate.ClientId);
            if (dbClient == null)
            {
                throw new ResourceNotFoundException($"Client with id {adviceCreate.ClientId} not found");
            }

            Trainer dbTrainer = _context.Trainers.Find(adviceCreate.TrainerId);
            if (dbTrainer == null)
            {
                throw new ResourceNotFoundException($"Trainer with id {adviceCreate.TrainerId} not found");
            }

            if (adviceCreate.Message != null) dbWorkoutAdvice.Message = adviceCreate.Message;
            if (adviceCreate.ClientId != null) dbWorkoutAdvice.ClientId = adviceCreate.ClientId;
            if (adviceCreate.TrainerId != null) dbWorkoutAdvice.TrainerId = adviceCreate.TrainerId;

            _context.WorkoutAdvices.Update(dbWorkoutAdvice);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            WorkoutAdvice dbWorkoutAdvice = _context.WorkoutAdvices.Find(id);
            if (dbWorkoutAdvice == null)
            {
                throw new ResourceNotFoundException($"Workout advice with id {id} not found");
            }

            _context.WorkoutAdvices.Remove(dbWorkoutAdvice);
            _context.SaveChanges();
        }
    }
}
