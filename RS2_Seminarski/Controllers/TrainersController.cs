using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS2_Seminarski.Database;
using RS2_Seminarski.Mappers;

namespace RS2_Seminarski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly FitnessCenterDbContext _context;

        public TrainersController(FitnessCenterDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Models.Trainers.Trainer> GetAll()
        {
            return _context.Trainers
                .Include(x => x.AppUser)
                .Select(x => TrainerMapper.fromDb(x))
                .ToList();
        }

        
    }
}