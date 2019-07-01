using AutoMapper;
using RS2_Seminarski.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Services
{
    public class WorkoutTypeService
    {
        private readonly IMapper _mapper;
        private readonly FitnessCenterDbContext _context;

        public WorkoutTypeService(FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Models.Workout.WorkoutType> GetAll()
        {
            return _context.Workouts
                .Select(x => _mapper.Map<Models.Workout.WorkoutType>(x))
                .ToList();
        }
    }
}
