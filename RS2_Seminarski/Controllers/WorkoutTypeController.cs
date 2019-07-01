using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS2_Seminarski.Database;
using RS2_Seminarski.Services;

namespace RS2_Seminarski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutTypeController : ControllerBase
    {
        private readonly FitnessCenterDbContext _context;
        private readonly WorkoutTypeService _workoutTypeService;
        private readonly IMapper _mapper;

        public WorkoutTypeController(FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _workoutTypeService = new WorkoutTypeService(_context, _mapper);
        }

        [HttpGet]
        public List<Models.Workout.WorkoutType> Get()
        {
            return _workoutTypeService.GetAll();
        }

    }
}