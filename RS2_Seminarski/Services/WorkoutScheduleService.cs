using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models.Requests.Workout;
using Models.Workout;
using RS2_Seminarski.Exceptions;
using RS2_Seminarski.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Services
{
    public class WorkoutScheduleService
    {
        private readonly IMapper _mapper;
        private readonly Database.FitnessCenterDbContext _context;

        public WorkoutScheduleService(Database.FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<WorkoutSchedule> GetAll(WorkoutScheduleSearchParams searchParams)
        {
            var query = _context.WorkoutSchedules
                .Include(x => x.Workout)
                .AsQueryable();

            if (searchParams.DayOfWeek != null)
            {
               query = query.Where(x => x.DayOfTheWeek == searchParams.DayOfWeek);
            }

            if (!string.IsNullOrEmpty(searchParams.WorkoutId))
            {
                int id = int.Parse(searchParams.WorkoutId);
                query = query.Where(x => x.WorkoutId == id);
            }

            if(searchParams.TimeFrom != null)
            {
                query = query.Where(x => x.TimeOfTheDay >= searchParams.TimeFrom);
            }

            if (searchParams.TimeTo != null)
            {
                query = query.Where(x => x.TimeOfTheDay <= searchParams.TimeTo);
            }

            return query
                .OrderBy(x => x.WorkoutId)
                .OrderBy(x => x.TimeOfTheDay)
                .Select(x => WorkoutScheduleMapper.fromDb(x))
                .ToList();
        }

        public WorkoutSchedule GetById(int Id)
        {
            Database.WorkoutSchedule workoutSchedule = _context.WorkoutSchedules
                .Include(x => x.Workout)
                .Where(x => x.Id == Id)
                .FirstOrDefault();

            if(workoutSchedule == null)
            {
                throw new ResourceNotFoundException($"WorkoutSchedule with id: {Id} not found");
            }

            return WorkoutScheduleMapper.fromDb(workoutSchedule);
        }

        public WorkoutSchedule Create(Models.Requests.Workout.WorkoutScheduleCreate createRequest)
        {
            // da li u isto vrijeme postoji vec trening
            Database.Workout workout = _context.Workouts.Find(createRequest.WorkoutId);

            if (workout == null)
            {
                throw new ResourceNotFoundException($"Workout with id {createRequest.WorkoutId} not found");
            }

            // adds 15 minutes after workout in order to prepare for new workout
            TimeSpan workoutEnd = new TimeSpan(
                createRequest.TimeOfTheDay.Hours,
                createRequest.TimeOfTheDay.Minutes + workout.Duration + 15, 
                createRequest.TimeOfTheDay.Seconds);

            Database.WorkoutSchedule workoutSchedule = _context.WorkoutSchedules
                .Where(x => x.DayOfTheWeek == createRequest.DayOfTheWeek)
                .Where(x => new TimeSpan(x.TimeOfTheDay.Hours, x.TimeOfTheDay.Minutes + x.Workout.Duration + 15, 0) > createRequest.TimeOfTheDay
                    &&
                       x.TimeOfTheDay < workoutEnd
                ).FirstOrDefault();

            if(workoutSchedule != null)
            {
                throw new WorkoutScheduleTakenException("This time slot is taken by another workout");
            }

            Database.WorkoutSchedule newWorkoutSchedule = _mapper.Map<Database.WorkoutSchedule>(createRequest);
            _context.WorkoutSchedules.Add(newWorkoutSchedule);
            _context.SaveChanges();

            return GetById(newWorkoutSchedule.Id);
        }

        public void Update(int id, Models.Requests.Workout.WorkoutScheduleCreate createRequest)
        {
            Database.WorkoutSchedule dbSchedule = _context.WorkoutSchedules.Find(id);

            if(dbSchedule == null)
            {
                throw new ResourceNotFoundException($"Workout Schedule with id {createRequest.WorkoutId} not found");
            }

            // da li u isto vrijeme postoji vec trening
            Database.Workout workout = _context.Workouts.Find(createRequest.WorkoutId);

            if (workout == null)
            {
                throw new ResourceNotFoundException($"Workout with id {createRequest.WorkoutId} not found");
            }

            // adds 15 minutes after workout in order to prepare for new workout
            TimeSpan workoutEnd = new TimeSpan(
                createRequest.TimeOfTheDay.Hours,
                createRequest.TimeOfTheDay.Minutes + workout.Duration + 15,
                createRequest.TimeOfTheDay.Seconds);

            Database.WorkoutSchedule workoutSchedule = _context.WorkoutSchedules
                .Where(x => x.Id != id)
                .Where(x => x.DayOfTheWeek == createRequest.DayOfTheWeek)
                .Where(x => new TimeSpan(x.TimeOfTheDay.Hours, x.TimeOfTheDay.Minutes + x.Workout.Duration + 15, 0) > createRequest.TimeOfTheDay
                    &&
                       x.TimeOfTheDay < workoutEnd
                ).FirstOrDefault();

            if (workoutSchedule != null)
            {
                throw new WorkoutScheduleTakenException("This time slot is taken by another workout");
            }

            _mapper.Map(createRequest, dbSchedule);
            _context.WorkoutSchedules.Update(dbSchedule);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Database.WorkoutSchedule dbSchedule = _context.WorkoutSchedules.Find(id);

            if (dbSchedule == null)
            {
                throw new ResourceNotFoundException($"Workout Schedule with id {id} not found");
            }

            _context.WorkoutSchedules.Remove(dbSchedule);
            _context.SaveChanges();
        }
    }
}
