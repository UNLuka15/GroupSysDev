using EntityAPI.Factories;
using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExhibitController : ControllerBase
    {
        // TODO: Add authorisation.

        [HttpGet("All")]
        public IActionResult GetExhibitList() 
        {
            var exhibitList = new ExhibitRepository().GetAll();
            return exhibitList != null ? Ok(exhibitList) : NoContent();
        }

        [HttpGet("ByMuseum")]
        public IActionResult GetExhibitByMuseumList(string museumCode)
        {
            var exhibitList = new ExhibitRepository().GetByMuseumCode(museumCode);
            return exhibitList != null ? Ok(exhibitList) : NoContent();
        }

        [HttpGet("Single")]
        public IActionResult GetExhibit(string id)
        {
            int intId;

            if (Int32.TryParse(id, out intId))
            {
                var exhibit = new ExhibitRepository().GetById(intId);
                return exhibit != null ? Ok(exhibit) : NotFound();
            }

            return BadRequest();
        }

        [HttpPost("Add")]
        public IActionResult AddExhibit([FromBody]ExhibitRequestModel exhibitRequest)
        {
            // Split up the translation into multiple smaller methods.
            try
            {
                var newExhibit = new ExhibitFactory().Create(exhibitRequest);
                new ExhibitRepository().AddNew(newExhibit);

                return Ok($"'{newExhibit.Name}' exhibit created with Id '{newExhibit.Id}'.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Remove")]
        public IActionResult RemoveExhibit(string id) 
        {
            int intId;

            if (Int32.TryParse(id, out intId))
            {
                var success = new ExhibitRepository().RemoveById(intId);

                return success ? Ok($"Exhibit with id '{intId}' successfully removed.") 
                               : NotFound($"Exhibit with id '{intId} not found.'");
            }

            return BadRequest();
        }
    }
}
