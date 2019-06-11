using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models.Requests;
using Models.Requests.Suplements;
using RS2_Seminarski.Database;
using RS2_Seminarski.Exceptions;
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

        public SuplementsService(FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Models.Suplements.Suplement> GetAll(SuplementSearchParams suplementSearch)
        {
            IQueryable<Database.Suplement> query = _context.Suplements
                .AsQueryable()
                .Include(x => x.SuplementType);

            if (!string.IsNullOrEmpty(suplementSearch.Name))
            {
                query = query.Where(x => x.Name == suplementSearch.Name);
            }

            if (!string.IsNullOrEmpty(suplementSearch.Type))
            {
                query = query.Where(x => x.SuplementType.Type == suplementSearch.Type);
            }

            return query.Select(x => mapFromDb(x))
                .ToList();
        }

        public Models.Suplements.Suplement Create(SuplementCreateRequest suplementCreateRequest)
        {
            Database.Suplement suplement = _mapper.Map<Database.Suplement>(suplementCreateRequest);
            suplement.CreatedAt = DateTime.Now;
            _context.Suplements.Add(suplement);
            _context.SaveChanges();
            return mapFromDb(suplement);
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

        private Models.Suplements.Suplement mapFromDb(Database.Suplement dbSuplement)
        {
            Models.Suplements.Suplement suplement = new Models.Suplements.Suplement();
            suplement.SuplementTypeName = dbSuplement.SuplementType?.Type;
            _mapper.Map(dbSuplement, suplement);
            return suplement;
        }
    }
}
