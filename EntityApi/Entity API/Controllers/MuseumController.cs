using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MuseumController : ControllerBase
    {
        [HttpGet("All")]
        public IActionResult GetMuseumList()
        {
            var museumList = new MuseumRepository().GetAll();
            return museumList != null ? Ok(museumList) : NoContent();
        }

        [HttpGet("Single")]
        public IActionResult GetMuseum(string id)
        {
            int intId;

            if (Int32.TryParse(id, out intId))
            {
                var museum = new MuseumRepository().GetById(intId);
                return museum != null ? Ok(museum) : NotFound();
            }

            return BadRequest();
        }

        [HttpPost("Add")]
        public IActionResult AddMuseum([FromBody] MuseumRequestModel museumRequest) 
        {
            var newMuseum = new Museum();
            var museumRepository = new MuseumRepository();

            newMuseum.Name = museumRequest.Name;
            newMuseum.Description = museumRequest.Description;

            var existingMuseums = museumRepository.GetAll();
            
            if (existingMuseums == null || existingMuseums.Any(m => m.Code == museumRequest.Code))
                return BadRequest($"There is already a museum with the code '{museumRequest.Code}'.");

            newMuseum.Code = museumRequest.Code;

            museumRepository.AddNew(newMuseum);

            return Ok($"'{newMuseum.Name}' museum created with Id '{newMuseum.Id}'.");
        }

        [HttpDelete("Remove")]
        public IActionResult RemoveMuseum(string id)
        {
            int intId;

            if (Int32.TryParse(id, out intId))
            {
                var success = new MuseumRepository().RemoveById(intId);

                return success ? Ok($"Museum with id '{intId}' successfully removed.")
                               : NotFound($"Museum with id '{intId} not found.'");
            }

            return BadRequest();
        }
    }
}
