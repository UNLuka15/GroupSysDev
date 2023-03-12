//using EntityAPI.Factories;
//using EntityAPI.Models;
//using EntityAPI.Repositories;
//using Microsoft.AspNetCore.Mvc;

//namespace EntityAPI.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class ReviewController : ControllerBase
//    {
//        [HttpGet("All")]
//        public IActionResult GetReviewList()
//        {
//            var reviewList = new ReviewRepository().GetAll();
//            return reviewList != null ? Ok(reviewList) : NoContent();
//        }

//        [HttpGet("Single")]
//        public IActionResult GetReview(string id)
//        {
//            int intId;

//            if (Int32.TryParse(id, out intId))
//            {
//                var exhibit = new ReviewRepository().GetById(intId);
//                return exhibit != null ? Ok(exhibit) : NotFound();
//            }

//            return BadRequest();
//        }

//        [HttpPost("Add")]
//        public IActionResult AddReview([FromBody] ExhibitRequestModel exhibitRequest)
//        {
//            // Split up the translation into multiple smaller methods.
//            try
//            {
//                var newExhibit = new ExhibitFactory().Create(exhibitRequest);
//                new ExhibitRepository().AddNew(newExhibit);

//                return Ok($"'{newExhibit.Name}' exhibit created with Id '{newExhibit.Id}'.");
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpDelete("Remove")]
//        public IActionResult RemoveReview(string id)
//        {
//            int intId;

//            if (Int32.TryParse(id, out intId))
//            {
//                var success = new ExhibitRepository().RemoveById(intId);

//                return success ? Ok($"Exhibit with id '{intId}' successfully removed.")
//                               : NotFound($"Exhibit with id '{intId} not found.'");
//            }

//            return BadRequest();
//        }
//    }
//}

using EntityAPI.Factories;
using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers 
{
    [Route("[controller]")]
    public class ReviewController : BaseController<Review, ReviewRequestModel>
    {
        public override IRepository<Review> _repository { get => new ReviewRepository(); }
        public override IModelFactory<Review, ReviewRequestModel> _factory { get => new ReviewFactory(); }
    }
}