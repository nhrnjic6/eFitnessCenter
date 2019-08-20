using RS2_Seminarski.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Services
{
    public class RecommenderService
    {
        private readonly FitnessCenterDbContext _context;
        private Dictionary<int, List<SuplementsRating>> suplementRatings; 

        public RecommenderService(FitnessCenterDbContext context)
        {
            _context = context;
        }  

        public List<Models.Suplements.Suplement> GetSimilarSuplements(int suplementId)
        {
            List<Suplement> reccomendedSuplements = new List<Suplement>();

            // get ratings for all suplements other than current suplement
            List<Suplement> restOfSuplements = _context.Suplements
                .Where(x => x.SuplementTypeId == suplementId)
                .ToList();

            foreach(var suplement in restOfSuplements)
            {
                List<SuplementsRating> ratings = _context.SuplementsRatings
                    .Where(x => x.SuplementId == suplement.Id)
                    .OrderBy(x => x.ClientId)
                    .ToList();

                if(ratings.Count > 0)
                {
                    suplementRatings.Add(suplementId, ratings);
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
                    Suplement suplement = _context.Suplements.Find(ratings.Key);
                    reccomendedSuplements.Add(suplement);
                }
            }
        }

        private double GetSimilarityBetweenProducts(List<SuplementsRating> rating1, List<SuplementsRating> rating2)
        {
            throw new NotImplementedException();
        }
    }
}
