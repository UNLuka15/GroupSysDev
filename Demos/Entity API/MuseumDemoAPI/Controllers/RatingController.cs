using Microsoft.AspNetCore.Mvc;
using MuseumDemoAPI.Models;

namespace MuseumDemoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : ControllerBase
    {
        [HttpGet("Levels/All")]
        public List<RatingLevel> GetRatingLevelList()
        {
            List<RatingLevel> ratingLevels = new List<RatingLevel>();

            using (var db = new RatingLevelContext())
            {
                ratingLevels = db.RatingLevels.ToList();
            }

            return ratingLevels;
        }

        [HttpGet("CustomerRatings/All")]
        public List<SatisfactionRating> GetCustomerRatingList()
        {
            List<SatisfactionRating> ratingLevels = new List<SatisfactionRating>();

            using (var db = new SatisfactionRatingContext())
            {
                ratingLevels = db.SatisfactionRatings.ToList();
            }

            return ratingLevels;
        }
    }
}
