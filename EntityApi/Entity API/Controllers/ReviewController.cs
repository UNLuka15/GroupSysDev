using EntityAPI.Factories;
using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers 
{
    [Route("[controller]")]
    public class ReviewController : WriteBaseController<Review, ReviewRequestModel>
    {
        public override IRepository<Review> _repository { get => new ReviewRepository(); }
        public override IModelFactory<Review, ReviewRequestModel> _factory { get => new ReviewFactory(); }
    }
}