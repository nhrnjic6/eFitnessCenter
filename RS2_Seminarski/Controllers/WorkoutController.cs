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
        public List<Models.Workout.Workout> GetAll(Models.Requests.Workout.WorkoutSearchParams searchParams)
        {
            return _workourService.GetAll(searchParams);
        }

        [HttpPost]
        public Models.Workout.Workout Create(Models.Requests.Workout.WorkoutCreateRequest createRequest)
        {
            return _workourService.Create(createRequest);
        }

        [HttpPut]
        public void Update(int Id, Models.Requests.Workout.WorkoutCreateRequest updateRequest)
        {
            _workourService.Update(Id, updateRequest);
        }

        [HttpDelete]
        public void Delete(int Id)
        {
            _workourService.Delete(Id);
        }

    }
}