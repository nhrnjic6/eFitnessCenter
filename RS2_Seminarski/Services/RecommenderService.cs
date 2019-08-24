using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RS2_Seminarski.Database;
using RS2_Seminarski.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Services
{
    public class RecommenderService
    {
        private readonly FitnessCenterDbContext _context;
        private Dictionary<int, List<SuplementsRating>> suplementRatings = new Dictionary<int, List<SuplementsRating>>();
        private readonly IMapper _mapper;

        public RecommenderService(FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }  

        public List<Models.Suplements.Suplement> GetSimilarSuplements(int suplementId, UserInfo userInfo)
        {
            List<Suplement> reccomendedSuplements = new List<Suplement>();

            // get ratings for all suplements other than current suplement
            List<Suplement> restOfSuplements = _context.Suplements
                .Where(x => x.Id != suplementId)
                .ToList();

            foreach(var suplement in restOfSuplements)
            {
                List<SuplementsRating> ratings = _context.SuplementsRatings
                    .Where(x => x.SuplementId == suplement.Id)
                    .OrderBy(x => x.ClientId)
                    .ToList();

                if(ratings.Count > 0)
                {
                    suplementRatings.Add(suplement.Id, ratings);
                }
            }

            // get current suplement ratings
            List<SuplementsRating> currentSuplementRating = _context.SuplementsRatings
                .Where(x => x.SuplementId == suplementId)
                .OrderBy(x => x.ClientId)
                .ToList();

            foreach(var ratings in suplementRatings)
            {
                List<SuplementsRating> rating1 = new List<SuplementsRating>(); 
                List<SuplementsRating> rating2 = new List<SuplementsRating>();

                foreach (var rating in currentSuplementRating)
                {
                    if(ratings.Value.Where(x => x.ClientId == rating.ClientId).Count() > 0)
                    {
                        rating1.Add(rating);
                        rating2.Add(ratings.Value.Where(x => x.ClientId == rating.ClientId).First());
                    }
                }

                double similarity = GetSimilarityBetweenProducts(rating1, rating2);

                if(similarity > 0.5)
                {
                    Suplement suplement = _context.Suplements
                        .Include(x => x.SuplementsRatings)
                        .Include(x => x.SuplementType)
                        .Where(x => x.Id == ratings.Key)
                        .FirstOrDefault();

                    reccomendedSuplements.Add(suplement);
                }
            }

            return reccomendedSuplements.Select(x => mapFromDb(x, userInfo)).ToList();
        }

        private double GetSimilarityBetweenProducts(List<SuplementsRating> rating1, List<SuplementsRating> rating2)
        {
            if (rating1.Count != rating2.Count) return 0;
            if (rating1.Count == 0 || rating2.Count == 0) return 0;

            double numerator = 0, denominator1 = 0, denominator2 = 0;

            double rating1Avg = rating1.Average(x => x.Rating);
            double rating2Avg = rating2.Average(x => x.Rating);

            for(int i = 0; i < rating1.Count; i++)
            {
                numerator += (rating1[i].Rating - rating1Avg) * (rating2[i].Rating - rating2Avg);
                denominator1 += Math.Pow(rating1[i].Rating - rating1Avg, 2);
                denominator2 += Math.Pow(rating2[i].Rating - rating2Avg, 2);
            }

            double denominator = Math.Sqrt(denominator1) * Math.Sqrt(denominator2);

            if (denominator == 0) return 0;

            return numerator / denominator;
        }

        private Models.Suplements.Suplement mapFromDb(Database.Suplement dbSuplement, UserInfo userInfo)
        {
            Models.Suplements.Suplement suplement = new Models.Suplements.Suplement();
            _mapper.Map(dbSuplement, suplement);
            suplement.SuplementTypeName = dbSuplement.SuplementType?.Type;
            suplement.CreatedAt = dbSuplement.CreatedAt.ToString("dd-MM-yyyy");

            if (dbSuplement.SuplementsRatings != null && dbSuplement.SuplementsRatings.Count > 0)
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
