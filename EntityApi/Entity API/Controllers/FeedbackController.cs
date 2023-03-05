using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : ControllerBase
    {
        [HttpGet("All")]
        public IActionResult GetFeedbackList()
        {
            var feedbackList = new FeedbackRepository().GetAll();
            return feedbackList != null ? Ok(feedbackList) : NoContent();
        }

        // Include feedback and feedback line.
    }
}
