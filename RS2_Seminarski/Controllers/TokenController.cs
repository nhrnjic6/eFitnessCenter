using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Requests.Token;
using RS2_Seminarski.Database;
using RS2_Seminarski.Security;

namespace RS2_Seminarski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly FitnessCenterDbContext _context;
        private readonly AuthenticationService authenticationService;

        public TokenController(FitnessCenterDbContext context)
        {   
            _context = context;
            authenticationService = new AuthenticationService(_context);
        }

        [HttpPost]
        public TokenResponse CreateToken(GetTokenPost getTokenPost)
        {
            string token = authenticationService.AuthenticateUser(
                getTokenPost.Email, getTokenPost.Password
            );

            return new TokenResponse
            {
                AccessToken = token
            };
        }
    }
}