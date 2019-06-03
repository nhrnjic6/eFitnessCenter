﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Requests.Clients;
using RS2_Seminarski.Database;
using RS2_Seminarski.Exceptions;
using RS2_Seminarski.Services;

namespace RS2_Seminarski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly FitnessCenterDbContext _context;
        private readonly ClientsService _clientsService;
        private readonly IMapper _mapper;

        public ClientsController(FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _clientsService = new ClientsService(_context, _mapper);
        }

        [HttpGet]
        public List<Models.Clients.Client> Get()
        {
            return _clientsService.GetAll();
        }

        [HttpGet("{id}")]
        public Models.Clients.Client GetById(int id)
        {
            return _clientsService.GetById(id);
        }

        [HttpPost]
        public Models.Clients.Client Create(CreateClientRequest createClientRequest)
        {
            validateModel();
            return _clientsService.Create(createClientRequest);
        } 

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _clientsService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateClientRequest updateClientRequest)
        {
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