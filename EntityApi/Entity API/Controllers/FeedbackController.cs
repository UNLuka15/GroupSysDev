using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : ReadBaseController<Feedback>
    {
        public override IReadRepository<Feedback> _repository => new FeedbackRepository();
    }
}
