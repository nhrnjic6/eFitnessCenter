using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Requests.Clients;
using RS2_Seminarski.Database;
using RS2_Seminarski.Exceptions;
using RS2_Seminarski.Security;
using RS2_Seminarski.Services;

namespace RS2_Seminarski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly FitnessCenterDbContext _context;
        private readonly ClientsService _clientsService;
        private readonly AuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public ClientsController(FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _clientsService = new ClientsService(_context, _mapper);
            _authenticationService = new AuthenticationService(_context);
        }

        [HttpGet]
        public List<Models.Clients.Client> Get([FromQuery] SearchClientParams searchClientParams)
        {
            _authenticationService.IsAuthorized(Request, new[] { "EMPLOYEE", "TRAINER" });
            return _clientsService.GetAll(searchClientParams);
        }

        [HttpGet("{id}")]
        public Models.Clients.Client GetById(int id)
        {
            return _clientsService.GetById(id);
        }

        [HttpPost]
        public Models.Clients.Client Create(CreateClientRequest createClientRequest)
        {
            _authenticationService.IsAuthorized(Request, "EMPLOYEE");
            validateModel();
            return _clientsService.Create(createClientRequest);
        } 

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _authenticationService.IsAuthorized(Request, "EMPLOYEE");
            _clientsService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateClientRequest updateClientRequest)
        {
            _authenticationService.IsAuthorized(Request, "EMPLOYEE");
            validateModel();
            _clientsService.Update(id, updateClientRequest);
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