using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Requests.Suplements;
using RS2_Seminarski.Database;
using RS2_Seminarski.Security;
using RS2_Seminarski.Services;

namespace RS2_Seminarski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuplementRatingController : ControllerBase
    {
        private readonly FitnessCenterDbContext _context;
        private readonly SuplementRatingService _ratingService;
        private readonly AuthenticationService _authenticationService;

        public SuplementRatingController(FitnessCenterDbContext context)
        {
            _context = context;
            _ratingService = new SuplementRatingService(_context);
            _authenticationService = new AuthenticationService(_context);
        }

        [HttpPost("rating")]
        public IActionResult RateSuplement(SuplementRatingCreate suplementRating)
        {
            UserInfo userInfo = _authenticationService.IsAuthorized(Request, "CLIENT");
            _ratingService.CreateOrUpdateSuplementRating(suplementRating, userInfo);
            return NoContent();
        }
    }
}