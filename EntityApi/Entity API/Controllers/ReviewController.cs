using EntityAPI.Factories;
using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers 
{
    [Route("[controller]")]
    public class ReviewController : WriteBaseController<Review, ReviewRequestModel>
    {
        public ReviewController(IModelFactory<Review, ReviewRequestModel> factory, IRepository<Review> repository) : base(factory, repository)
        {
        }
    }
}