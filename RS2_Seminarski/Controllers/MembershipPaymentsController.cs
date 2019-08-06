using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Membership;
using Models.Requests.Membership;
using RS2_Seminarski.Exceptions;
using RS2_Seminarski.Security;
using RS2_Seminarski.Services;

namespace RS2_Seminarski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipPaymentsController : ControllerBase
    {
        private readonly Database.FitnessCenterDbContext _context;
        private readonly AuthenticationService _authenticationService;
        private readonly MembershipPaymentService _membershipPaymentService;
        private readonly IMapper _mapper;

        public MembershipPaymentsController(Database.FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _authenticationService = new AuthenticationService(_context);
            _membershipPaymentService = new MembershipPaymentService(_context, _mapper);
        }

        [HttpGet]
        public List<MembershipPayment> GetAll([FromQuery] MembershipPaymentSearchParams searchParams)
        {
            UserInfo userInfo = _authenticationService.IsAuthorized(Request, new[] { "EMPLOYEE", "CLIENT" });
            return _membershipPaymentService.GetAll(searchParams, userInfo);
        }

        [HttpPost]
        public MembershipPayment Create(
            MembershipPaymentCreate membershipPaymentCreate)
        {
            UserInfo userInfo = _authenticationService.IsAuthorized(Request, "EMPLOYEE");
            validateModel();
            return _membershipPaymentService.Create(membershipPaymentCreate, userInfo.Id);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, MembershipPaymentUpdate membershipPaymentUpdate)
        {
            _authenticationService.IsAuthorized(Request, "EMPLOYEE");
            validateModel();
            _membershipPaymentService.Update(id, membershipPaymentUpdate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _authenticationService.IsAuthorized(Request, "EMPLOYEE");
            validateModel();
            _membershipPaymentService.Delete(id);
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