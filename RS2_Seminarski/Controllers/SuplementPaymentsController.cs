using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Requests.Suplements;
using Models.Suplements;
using RS2_Seminarski.Exceptions;
using RS2_Seminarski.Security;
using RS2_Seminarski.Services;

namespace RS2_Seminarski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuplementPaymentsController : ControllerBase
    {
        private readonly Database.FitnessCenterDbContext _context;
        private readonly SuplementPaymentService _paymentService;
        private readonly AuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public SuplementPaymentsController(Database.FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _paymentService = new SuplementPaymentService(_context, _mapper);
            _authenticationService = new AuthenticationService(_context);
        }

        [HttpGet]
        public List<SuplementPayment> GetAll([FromQuery] SuplementPaymentSearchParams searchParams)
        {
            _authenticationService.IsAuthorized(Request, "EMPLOYEE");
            return _paymentService.GetAll(searchParams);
        }

        [HttpGet("{id}")]
        public SuplementPayment GetById(int id)
        {
            _authenticationService.IsAuthorized(Request, "EMPLOYEE");
            return _paymentService.GetById(id);
        }

        [HttpPost]
        public SuplementPayment Create(SuplementPaymentRequest paymentRequest)
        {
            validateModel();
            UserInfo info = _authenticationService.IsAuthorized(Request, "EMPLOYEE");
            return _paymentService.Create(paymentRequest, info);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, SuplementPaymentRequest paymentRequest)
        {
            validateModel();
            UserInfo info = _authenticationService.IsAuthorized(Request, "EMPLOYEE");
            _paymentService.Update(id ,paymentRequest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            validateModel();
            UserInfo info = _authenticationService.IsAuthorized(Request, "EMPLOYEE");
            _paymentService.Delete(id);
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