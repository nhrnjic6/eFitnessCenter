using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models.Requests;
using Models.Requests.Suplements;
using RS2_Seminarski.Database;
using RS2_Seminarski.Exceptions;
using RS2_Seminarski.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Services
{
    public class SuplementsService
    {
        private readonly IMapper _mapper;
        private readonly FitnessCenterDbContext _context;
        private readonly SuplementRatingService _suplementRatingService;

        public SuplementsService(FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _suplementRatingService = new SuplementRatingService(_context);
        }

        public Models.Suplements.Suplement GetById(int id, UserInfo userInfo)
        {
            Database.Suplement dbSuplement = _context.Suplements
                .AsQueryable()
                .Include(x => x.SuplementType)
                .Include(x => x.SuplementsRatings)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if(dbSuplement == null)
            {
                throw new ResourceNotFoundException($"Suplement with id: {id} not found");
            }

            return mapFromDb(dbSuplement, userInfo);
        }

        public List<Models.Suplements.Suplement> GetAll(SuplementSearchParams suplementSearch, UserInfo userInfo)
        {
            IQueryable<Database.Suplement> query = _context.Suplements
                .AsQueryable()
                .Include(x => x.SuplementType)
                .Include(x => x.SuplementsRatings);

            if (!string.IsNullOrEmpty(suplementSearch.Name))
            {
                query = query.Where(x => x.Name == suplementSearch.Name);
            }

            if (!string.IsNullOrEmpty(suplementSearch.Type))
            {
                query = query.Where(x => x.SuplementType.Type == suplementSearch.Type);
            }

            return query.ToList()
                .Select(x => mapFromDb(x, userInfo))
                .ToList();
        }

        public Models.Suplements.Suplement Create(SuplementCreateRequest suplementCreateRequest)
        {
            Database.Suplement suplement = _mapper.Map<Database.Suplement>(suplementCreateRequest);
            suplement.CreatedAt = DateTime.Now;
            _context.Suplements.Add(suplement);
            _context.SaveChanges();
            return mapFromDb(suplement, null);
        }

        public void Update(int id ,SuplementCreateRequest suplementCreateRequest)
        {
            Database.Suplement suplement = _context.Suplements.Find(id);

            if(suplement == null)
            {
                throw new ResourceNotFoundException($"Resource with id: {id} not found");
            }

            _mapper.Map(suplementCreateRequest, suplement);
            _context.Suplements.Update(suplement);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Database.Suplement suplement = _context.Suplements.Find(id);

            if (suplement == null)
            {
                throw new ResourceNotFoundException($"Resource with id: {id} not found");
            }

            _context.Suplements.Remove(suplement);
            _context.SaveChanges();
        }

        private Models.Suplements.Suplement mapFromDb(Database.Suplement dbSuplement, UserInfo userInfo)
        {
            Models.Suplements.Suplement suplement = new Models.Suplements.Suplement();
            _mapper.Map(dbSuplement, suplement);
            suplement.SuplementTypeName = dbSuplement.SuplementType?.Type;
            suplement.CreatedAt = dbSuplement.CreatedAt.ToString("dd-MM-yyyy");

            if(dbSuplement.SuplementsRatings != null && dbSuplement.SuplementsRatings.Count > 0)
            {
                suplement.AverageRating = dbSuplement.SuplementsRatings.Average(x => x.Rating);

                if (userInfo != null)
                {
                    SuplementsRating userSuplementRating = dbSuplement.SuplementsRatings.Where(x => x.ClientId == userInfo.Id).FirstOrDefault();
                    if (userSuplementRating != null)
                    {
                        suplement.UserRating = userSuplementRating.Rating;
                    }
                }
            }

            return suplement;
        }
    }
}
