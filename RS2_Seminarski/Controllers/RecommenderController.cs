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
    public class RecommenderController : ControllerBase
    {
        private readonly FitnessCenterDbContext _context;
        private readonly RecommenderService _recommenderService;
        private readonly AuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public RecommenderController(FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _recommenderService = new RecommenderService(_context, _mapper);
            _authenticationService = new AuthenticationService(_context);
        }

        [HttpGet("{id}")]
        public List<Models.Suplements.Suplement> GetSimilarSuplements(int suplementId)
        {
            UserInfo userInfo = _authenticationService.IsAuthorized(Request, "CLIENT");
            return _recommenderService.GetSimilarSuplements(suplementId, userInfo);
        }
    }
}