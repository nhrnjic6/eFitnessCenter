using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Requests;
using Models.Requests.Suplements;
using RS2_Seminarski.Database;
using RS2_Seminarski.Exceptions;
using RS2_Seminarski.Security;
using RS2_Seminarski.Services;

namespace RS2_Seminarski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuplementsController : ControllerBase
    {
        private readonly FitnessCenterDbContext _context;
        private readonly SuplementsService _suplementsService;
        private readonly AuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public SuplementsController(FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _suplementsService = new SuplementsService(_context, _mapper);
            _authenticationService = new AuthenticationService(_context);
        }

        [HttpGet]
        public List<Models.Suplements.Suplement> GetAll([FromQuery] SuplementSearchParams suplementSearch)
        {
            UserInfo userInfo = _authenticationService.IsAuthorized(Request, new string[] { "EMPLOYEE", "CLIENT", "TRAINER" });
            return _suplementsService.GetAll(suplementSearch, userInfo);
        }

        [HttpGet("{id}")]
        public Models.Suplements.Suplement GetById(int id)
        {
            UserInfo userInfo = _authenticationService.IsAuthorized(Request, new string[] { "EMPLOYEE", "CLIENT" });
            return _suplementsService.GetById(id, userInfo);
        }

        [HttpPost]
        public Models.Suplements.Suplement Create(SuplementCreateRequest suplementCreateRequest)
        {
            validateModel();
            _authenticationService.IsAuthorized(Request, "EMPLOYEE");
            return _suplementsService.Create(suplementCreateRequest);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, SuplementCreateRequest suplementCreateRequest)
        {
            validateModel();
            _authenticationService.IsAuthorized(Request, "EMPLOYEE");
            _suplementsService.Update(id,suplementCreateRequest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            validateModel();
            _authenticationService.IsAuthorized(Request, "EMPLOYEE");
            _suplementsService.Delete(id);
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