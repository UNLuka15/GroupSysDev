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
        // TODO: Add GetExhibit By Museum Id.

        [HttpGet("All")]
        public IActionResult GetExhibitList() 
        {
            var exhibitList = new ExhibitRepository().GetAll();
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
            // TODO: Move the request translation logic to another class. It isn't the controller's responsibility.
            // Split up the translation into multiple smaller methods.
            var newExhibit = new Exhibit();
            var exhibitRepository = new ExhibitRepository();

            newExhibit.Name = exhibitRequest.Name;
            newExhibit.Museum = null;
            newExhibit.Description = exhibitRequest.Description;

            var museumExhibits = exhibitRepository.GetByMuseumCode(exhibitRequest.MuseumCode);

            if (museumExhibits == null || museumExhibits.Any(e => e.Reference == exhibitRequest.Reference))
                return BadRequest($"There is already an exhibit with the reference '{exhibitRequest.Reference}'.");
             
            newExhibit.Reference = exhibitRequest.Reference;

            var existingMuseum = new MuseumRepository().GetByCode(exhibitRequest.MuseumCode);
            if (existingMuseum == null)
                return BadRequest($"Cannot find museum with code '{exhibitRequest.MuseumCode}'.");

            newExhibit.Museum = existingMuseum;

            DateTime parsedDate;
            if (exhibitRequest.OpeningTime != null) 
            {
                if (DateTime.TryParse(exhibitRequest.OpeningTime, out parsedDate))
                    newExhibit.OpeningTime = parsedDate;
                else
                    return BadRequest("OpeningTime was in the incorrect format.");
            }

            if (exhibitRequest.ClosingTime != null)
            {
                if (DateTime.TryParse(exhibitRequest.ClosingTime, out parsedDate))
                    newExhibit.ClosingTime = parsedDate;
                else
                    return BadRequest("ClosingTime was in the incorrect format.");
            }

            new ExhibitRepository().AddNew(newExhibit);

            return Ok($"'{newExhibit.Name}' exhibit created with Id '{newExhibit.Id}'.");
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
