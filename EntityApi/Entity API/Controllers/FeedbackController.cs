using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [Route("[controller]")]
    public class FeedbackController : ReadBaseController<Feedback>
    {
        public FeedbackController(IRepository<Feedback> repository) : base(repository)
        {
        }
    }
}
