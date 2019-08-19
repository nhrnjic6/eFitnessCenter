using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Requests.Trainers;
using RS2_Seminarski.Database;
using RS2_Seminarski.Exceptions;
using RS2_Seminarski.Mappers;
using RS2_Seminarski.Security;
using RS2_Seminarski.Services;

namespace RS2_Seminarski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly FitnessCenterDbContext _context;
        private readonly TrainersService _trainersService;
        private readonly AuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public TrainersController(FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _trainersService = new TrainersService(_context, _mapper);
            _authenticationService = new AuthenticationService(_context);
        }

        [HttpGet]
        public List<Models.Trainers.Trainer> Get([FromQuery] SearchTrainerParams searchTrainerParams)
        {
            _authenticationService.IsAuthorized(Request, new[] { "EMPLOYEE", "TRAINER" });
            return _trainersService.GetAll(searchTrainerParams);
        }

        [HttpGet("{id}")]
        public Models.Trainers.Trainer GetById(int id)
        {
            return _trainersService.GetById(id);
        }

        [HttpPost]
        public Models.Trainers.Trainer Create(CreateTrainerRequest createTrainerRequest)
        {
            _authenticationService.IsAuthorized(Request, "EMPLOYEE");
            validateModel();
            return _trainersService.Create(createTrainerRequest);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _authenticationService.IsAuthorized(Request, "EMPLOYEE");
            _trainersService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateTrainerRequest updateTrainerRequest)
        {
            _authenticationService.IsAuthorized(Request, "EMPLOYEE");
            validateModel();
            _trainersService.Update(id, updateTrainerRequest);
            return NoContent();
        }

        private void validateModel()
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidModelStateException("Invalid model");
            }
        }
    }
}