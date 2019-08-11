using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS2_Seminarski.Database;
using RS2_Seminarski.Security;
using RS2_Seminarski.Services;

namespace RS2_Seminarski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly FitnessCenterDbContext _context;
        private readonly WorkoutService _workourService;
        private readonly AuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public WorkoutController(FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _workourService = new WorkoutService(_context, _mapper);
            _authenticationService = new AuthenticationService(_context);
        }

        [HttpGet]
        public List<Models.Workout.Workout> GetAll([FromQuery] Models.Requests.Workout.WorkoutSearchParams searchParams)
        {
            UserInfo userInfo = _authenticationService.IsAuthorized(Request, new string[] { "ADMIN", "CLIENT", "TRAINER" });
            return _workourService.GetAll(searchParams, userInfo);
        }

        [HttpPost]
        public Models.Workout.Workout Create(Models.Requests.Workout.WorkoutCreateRequest createRequest)
        {
            return _workourService.Create(createRequest);
        }

        [HttpPut("{id}")]
        public void Update(int id, Models.Requests.Workout.WorkoutCreateRequest updateRequest)
        {
            _workourService.Update(id, updateRequest);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _workourService.Delete(id);
        }

    }
}