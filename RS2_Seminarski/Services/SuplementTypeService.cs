using AutoMapper;
using RS2_Seminarski.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Services
{
    public class SuplementTypeService
    {
        private readonly IMapper _mapper;
        private readonly FitnessCenterDbContext _context;

        public SuplementTypeService(FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Models.Suplements.SuplementType> GetAll()
        {
            return _context.SuplementTypes
                .Select(x => _mapper.Map<Models.Suplements.SuplementType>(x))
                .ToList();
        }
    }
}
