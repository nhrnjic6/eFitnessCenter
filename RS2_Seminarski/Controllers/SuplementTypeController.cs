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
    public class SuplementTypeController : ControllerBase
    {
        private readonly FitnessCenterDbContext _context;
        private readonly SuplementTypeService _suplementTypeService;
        private readonly AuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public SuplementTypeController(FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _suplementTypeService = new SuplementTypeService(_context, _mapper);
            _authenticationService = new AuthenticationService(_context);
        }

        [HttpGet]
        public List<Models.Suplements.SuplementType> GetAll()
        {
            return _suplementTypeService.GetAll();
        }
    }
}