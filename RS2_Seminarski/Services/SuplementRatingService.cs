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
    public class SuplementRatingService
    {
        private readonly FitnessCenterDbContext _context;

        public SuplementRatingService(FitnessCenterDbContext context)
        {
            _context = context;
        }

        public void CreateOrUpdateSuplementRating(SuplementRatingCreate ratingCreate, UserInfo userInfo)
        {
            if(ratingCreate.Rating < 1 || ratingCreate.Rating > 5)
            {
                throw new InvalidRatingValueException("Ocjena moze biti od 1 - 5");
            }

            Suplement suplement = _context.Suplements.Find(ratingCreate.SuplementId);
            if(suplement == null)
            {
                throw new ResourceNotFoundException($"Suplement with id: {ratingCreate.SuplementId} not found.");
            }

            SuplementsRating dbSuplementRating = _context.SuplementsRatings.Where(x => x.ClientId == userInfo.Id).FirstOrDefault();
            if(dbSuplementRating == null)
            {
                dbSuplementRating = new SuplementsRating();

                dbSuplementRating.ClientId = userInfo.Id;
                dbSuplementRating.SuplementId = ratingCreate.SuplementId;
                dbSuplementRating.Rating = ratingCreate.Rating;
                _context.SuplementsRatings.Add(dbSuplementRating);
            }
            else
            {
                dbSuplementRating.Rating = ratingCreate.Rating;
                _context.SuplementsRatings.Update(dbSuplementRating);
            }

            _context.SaveChanges();
        }

        public double GetAverageSuplementRating(int suplementId)
        {
            return _context.SuplementsRatings.Where(x => x.SuplementId == suplementId).Average(x => x.Rating);
        }

        public SuplementsRating GetUserSuplementRating(int userId, int suplementId)
        {
            return _context.SuplementsRatings.Where(x => x.SuplementId == suplementId).Where(x => x.ClientId == userId).FirstOrDefault();
        }
    }
}
