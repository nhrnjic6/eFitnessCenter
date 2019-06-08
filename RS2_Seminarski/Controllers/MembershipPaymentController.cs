using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Requests;
using RS2_Seminarski.Database;
using RS2_Seminarski.Security;
using RS2_Seminarski.Services;

namespace RS2_Seminarski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipPaymentController : ControllerBase
    {
        private readonly FitnessCenterDbContext _context;
        private readonly AuthenticationService _authenticationService;
        private readonly MembershipPaymentService _membershipPaymentService;
        private readonly IMapper _mapper;

        public MembershipPaymentController(FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _authenticationService = new AuthenticationService(_context);
            _membershipPaymentService = new MembershipPaymentService(_context, _mapper);
        }

        [HttpGet]
        public List<Models.MembershipPayments.MembershipPayment> GetAll()
        {
            _authenticationService.IsAuthorized(Request, "EMPLOYEE");
            return _membershipPaymentService.GetAll();
        }

        [HttpPost]
        public Models.MembershipPayments.MembershipPayment Create(
            MembershipPaymentCreate membershipPaymentCreate)
        {
            UserInfo userInfo = _authenticationService.IsAuthorized(Request, "EMPLOYEE");
            return _membershipPaymentService.Create(membershipPaymentCreate, userInfo.Id);
        }
    }
}