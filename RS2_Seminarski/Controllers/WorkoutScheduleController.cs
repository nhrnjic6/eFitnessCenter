using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RS2_Seminarski.Database;
using RS2_Seminarski.Security;
using RS2_Seminarski.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RS2_Seminarski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutScheduleController : ControllerBase
    {
        private readonly FitnessCenterDbContext _context;
        private readonly WorkoutScheduleService _workoutScheduleService;
        private readonly AuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public WorkoutScheduleController(FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _workoutScheduleService = new WorkoutScheduleService(_context, _mapper);
            _authenticationService = new AuthenticationService(_context);
        }

        [HttpGet]
        public List<Models.Workout.WorkoutSchedule> GetAll([FromQuery] Models.Requests.Workout.WorkoutScheduleSearchParams searchParams)
        {
            return _workoutScheduleService.GetAll(searchParams);
        }

        [HttpPost]
        public Models.Workout.WorkoutSchedule Create(Models.Requests.Workout.WorkoutScheduleCreate createRequest)
        {
            return _workoutScheduleService.Create(createRequest);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Models.Requests.Workout.WorkoutScheduleCreate createRequest)
        {
            _workoutScheduleService.Update(id, createRequest);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _workoutScheduleService.Delete(id);
            return NoContent();
        }
    }
}
