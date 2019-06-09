using AutoMapper;
using Models.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Services
{
    public class MembershipTypeService
    {
        private readonly IMapper _mapper;
        private readonly Database.FitnessCenterDbContext _context;

        public MembershipTypeService(Database.FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<MembershipType> GetAll()
        {
            return _context.MembershipTypes
                .Select(x => _mapper.Map<MembershipType>(x))
                .ToList();
        }
    }
}
