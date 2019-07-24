using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Requests.Workout;
using RS2_Seminarski.Database;
using RS2_Seminarski.Security;
using RS2_Seminarski.Services;

namespace RS2_Seminarski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutAdviceController : ControllerBase
    {
        private readonly FitnessCenterDbContext _context;
        private readonly WorkoutAdviceService _workoutAdviceService;
        private readonly AuthenticationService _authenticationService;

        public WorkoutAdviceController(FitnessCenterDbContext context)
        {
            _context = context;
            _workoutAdviceService = new WorkoutAdviceService(_context);
            _authenticationService = new AuthenticationService(_context);
        }

        [HttpGet]
        public List<Models.Workout.WorkoutAdvice> GetAll([FromQuery] WorkoutAdviceQueryParams queryParams)
        {
           return _workoutAdviceService.GetAll(queryParams);
        }

        [HttpGet("{id}")]
        public Models.Workout.WorkoutAdvice GetById(int id)
        {
            return _workoutAdviceService.GetById(id);
        }

        [HttpPost]
        public Models.Workout.WorkoutAdvice Create(Models.Requests.Workout.WorkoutAdviceCreate adviceCreate)
        {
            return _workoutAdviceService.Create(adviceCreate);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Models.Requests.Workout.WorkoutAdviceCreate adviceCreate)
        {
            _workoutAdviceService.Update(id, adviceCreate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _workoutAdviceService.Delete(id);
            return NoContent();
        }
    }
}